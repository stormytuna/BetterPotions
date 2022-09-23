using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BetterPotions.Common.Players;

namespace BetterPotions.Content.Buffs
{
    public class DiscoInferno : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("DiscoInferno");
            Description.SetDefault("Nearby enemies are engulfed in dazzling flames");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<BetterPotionsPlayer>().discoInferno = true;
        }
    }
}