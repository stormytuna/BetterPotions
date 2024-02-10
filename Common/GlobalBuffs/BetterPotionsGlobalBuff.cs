using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BetterPotions.Common.Players;
using BetterPotions.Common.Configs;

namespace BetterPotions.Common.GlobalBuffs
{
    public class BetterPotionsGlobalBuff : GlobalBuff
    {
        #region Tooltips
        public override void ModifyBuffText(int type, ref string buffName, ref string tip, ref int rare)
        {
            var modConfig = ModContent.GetInstance<BetterPotionsConfig>();

            if (modConfig.PotionsAndBuffsImprovedTooltips)
            {
                switch (type)
                {
                    case BuffID.AmmoReservation:
                        tip = "50% chance not to consume ammo";
                        break;
                    case BuffID.Battle:
                        tip = "100% increased enemy spawn rate and spawn cap";
                        break;
                    case BuffID.Builder:
                        if (modConfig.PotionChanges_Builder)
                            tip = "Increased placement range by 3 tiles and placement speed by 50%";
                        if (!modConfig.PotionChanges_Builder)
                            tip = "Increased placement range by 1 tile and placement speed by 25%";
                        break;
                    case BuffID.Calm:
                        tip = "17% decreased enemy spawn rate and 20% decreased enemy spawn cap";
                        break;
                    case BuffID.Crate:
                        tip = "10% increased chance of fishing up a crate";
                        break;
                    case BuffID.Dangersense:
                        tip = "You can see nearby sources of danger";
                        break;
                    case BuffID.Featherfall:
                        tip = "Falling speed is slowed\nPress UP or DOWN to control speed of descent";
                        break;
                    case BuffID.Fishing:
                        tip = "Increased fishing power by 15";
                        break;
                    case BuffID.Flipper:
                        tip = "Swim swiftly in liquids";
                        break;
                    case BuffID.Gills:
                        tip = "Breathe underwater";
                        break;
                    case BuffID.Gravitation:
                        tip = "Control gravity\nPress UP to reverse gravity";
                        break;
                    case BuffID.Invisibility:
                        tip = "Invisible and 20% decreased enemy spawn rate";
                        break;
                    case BuffID.Ironskin:
                        tip = "Increased defense by 8";
                        break;
                    case BuffID.ManaRegeneration:
                        if (modConfig.PotionChanges_ManaRegen)
                            tip = "Increased mana regeneration and constantly regenerate 4 mana per second";
                        break;
                    case BuffID.NightOwl:
                        tip = "You can see better in the dark";
                        break;
                    case BuffID.ObsidianSkin:
                        if (modConfig.PotionChanges_ObsidianSkin)
                            tip = "Immune to fire, lava, cursed flames and ichor";
                        break;
                    case BuffID.Regeneration:
                        tip = "Increased life regeneration";
                        break;
                    case BuffID.Summoning:
                        if (modConfig.PotionChanges_Summoning)
                            tip = "Increased max number of minions and sentries by 1 and 10% increased summon damage";
                        break;
                    case BuffID.Titan:
                        tip = "50% increased knockback";
                        break;
                    case BuffID.Warmth:
                        tip = "30% reduced damage from cold sources";
                        break;
                    case BuffID.WaterWalking:
                        tip = "Walk on liquids\nPress DOWN to enter liquid";
                        break;
                }
            }
        }
        #endregion

        public override void Update(int type, Player player, ref int buffIndex)
        {
            var modPlayer = player.GetModPlayer<BetterPotionsPlayer>();
            var modConfig = ModContent.GetInstance<BetterPotionsConfig>();

            switch (type)
            {
                case BuffID.AmmoReservation:
                    if (modConfig.PotionChanges_AmmoReservation)
                    {
                        player.ammoPotion = false;
                        modPlayer.ammoReservation = true;
                    }
                    break;
                case BuffID.Builder:
                    if (modConfig.PotionChanges_Builder)
                    {
                        player.tileSpeed += 0.25f;
                        player.wallSpeed += 0.25f;
                        player.blockRange += 2;
                    }
                    break;
                case BuffID.ManaRegeneration:
                    if (modConfig.PotionChanges_ManaRegen)
                    {
                        modPlayer.manaRegeneration = true;
                    }
                    break;
                case BuffID.ObsidianSkin:
                    if (modConfig.PotionChanges_ObsidianSkin)
                    {
                        player.buffImmune[BuffID.CursedInferno] = true;
                        player.buffImmune[BuffID.Ichor] = true;
                    }
                    break;
                case BuffID.Summoning:
                    if (modConfig.PotionChanges_Summoning)
                    {
                        player.maxTurrets++;
                        player.GetDamage(DamageClass.Summon) += 0.1f;
                    }
                    break;
            }
        }
    }
}
