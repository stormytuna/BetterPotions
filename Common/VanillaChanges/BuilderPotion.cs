using System.Collections.Generic;
using System.Linq;
using BetterPotions.Common.Configs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace BetterPotions.Common.VanillaChanges;

public class BuilderPotionGlobalBuff : GlobalBuff
{
    public override bool IsLoadingEnabled(Mod mod) => BetterPotionsConfig.Instance.PotionChanges_Builder;

    public override void Update(int type, Player player, ref int buffIndex) {
        if (type != BuffID.Builder) {
            return;
        }

        player.tileSpeed += 0.25f;
        player.wallSpeed += 0.25f;
        player.blockRange += 2;
    }

    public override void ModifyBuffText(int type, ref string buffName, ref string tip, ref int rare) {
        if (type != BuffID.Builder) {
            return;
        }

        if (BetterPotionsConfig.Instance.PotionChanges_Builder) {
            tip = Language.GetTextValue("Mods.BetterPotions.VanillaChanges.BuilderPotion");
        } else {
            tip = Language.GetTextValue("ItemTooltip.BuilderPotion");
        }
    }
}

public class BuilderPotionGlobalItem : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod) => BetterPotionsConfig.Instance.PotionChanges_Builder;

    public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.type == ItemID.BuilderPotion;

    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
        TooltipLine line = tooltips.FirstOrDefault(tip => tip.Name == "Tooltip0");
        if (line is null) {
            return;
        }

        if (BetterPotionsConfig.Instance.PotionsAndBuffsImprovedTooltips) {
            line.Text = Language.GetTextValue("Mods.BetterPotions.VanillaChanges.BuffBuilder");
        } else {
            line.Text = Language.GetTextValue("BuffDescription.BuilderIncreases");
        }
    }
}
