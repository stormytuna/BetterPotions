using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BetterPotions.Common.Players;

namespace BetterPotions.Content.Potions.DiscoInferno
{
    public class DiscoInfernoBuff : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<BetterPotionsPlayer>().discoInferno = true;
        }
    }
}
