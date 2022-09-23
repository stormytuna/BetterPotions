using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BetterPotions.Common.Players;
using BetterPotions.Common.NPCs;

namespace BetterPotions.Content.Buffs
{
    public class DazzlingFlames : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("DazzlingFlames");
            Description.SetDefault("You are engulfed in dazzling flames!");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<BetterPotionsPlayer>().dazzlingFlames = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<BetterPotionsGlobalNPC>().dazzlingFlames = true;
        }
    }
}