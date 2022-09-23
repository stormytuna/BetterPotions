using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterPotions.Content.Buffs
{
    public class Immovable : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Immovable");
            Description.SetDefault("Immune to knockback");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.noKnockback = true;
        }
    }
}