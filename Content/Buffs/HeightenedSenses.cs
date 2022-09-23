using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterPotions.Content.Buffs
{
    public class HeightenedSenses : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("HeightenedSenses");
            Description.SetDefault("See nearby sources of danger, see better in the dark and see the location of enemies");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.nightVision = true;
            player.detectCreature = true;
            player.dangerSense = true;
        }
    }
}