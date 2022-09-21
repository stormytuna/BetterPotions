using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterPotions.Content.Buffs
{
    public class Predator : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Predator");
            Description.SetDefault("10% increased ranged damage and critical chance");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetCritChance(DamageClass.Ranged) += 10f;
            player.GetDamage(DamageClass.Ranged) += 0.1f;
        }
    }
}