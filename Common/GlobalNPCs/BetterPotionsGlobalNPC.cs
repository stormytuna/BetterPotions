using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BetterPotions.Common.Players;
using Microsoft.Xna.Framework;

namespace BetterPotions.Common.NPCs
{
    public class BetterPotionsGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity 
            => true;

        public bool dazzlingFlames;

        public override void ResetEffects(NPC npc)
        {
            dazzlingFlames = false;
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (dazzlingFlames)
            {
                // Dust
                Dust d = Dust.NewDustDirect(new Vector2(npc.position.X - 2f, npc.position.Y - 2f), npc.width + 4, npc.height + 4, DustID.HallowedTorch, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 180, default(Color), 1.95f);
                d.noGravity = true;
                d.velocity *= 0.75f;
                d.velocity.X *= 0.75f;
                d.velocity.Y -= 1f;
                if (Main.rand.NextBool(4))
                {
                    d.noGravity = false;
                    d.scale *= 0.5f;
                }

                // Actual effect
                npc.lifeRegen = 0;
                npc.lifeRegen -= 24;
            }
        }
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (player.GetModPlayer<BetterPotionsPlayer>().war)
            {
                spawnRate = (int)((float)spawnRate * 0.2f);
                maxSpawns *= 5;
            }
        }
    }
}