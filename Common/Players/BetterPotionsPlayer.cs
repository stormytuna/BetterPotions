using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterPotions.Common.Players
{
    public class BetterPotionsPlayer : ModPlayer
    {
        public bool ammoReservation;

        public override void ResetEffects()
        {
            ammoReservation = false;
        }

        public override bool CanConsumeAmmo(Item weapon, Item ammo)
        {
            if (ammoReservation && Main.rand.NextFloat() < 0.3f)
                return false;

            return base.CanConsumeAmmo(weapon, ammo);
        }

        private int[] buffs = new int[Player.MaxBuffs];
        private int[] buffTimes = new int[Player.MaxBuffs];
        private float timeMultiplier = 0.75f;


        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            for (int i = 0; i < Player.buffType.Length; i++)
            {
                if (!Main.debuff[Player.buffType[i]])
                {
                    buffs[i] = Player.buffType[i];
                    buffTimes[i] = Player.buffTime[i];
                }
            }
        }

        public override void OnRespawn(Player player)
        {
            for (int i = 0; i < Player.buffType.Length; i++)
            {
                if (buffs[i] >= 0)
                    Player.AddBuff(buffs[i], Convert.ToInt32(timeMultiplier * (float)buffTimes[i]));
            }
        }
    }
}