using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BetterPotions.Common.Players;

namespace BetterPotions.Content.Buffs
{
    public class Steelfall : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steelfall");
            Description.SetDefault("Falling speed is increased\nPress DOWN to fall faster");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<BetterPotionsPlayer>().steelfall = true;
        }
    }
}