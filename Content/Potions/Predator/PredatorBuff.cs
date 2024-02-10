using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterPotions.Content.Potions.Predator
{
    public class PredatorBuff : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetCritChance(DamageClass.Ranged) += 10f;
            player.GetDamage(DamageClass.Ranged) += 0.1f;
        }
    }
}
