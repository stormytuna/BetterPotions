using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterPotions.Content.Buffs
{
    public class Instigating : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Instigating");
            Description.SetDefault("Enemies are more likely to target you");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.aggro += 200;
        }
    }
}