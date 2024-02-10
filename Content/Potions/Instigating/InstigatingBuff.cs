using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterPotions.Content.Potions.Instigating
{
    public class InstigatingBuff : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.aggro += 200;
        }
    }
}
