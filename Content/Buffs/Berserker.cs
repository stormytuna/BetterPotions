using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterPotions.Content.Buffs
{
    public class Berserker : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Berserker");
            Description.SetDefault("10% increased melee damage and speed");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Melee) += 0.1f;
            player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
        }
    }
}