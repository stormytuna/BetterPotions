using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterPotions.Content.Buffs
{
    public class Orichalcumskin : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orichalcumskin");
            Description.SetDefault("Increased defense by 14");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 14;
        }
    }
}