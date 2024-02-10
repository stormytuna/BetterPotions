using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterPotions.Content.Potions.Orichalcumskin
{
    public class OrichalcumskinBuff : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 14;
        }
    }
}
