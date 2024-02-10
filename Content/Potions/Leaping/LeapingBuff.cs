using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BetterPotions.Common.Players;

namespace BetterPotions.Content.Potions.Leaping
{
    public class LeapingBuff : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.jumpSpeedBoost += 2.5f;
            player.autoJump = true;
        }
    }
}
