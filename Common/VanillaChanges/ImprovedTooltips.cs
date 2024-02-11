using System.Collections.Generic;
using System.Linq;
using BetterPotions.Common.Configs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterPotions.Common.VanillaChanges;

public class ImprovedTooltipsGlobalItem : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod) => BetterPotionsConfig.Instance.PotionsAndBuffsImprovedTooltips;

    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
        TooltipLine line = tooltips.FirstOrDefault(tip => tip.Name == "Tooltip0");
        if (line is null) {
            return;
        }

        line.Text = item.type switch {
            ItemID.BattlePotion => "Increases enemy spawn rate and spawn cap by 100%",
            ItemID.CalmingPotion => "Decreases enemy spawn rate by 17% and decreases enemy spawn cap by 20%",
            ItemID.CratePotion => "Increases chance to get a crate by 10%",
            ItemID.TrapsightPotion => "Allows you to see nearby sources of danger",
            ItemID.FeatherfallPotion => "Slows falling speed\nPress UP or DOWN to control speed of descent",
            ItemID.FishingPotion => "Increases fishing power by 15",
            ItemID.FlipperPotion => "Allows you to swim swiftly in liquids",
            ItemID.GillsPotion => "Allows you to breathe underwater",
            ItemID.GravitationPotion => "Allows you to control gravity\nPress UP to reverse gravity",
            ItemID.InvisibilityPotion => "Grants invisibility and decreases enemy spawn rate by 20%",
            ItemID.IronskinPotion => "Increases defense by 8",
            ItemID.MagicPowerPotion => "Increases magic damage by 20%",
            ItemID.NightOwlPotion => "Allows you to see better in the dark",
            ItemID.RegenerationPotion => "Grants life regeneration",
            ItemID.SwiftnessPotion => "Increases movement speed by 25%",
            ItemID.TitanPotion => "Increases knockback by 50%",
            ItemID.WarmthPotion => "Reduces damage from cold sources by 30%",
            ItemID.WaterWalkingPotion => "Grants the ability to walk on liquids\nPress DOWN to enter liquid",
            _ => line.Text
        };
    }
}

public class ImprovedTooltipsGlobalBuff : GlobalBuff
{
    public override bool IsLoadingEnabled(Mod mod) => BetterPotionsConfig.Instance.PotionsAndBuffsImprovedTooltips;

    public override void ModifyBuffText(int type, ref string buffName, ref string tip, ref int rare) {
        tip = type switch {
            BuffID.Battle => "100% increased enemy spawn rate and spawn cap",
            BuffID.Calm => "17% decreased enemy spawn rate and 20% decreased enemy spawn cap",
            BuffID.Crate => "10% increased chance of fishing up a crate",
            BuffID.Dangersense => "You can see nearby sources of danger",
            BuffID.Featherfall => "Falling speed is slowed\nPress UP or DOWN to control speed of descent",
            BuffID.Fishing => "Increased fishing power by 15",
            BuffID.Flipper => "Swim swiftly in liquids",
            BuffID.Gills => "Breathe underwater",
            BuffID.Gravitation => "Control gravity\nPress UP to reverse gravity",
            BuffID.Invisibility => "Invisible and 20% decreased enemy spawn rate",
            BuffID.Ironskin => "Increased defense by 8",
            BuffID.NightOwl => "You can see better in the dark",
            BuffID.Regeneration => "Increased life regeneration",
            BuffID.Titan => "50% increased knockback",
            BuffID.Warmth => "30% reduced damage from cold sources",
            BuffID.WaterWalking => "Walk on liquids\nPress DOWN to enter liquid",
            _ => tip
        };
    }
}
