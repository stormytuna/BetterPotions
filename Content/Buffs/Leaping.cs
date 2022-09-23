using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BetterPotions.Common.Players;

namespace BetterPotions.Content.Buffs
{
    public class Leaping : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Leaping");
            Description.SetDefault("50% increased jump speed and auto-jump enabled");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.jumpSpeedBoost += 2.5f;
            player.autoJump = true;
        }
    }
}