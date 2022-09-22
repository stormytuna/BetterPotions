using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BetterPotions.Common.Players;

namespace BetterPotions.Common.NPCs
{
    public class BetterPotionsGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity 
            => true;

        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (player.GetModPlayer<BetterPotionsPlayer>().war)
            {
                spawnRate = (int)((float)spawnRate * 0.2f);
                maxSpawns *= 5;
            }
        }
    }
}