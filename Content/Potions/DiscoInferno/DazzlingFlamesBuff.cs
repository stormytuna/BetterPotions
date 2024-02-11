using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterPotions.Content.Potions.DiscoInferno;

public class DazzlingFlamesBuff : ModBuff
{
    public override void Update(Player player, ref int buffIndex) {
        player.GetModPlayer<DazzlingFlamesPlayer>().DazzlingFlames = true;
    }

    public override void Update(NPC npc, ref int buffIndex) {
        npc.GetGlobalNPC<DazzlingFlamesGlobalNPC>().DazzlingFlames = true;
    }
}

public class DazzlingFlamesGlobalNPC : GlobalNPC
{
    public override bool InstancePerEntity => true;

    public bool DazzlingFlames { get; set; }

    public override void ResetEffects(NPC npc) {
        DazzlingFlames = false;
    }

    public override void UpdateLifeRegen(NPC npc, ref int damage) {
        if (!DazzlingFlames) {
            return;
        }

        npc.lifeRegen = 0;
        npc.lifeRegen -= 24;

        Dust d = Dust.NewDustDirect(new Vector2(npc.position.X - 2f, npc.position.Y - 2f), npc.width + 4, npc.height + 4, DustID.HallowedTorch, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 180,
            default, 1.95f);
        d.noGravity = true;
        d.velocity *= 0.75f;
        d.velocity.X *= 0.75f;
        d.velocity.Y -= 1f;
        if (Main.rand.NextBool(4)) {
            d.noGravity = false;
            d.scale *= 0.5f;
        }
    }
}

public class DazzlingFlamesPlayer : ModPlayer
{
    public bool DazzlingFlames { get; set; }

    public override void ResetEffects() {
        DazzlingFlames = false;
    }

    public override void UpdateBadLifeRegen() {
        if (!DazzlingFlames) {
            return;
        }

        Player.lifeRegen = 0;
        Player.lifeRegenTime = 0;
        Player.lifeRegen -= 12;

        Dust d = Dust.NewDustDirect(new Vector2(Player.position.X - 2f, Player.position.Y - 2f), Player.width + 4, Player.height + 4, DustID.HallowedTorch, Player.velocity.X * 0.4f,
            Player.velocity.Y * 0.4f, 180, default, 1.95f);
        d.noGravity = true;
        d.velocity *= 0.75f;
        d.velocity.X *= 0.75f;
        d.velocity.Y -= 1f;
        if (Main.rand.NextBool(4)) {
            d.noGravity = false;
            d.scale *= 0.5f;
        }
    }
}
