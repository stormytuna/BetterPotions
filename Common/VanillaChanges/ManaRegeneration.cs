using System.Collections.Generic;
using System.Linq;
using BetterPotions.Common.Configs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace BetterPotions.Common.VanillaChanges;

public class ManaRegenerationGlobalBuff : GlobalBuff
{
    public override bool IsLoadingEnabled(Mod mod) => BetterPotionsConfig.Instance.PotionChanges_ManaRegen;

    public override void Update(int type, Player player, ref int buffIndex) {
        if (type != BuffID.ManaRegeneration) {
            return;
        }

        player.GetModPlayer<ManaRegenerationPlayer>().ManaRegeneration = true;
    }

    public override void ModifyBuffText(int type, ref string buffName, ref string tip, ref int rare) {
        if (type != BuffID.ManaRegeneration) {
            return;
        }

        tip = Language.GetTextValue("Mods.BetterPotions.VanillaChanges.ManaRegenerationPotion");
    }
}

public class ManaRegenerationPlayer : ModPlayer
{
    private int manaRegenerationCounter;

    public bool ManaRegeneration { get; set; }

    public override void ResetEffects() {
        ManaRegeneration = false;
    }

    public override void PostUpdateBuffs() {
        if (!ManaRegeneration) {
            return;
        }

        manaRegenerationCounter++;
        if (manaRegenerationCounter > 15 && Player.statMana < Player.statManaMax2) {
            Player.statMana++;
            manaRegenerationCounter = 0;
        }
    }
}

public class ManaRegenerationGlobalItem : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod) => BetterPotionsConfig.Instance.PotionChanges_ManaRegen;

    public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.type == ItemID.ManaRegenerationPotion;

    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
        TooltipLine line = tooltips.FirstOrDefault(tip => tip.Name == "Tooltip0");
        if (line is null) {
            return;
        }

        line.Text = Language.GetTextValue("Mods.BetterPotions.VanillaChanges.BuffManaRegeneration");
    }
}
