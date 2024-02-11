using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterPotions.Content.Potions.DiscoInferno;

public class DiscoInfernoBuff : ModBuff
{
    public override void Update(Player player, ref int buffIndex) {
        player.GetModPlayer<DiscoInfernoPlayer>().DiscoInferno = true;
    }
}

public class DiscoInfernoPlayer : ModPlayer
{
    private const string DiscoInfernoRingPath = "BetterPotions/Content/Potions/DiscoInferno/DiscoInfernoRing";

    private float discoInfernoRingRot;
    private float discoInfernoRingScale = 1f;

    public bool DiscoInferno { get; set; }

    public override void ResetEffects() {
        DiscoInferno = false;
    }

    public override void PostUpdateBuffs() {
        if (!DiscoInferno) {
            return;
        }

        Lighting.AddLight(Player.Center, TorchID.Hallowed);
        float range = 200f;
        int damage = 25;
        for (int i = 0; i < 200; i++) {
            NPC npc = Main.npc[i];
            if (npc.active && !npc.friendly && npc.damage > 0 && !npc.dontTakeDamage && !npc.buffImmune[BuffID.CursedInferno] && Player.CanNPCBeHitByPlayerOrPlayerProjectile(npc) &&
                Vector2.Distance(Player.Center, npc.Center) < range) {
                if (npc.FindBuffIndex(ModContent.BuffType<DazzlingFlamesBuff>()) == -1) {
                    npc.AddBuff(ModContent.BuffType<DazzlingFlamesBuff>(), 120);
                }

                if (Player.infernoCounter % 60 == 0) {
                    Player.ApplyDamageToNPC(npc, damage, 0f, 0);
                }
            }
        }

        if (!Player.hostile) {
            return;
        }

        for (int i = 0; i < 255; i++) {
            Player pl = Main.player[i];
            if (pl == Player || !pl.active || pl.dead || !pl.hostile || pl.buffImmune[BuffID.CursedInferno] || (pl.team == Player.team && pl.team != 0) ||
                !(Vector2.Distance(Player.Center, pl.Center) < range)) {
                continue;
            }

            if (pl.FindBuffIndex(ModContent.BuffType<DazzlingFlamesBuff>()) == -1) {
                pl.AddBuff(ModContent.BuffType<DazzlingFlamesBuff>(), 120);
            }

            if (Player.infernoCounter % 60 == 0) {
                pl.Hurt(PlayerDeathReason.LegacyEmpty(), damage, 0, true);
                if (Main.netMode != NetmodeID.SinglePlayer) {
                    Player.HurtInfo hurtInfo = new() {
                        Damage = damage,
                        DamageSource = PlayerDeathReason.ByOther(16),
                        PvP = true,
                        Knockback = 0
                    };
                    NetMessage.SendPlayerHurt(i, hurtInfo);
                }
            }
        }
    }

    public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright) {
        if (!DiscoInferno) {
            return;
        }

        // Draw the flame ring - this is all code from vanilla and i cba renaming variables and optimising lmao
        Asset<Texture2D> discoRingTexture = ModContent.Request<Texture2D>(DiscoInfernoRingPath);

        float num = 1f;
        float num2 = 0.1f;
        float num3 = 0.9f;
        if (!Main.gamePaused) {
            discoInfernoRingScale += 0.004f;
            discoInfernoRingRot += 0.05f;
        }

        if (discoInfernoRingScale < 1f) {
            num = discoInfernoRingScale;
        } else {
            discoInfernoRingScale = 0.8f;
            num = discoInfernoRingScale;
        }

        if (discoInfernoRingRot > (float)Math.PI * 2f) {
            discoInfernoRingRot -= (float)Math.PI * 2f;
        }

        if (discoInfernoRingRot < (float)Math.PI * 2f) {
            discoInfernoRingRot += (float)Math.PI * 2f;
        }

        for (int i = 0; i < 4; i++) {
            float num4 = num + num2 * i;
            if (num4 > 1f) {
                num4 -= num2 * 2f;
            }

            float num5 = MathHelper.Lerp(0.8f, 0f, Math.Abs(num4 - num3) * 10f);
            Main.spriteBatch.Draw(discoRingTexture.Value, Player.Center - Main.screenPosition, new Rectangle(0, 400 * i, 400, 400), new Color(num5, num5, num5, num5 / 2f),
                discoInfernoRingRot + (float)Math.PI / 3f * i, new Vector2(200f, 200f), num4, SpriteEffects.None, 0f);
        }
    }
}
