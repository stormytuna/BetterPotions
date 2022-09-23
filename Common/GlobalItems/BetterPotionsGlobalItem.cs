using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BetterPotions.Content.Buffs;

namespace BetterPotions.Common.GlobalItems
{
    public class BetterPotionsGlobalItem : GlobalItem
    {
        #region Tooltips

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine line;

            switch (item.type)
            {
                case ItemID.AmmoReservationPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Increases chance to not consume ammo by 30%";
                    break;
                case ItemID.ArcheryPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Increases ranged damage and critical chance by 10%";
                    break;
                case ItemID.BattlePotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Increases enemy spawn rate and spawn cap by 100%";
                    break;
                case ItemID.BuilderPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Increases placement range by 3 tiles and placement speed by 50%";
                    break;
                case ItemID.CalmingPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Decreases enemy spawn rate by 17% and decreases enemy spawn cap by 20%";
                    break;
                case ItemID.CratePotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Increases chance to get a crate by 10%";
                    break;
                case ItemID.TrapsightPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Allows you to see nearby sources of danger";
                    break;
                case ItemID.FeatherfallPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Slows falling speed\nPress UP or DOWN to control speed of descent";
                    break;
                case ItemID.FishingPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Increases fishing power by 15";
                    break;
                case ItemID.FlipperPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Allows you to swim swiftly in liquids";
                    break;
                case ItemID.GillsPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Allows you to breathe underwater";
                    break;
                case ItemID.GravitationPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Allows you to control gravity\nPress UP to reverse gravity";
                    break;
                case ItemID.InvisibilityPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Grants invisibility and decreases enemy spawn rate by 20%";
                    break;
                case ItemID.IronskinPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Increases defense by 8";
                    break;
                case ItemID.MagicPowerPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Increases magic damage by 20%";
                    break;
                case ItemID.ManaRegenerationPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Increases mana regeneration and constantly regenerate 4 mana per second";
                    break;
                case ItemID.NightOwlPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Allows you to see better in the dark";
                    break;
                case ItemID.ObsidianSkinPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Grants immunity to fire and lava";
                    break;
                case ItemID.RegenerationPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Grants life regeneration";
                    break;
                case ItemID.SummoningPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Increases your max number of minions and sentries by 1 and increases minion damage by 10%";
                    break;
                case ItemID.SwiftnessPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Increases movement speed by 25%";
                    break;
                case ItemID.TitanPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Increases knockback by 50%";
                    break;
                case ItemID.WarmthPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Reduces damage from cold sources by 30%";
                    break;
                case ItemID.WaterWalkingPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Grants the ability to walk on liquids\nPress DOWN to enter liquid";
                    break;
            }
        }

        #endregion

        #region SetDefaults

        public override void SetDefaults(Item item)
        {
            switch (item.type)
            {
                case ItemID.AmmoReservationPotion:
                    item.buffTime = 10 * 60 * 60;
                    break;
                case ItemID.ArcheryPotion:
                    item.SetNameOverride("Predator Potion");
                    item.buffType = ModContent.BuffType<Predator>();
                    item.buffTime = 10 * 60 * 60;
                    break;
                case ItemID.BattlePotion:
                    item.buffTime = 10 * 60 * 60;
                    break;
                case ItemID.CalmingPotion:
                    item.buffTime = 10 * 60 * 60;
                    break;
                case ItemID.CratePotion:
                    item.buffTime = 10 * 60 * 60;
                    break;
                case ItemID.EndurancePotion:
                    item.buffTime = 10 * 60 * 60;
                    break;
                case ItemID.FishingPotion:
                    item.buffTime = 10 * 60 * 60;
                    break;
                case ItemID.FlipperPotion:
                    item.buffTime = 10 * 60 * 60;
                    break;
                case ItemID.GillsPotion:
                    item.buffTime = 10 * 60 * 60;
                    break;
                case ItemID.GravitationPotion:
                    item.buffTime = 10 * 60 * 60;
                    break;
                case ItemID.HeartreachPotion:
                    item.buffTime = 10 * 60 * 60;
                    break;
                case ItemID.HunterPotion:
                    item.buffTime = 10 * 60 * 60;
                    break;
                case ItemID.InfernoPotion:
                    item.buffTime = 10 * 60 * 60;
                    break;
                case ItemID.InvisibilityPotion:
                    item.buffTime = 10 * 60 * 60;
                    break;
                case ItemID.IronskinPotion:
                    item.buffTime = 10 * 60 * 60;
                    break;
                case ItemID.LifeforcePotion:
                    item.buffTime = 10 * 60 * 60;
                    break;
                case ItemID.MagicPowerPotion:
                    item.buffTime = 10 * 60 * 60;
                    break;
                case ItemID.ManaRegenerationPotion:
                    item.buffTime = 10 * 60 * 60;
                    break;
                case ItemID.ObsidianSkinPotion:
                    item.buffTime = 10 * 60 * 60;
                    break;
                case ItemID.RagePotion:
                    item.buffTime = 10 * 60 * 60;
                    break;
                case ItemID.RegenerationPotion:
                    item.buffTime = 10 * 60 * 60;
                    break;
                case ItemID.SonarPotion:
                    item.buffTime = 10 * 60 * 60;
                    break;
                case ItemID.SpelunkerPotion:
                    item.buffTime = 10 * 60 * 60;
                    break;
                case ItemID.SummoningPotion:
                    item.buffTime = 10 * 60 * 60;
                    break;
                case ItemID.SwiftnessPotion:
                    item.buffTime = 10 * 60 * 60;
                    break;
                case ItemID.ThornsPotion:
                    item.buffTime = 10 * 60 * 60;
                    break;
                case ItemID.TitanPotion:
                    item.buffTime = 10 * 60 * 60;
                    break;
                case ItemID.WrathPotion:
                    item.buffTime = 10 * 60 * 60;
                    break;
            }
        }

        #endregion

        public override bool CanUseItem(Item item, Player player)
        {
            switch (item.type)
            {
                case ItemID.BattlePotion:
                    return !player.HasBuff(ModContent.BuffType<War>());
                case ItemID.InfernoPotion:
                    return !player.HasBuff(ModContent.BuffType<DiscoInferno>());
                case ItemID.IronskinPotion:
                    return !player.HasBuff(ModContent.BuffType<Orichalcumskin>());
            }

            return base.CanUseItem(item, player);
        }
    }
}