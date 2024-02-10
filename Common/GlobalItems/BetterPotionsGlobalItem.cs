using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using BetterPotions.Common.Configs;
using BetterPotions.Content.Potions.DiscoInferno;
using BetterPotions.Content.Potions.War;
using BetterPotions.Content.Potions.Orichalcumskin;
using BetterPotions.Content.Potions.HeightenedSenses;
using BetterPotions.Content.Potions.Predator;

namespace BetterPotions.Common.GlobalItems
{
    public class BetterPotionsGlobalItem : GlobalItem
    {
        #region Tooltips

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine line;
            var modConfig = ModContent.GetInstance<BetterPotionsConfig>();

            if (item.type == ItemID.ArcheryPotion && modConfig.PotionChanges_Archery)
            {
                line = tooltips.Find(x => x.Name == "Tooltip0");
                line.Text = "Increases ranged damage and critical chance by 10%";
            }

            if (item.type == ItemID.AmmoReservationPotion && modConfig.PotionChanges_AmmoReservation)
            {
                line = tooltips.Find(x => x.Name == "Tooltip0");
                line.Text = "Increases chance to not consume ammo by 50%";
            }

            if (item.type == ItemID.BuilderPotion && modConfig.PotionChanges_Builder)
            {
                line = tooltips.Find(x => x.Name == "Tooltip0");
                if (modConfig.PotionsAndBuffsImprovedTooltips)
                    line.Text = "Increases placement range by 3 tiles and placement speed by 50%";
                else
                    line.Text = "Increases placement range by 1 tiles and placement speed by 25%";
            }

            if (item.type == ItemID.ManaRegenerationPotion && modConfig.PotionChanges_ManaRegen)
            {
                line = tooltips.Find(x => x.Name == "Tooltip0");
                line.Text = "Increases mana regeneration and constantly regenerate 4 mana per second";
            }

            if (item.type == ItemID.ObsidianSkinPotion && modConfig.PotionChanges_ObsidianSkin)
            {
                line = tooltips.Find(x => x.Name == "Tooltip0");
                line.Text = "Grants immunity to fire, lava, cursed flames and ichor";
            }

            if (item.type == ItemID.SummoningPotion && modConfig.PotionChanges_Summoning)
            {
                line = tooltips.Find(x => x.Name == "Tooltip0");
                line.Text = "Increases your max number of minions and sentries by 1 and increases summon damage by 10%";
            }

            if (modConfig.PotionsAndBuffsImprovedTooltips)
            {
                switch (item.type)
                {
                    case ItemID.BattlePotion:
                        line = tooltips.Find(x => x.Name == "Tooltip0");
                        line.Text = "Increases enemy spawn rate and spawn cap by 100%";
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
                    case ItemID.NightOwlPotion:
                        line = tooltips.Find(x => x.Name == "Tooltip0");
                        line.Text = "Allows you to see better in the dark";
                        break;
                    case ItemID.RegenerationPotion:
                        line = tooltips.Find(x => x.Name == "Tooltip0");
                        line.Text = "Grants life regeneration";
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
        }

        #endregion

        public override void SetDefaults(Item item)
        {
            var modConfig = ModContent.GetInstance<BetterPotionsConfig>();

            if (ItemID.Search.TryGetName(item.type, out string itemName) && modConfig.PotionsLastTenMinutes)
            {
                if (item.buffType > 0 && BuffShouldBeTenMinutes(item.buffType) && item.buffTime < 10 * 60 * 60 && !modConfig.TenMinutePotionsBlacklist.Contains(new ItemDefinition(itemName)))
                    item.buffTime = 10 * 60 * 60;
            }

            if (item.type == ItemID.ArcheryPotion && modConfig.PotionChanges_Archery)
            {
                item.SetNameOverride("Predator Potion");
                item.buffType = ModContent.BuffType<PredatorBuff>();
            }
        }

        private bool BuffShouldBeTenMinutes(int buffType)
            => !Main.debuff[buffType] && !Main.vanityPet[buffType] && !Main.lightPet[buffType] && !Main.buffNoTimeDisplay[buffType];

        public override bool CanUseItem(Item item, Player player)
        {
            switch (item.type)
            {
                case ItemID.BattlePotion:
                    return !player.HasBuff(ModContent.BuffType<WarBuff>());
                case ItemID.InfernoPotion:
                    return !player.HasBuff(ModContent.BuffType<DiscoInfernoBuff>());
                case ItemID.IronskinPotion:
                    return !player.HasBuff(ModContent.BuffType<OrichalcumskinBuff>());
                case ItemID.HunterPotion:
                case ItemID.NightOwlPotion:
                case ItemID.TrapsightPotion:
                    return !player.HasBuff(ModContent.BuffType<HeightenedSensesBuff>());
            }

            return base.CanUseItem(item, player);
        }
    }
}
