using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterPotions.Content.Buffs
{
    public class Instigate : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Instigate");
            Description.SetDefault("Enemies are more likely to target you");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.aggro += 200;
        }
    }
}