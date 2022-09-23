using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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

            player.wings = 34;
            player.wingsLogic = 2;
            player.wingTimeMax = 50;
        }
    }
}