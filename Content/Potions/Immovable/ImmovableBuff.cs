using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterPotions.Content.Potions.Immovable
{
    public class ImmovableBuff : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.noKnockback = true;
        }
    }
}
