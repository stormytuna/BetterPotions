using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BetterPotions.Content.Items;
using BetterPotions.Common.Players;

namespace BetterPotions.Content.Buffs
{
    public class Flight : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flight");
            Description.SetDefault("Fly with ethereal wings");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            for (int i = 0; i < player.armor.Length; i++)
            {
                if (player.armor[i].wingSlot > 0)
                    return;
            }

            Item wingItem = new Item(ModContent.ItemType<FlightPotionWings>());
            player.wingsLogic = wingItem.wingSlot;
            player.wingTimeMax = 50;
            player.noFallDmg = true;
            player.GetModPlayer<BetterPotionsPlayer>().flight = true;
        }
    }
}