using System.Collections.Generic;
using System.Linq;
using BetterPotions.Common.Configs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace BetterPotions.Common.VanillaChanges;

public class ObsidianSkinGlobalBuff : GlobalBuff
{
    public override bool IsLoadingEnabled(Mod mod) => BetterPotionsConfig.Instance.PotionChanges_ObsidianSkin;

    public override void Update(int type, Player player, ref int buffIndex) {
        if (type != BuffID.ObsidianSkin) {
            return;
        }

        player.buffImmune[BuffID.CursedInferno] = true;
        player.buffImmune[BuffID.Ichor] = true;
    }

    public override void ModifyBuffText(int type, ref string buffName, ref string tip, ref int rare) {
        if (type != BuffID.ObsidianSkin) {
            return;
        }

        tip = Language.GetTextValue("Mods.BetterPotions.VanillaChanges.BuffObsidianSkin");
    }
}

public class ObsidianSkinGlobalItem : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod) => BetterPotionsConfig.Instance.PotionChanges_ObsidianSkin;

    public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.type == ItemID.ObsidianSkinPotion;

    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
        TooltipLine line = tooltips.FirstOrDefault(tip => tip.Name == "Tooltip0");
        if (line is null) {
            return;
        }

        line.Text = Language.GetTextValue("Mods.BetterPotions.VanillaChanges.ObsidianSkinPotion");
    }
}
