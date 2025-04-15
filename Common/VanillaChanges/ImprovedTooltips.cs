using System.Collections.Generic;
using System.Linq;
using BetterPotions.Common.Configs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

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
            ItemID.BattlePotion => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.BattlePotion"),
            ItemID.CalmingPotion => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.CalmingPotion"),
            ItemID.CratePotion => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.CratePotion"),
            ItemID.TrapsightPotion => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.TrapsightPotion"),
            ItemID.FeatherfallPotion => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.FeatherfallPotion"),
            ItemID.FishingPotion => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.FishingPotion"),
            ItemID.FlipperPotion => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.FlipperPotion"),
            ItemID.GillsPotion => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.GillsPotion"),
            ItemID.GravitationPotion => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.GravitationPotion"),
            ItemID.InvisibilityPotion => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.InvisibilityPotion"),
            ItemID.IronskinPotion => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.IronskinPotion"),
            ItemID.MagicPowerPotion => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.MagicPowerPotion"),
            ItemID.NightOwlPotion => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.NightOwlPotion"),
            ItemID.RegenerationPotion => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.RegenerationPotion"),
            ItemID.SwiftnessPotion => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.SwiftnessPotion"),
            ItemID.TitanPotion => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.TitanPotion"),
            ItemID.WarmthPotion => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.WarmthPotion"),
            ItemID.WaterWalkingPotion => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.WaterWalkingPotion"),
            _ => line.Text
        };
    }
}

public class ImprovedTooltipsGlobalBuff : GlobalBuff
{
    public override bool IsLoadingEnabled(Mod mod) => BetterPotionsConfig.Instance.PotionsAndBuffsImprovedTooltips;

    public override void ModifyBuffText(int type, ref string buffName, ref string tip, ref int rare) {
        tip = type switch {
            BuffID.Battle => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.BuffBattle"),
            BuffID.Calm => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.BuffCalm"),
            BuffID.Crate => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.BuffCrate"),
            BuffID.Dangersense => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.BuffDangersense"),
            BuffID.Featherfall => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.BuffFeatherfall"),
            BuffID.Fishing => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.BuffFishing"),
            BuffID.Flipper => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.BuffFlipper"),
            BuffID.Gills => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.BuffGills"),
            BuffID.Gravitation => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.BuffGravitation"),
            BuffID.Invisibility => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.BuffInvisibility"),
            BuffID.Ironskin => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.BuffIronskin"),
            BuffID.NightOwl => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.BuffNightOwl"),
            BuffID.Regeneration => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.BuffRegeneration"),
            BuffID.Titan => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.BuffTitan"),
            BuffID.Warmth => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.BuffWarmth"),
            BuffID.WaterWalking => Language.GetTextValue("Mods.BetterPotions.VanillaChanges.BuffWaterWalking"),
            _ => tip
        };
    }
}
