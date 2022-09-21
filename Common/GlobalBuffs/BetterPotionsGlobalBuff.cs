using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using BetterPotions.Common.Players;

namespace BetterPotions.Common.GlobalBuffs
{
    public class BetterPotionsGlobalBuff : GlobalBuff
    {
        #region Tooltips
        public override void ModifyBuffTip(int type, ref string tip, ref int rare)
        {
            switch (type)
            {
                case BuffID.AmmoReservation:
                    tip = "30% chance to not consume ammo";
                    break;
                case BuffID.Battle:
                    tip = "100% increased enemy spawn rate and spawn cap";
                    break;
                case BuffID.Builder:
                    tip = "Increased placement range by 3 tiles and placement speed by 50%";
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
                    tip = "Increased mana regeneration and constantly regenerate 4 mana per second";
                    break;
                case BuffID.NightOwl:
                    tip = "You can see better in the dark";
                    break;
                case BuffID.ObsidianSkin:
                    tip = "Immune to fire and lava";
                    break;
                case BuffID.Regeneration:
                    tip = "Increased life regeneration";
                    break;
                case BuffID.Summoning:
                    tip = "Increased max number of minions and sentries by 1 and 10% increased minion damage";
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
        #endregion

        public override void Update(int type, Player player, ref int buffIndex)
        {
            var modPlayer = player.GetModPlayer<BetterPotionsPlayer>();

            switch (type)
            {
                case BuffID.AmmoReservation:
                    player.ammoPotion = false;
                    modPlayer.ammoReservation = true;
                    break;
                case BuffID.Builder:
                    player.tileSpeed += 0.25f;
                    player.wallSpeed += 0.25f;
                    player.blockRange += 2;
                    break;
                case BuffID.ManaRegeneration:
                    modPlayer.manaRegeneration = true;
                    break;
                case BuffID.ObsidianSkin:
                    player.buffImmune[BuffID.CursedInferno] = true;
                    player.buffImmune[BuffID.Ichor] = true;
                    break;
                case BuffID.Summoning:
                    player.maxTurrets++;
                    player.GetDamage(DamageClass.Summon) += 0.1f;
                    break;
            }
        }
    }
}