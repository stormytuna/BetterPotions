using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterPotions.Content.Potions.HeightenedSenses
{
    public class HeightenedSensesBuff : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.nightVision = true;
            player.detectCreature = true;
            player.dangerSense = true;
        }
    }
}
