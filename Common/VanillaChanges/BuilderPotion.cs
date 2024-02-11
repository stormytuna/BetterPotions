using System.Collections.Generic;
using System.Linq;
using BetterPotions.Common.Configs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
            tip = "Increased placement range by 3 tiles and placement speed by 50%";
        } else {
            tip = "Increased placement range by 1 tile and placement speed by 25%";
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
            line.Text = "Increases placement range by 3 tiles and placement speed by 50%";
        } else {
            line.Text = "Increases placement range by 1 tiles and placement speed by 25%";
        }
    }
}
