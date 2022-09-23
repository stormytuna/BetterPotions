using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BetterPotions.Common.Players;

namespace BetterPotions.Content.Buffs
{
    public class Piercing : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Piercing");
            Description.SetDefault("Increased armor penetration by 10");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetArmorPenetration(DamageClass.Generic) += 10;
        }
    }
}