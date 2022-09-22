using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BetterPotions.Common.Players;

namespace BetterPotions.Content.Buffs
{
    public class War : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("War");
            Description.SetDefault("400% increased enemy spawn rate and spawn cap");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<BetterPotionsPlayer>().war = true;
        }
    }
}