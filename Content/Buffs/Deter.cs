using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterPotions.Content.Buffs
{
    public class Deter : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Deter");
            Description.SetDefault("Enemies are less likely to target you");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.aggro -= 200;
        }
    }
}