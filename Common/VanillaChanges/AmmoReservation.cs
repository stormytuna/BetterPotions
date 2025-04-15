using System.Collections.Generic;
using System.Linq;
using BetterPotions.Common.Configs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace BetterPotions.Common.VanillaChanges;

public class AmmoReservationGlobalBuff : GlobalBuff
{
    public override bool IsLoadingEnabled(Mod mod) => BetterPotionsConfig.Instance.PotionChanges_AmmoReservation;

    public override void Update(int type, Player player, ref int buffIndex) {
        if (type != BuffID.AmmoReservation) {
            return;
        }

        player.ammoPotion = false;
        player.GetModPlayer<AmmoReservationPlayer>().AmmoReservation = true;
    }

    public override void ModifyBuffText(int type, ref string buffName, ref string tip, ref int rare) {
        if (type != BuffID.AmmoReservation) {
            return;
        }

        tip = Language.GetTextValue("Mods.BetterPotions.VanillaChanges.AmmoReservationPotion");
    }
}

public class AmmoReservationGlobalItem : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod) => BetterPotionsConfig.Instance.PotionChanges_AmmoReservation;

    public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.type == ItemID.AmmoReservationPotion;

    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
        TooltipLine line = tooltips.FirstOrDefault(tip => tip.Name == "Tooltip0");
        if (line is null) {
            return;
        }

        line.Text = Language.GetTextValue("Mods.BetterPotions.VanillaChanges.BuffAmmoReservation");
    }
}

public class AmmoReservationPlayer : ModPlayer
{
    public bool AmmoReservation { get; set; }

    public override void ResetEffects() {
        AmmoReservation = false;
    }

    public override bool CanConsumeAmmo(Item weapon, Item ammo) {
        if (AmmoReservation && Main.rand.NextFloat() < 0.5f) {
            return false;
        }

        return base.CanConsumeAmmo(weapon, ammo);
    }
}
