using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using BetterPotions.Content.Projectiles;
using BetterPotions.Content.Buffs;
using BetterPotions.Content.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using ReLogic.Content;

namespace BetterPotions.Common.Players
{
    public class BetterPotionsPlayer : ModPlayer
    {
        private const string DiscoInfernoRingPath = "BetterPotions/Content/Buffs/DiscoInfernoRing";

        public bool ammoReservation;
        public bool manaRegeneration;

        public bool architect;
        public bool war;
        public bool discoInferno;
        public bool dazzlingFlames;
        public bool steelfall;
        public bool flight;

        public override void ResetEffects()
        {
            ammoReservation = false;
            manaRegeneration = false;

            architect = false;
            war = false;
            discoInferno = false;
            dazzlingFlames = false;
            steelfall = false;
            flight = false;
        }

        public override bool CanConsumeAmmo(Item weapon, Item ammo)
        {
            if (ammoReservation && Main.rand.NextFloat() < 0.3f)
                return false;

            return base.CanConsumeAmmo(weapon, ammo);
        }

        int manaRegenerationCounter = 0;
        float discoInfernoRingScale = 1f;
        float discoInfernoRingRot;

        public override void PostUpdateBuffs()
        {
            if (discoInferno)
            {
                // Do the actual effect
                Lighting.AddLight(Player.Center, TorchID.Hallowed);
                float range = 200f;
                int damage = 25;
                for (int i = 0; i < 200; i++)
                {
                    NPC npc = Main.npc[i];
                    if (npc.active && !npc.friendly && npc.damage > 0 && !npc.dontTakeDamage && !npc.buffImmune[BuffID.CursedInferno] && Player.CanNPCBeHitByPlayerOrPlayerProjectile(npc) && Vector2.Distance(Player.Center, npc.Center) < range)
                    {
                        if (npc.FindBuffIndex(ModContent.BuffType<DazzlingFlames>()) == -1)
                            npc.AddBuff(ModContent.BuffType<DazzlingFlames>(), 120);

                        if (Player.infernoCounter % 60 == 0)
                            Player.ApplyDamageToNPC(npc, damage, 0f, 0, crit: false);

                    }
                }

                if (!Player.hostile)
                    return;

                for (int i = 0; i < 255; i++)
                {
                    Player pl = Main.player[i];
                    if (pl == Player || !pl.active || pl.dead || !pl.hostile || pl.buffImmune[BuffID.CursedInferno] || (pl.team == Player.team && pl.team != 0) || !(Vector2.Distance(Player.Center, pl.Center) < range))
                    {
                        continue;
                    }

                    if (pl.FindBuffIndex(ModContent.BuffType<DazzlingFlames>()) == -1)
                        pl.AddBuff(ModContent.BuffType<DazzlingFlames>(), 120);

                    if (Player.infernoCounter % 60 == 0)
                    {
                        pl.Hurt(PlayerDeathReason.LegacyEmpty(), damage, 0, pvp: true);
                        if (Main.netMode != NetmodeID.SinglePlayer)
                        {
                            PlayerDeathReason reason = PlayerDeathReason.ByOther(16);
                            NetMessage.SendPlayerHurt(i, reason, damage, 0, critical: false, pvp: true, -1);
                        }
                    }
                }
            }

            if (manaRegeneration)
            {
                manaRegenerationCounter++;
                if (manaRegenerationCounter > 15 && Player.statMana < Player.statManaMax2)
                {
                    Player.statMana++;
                    manaRegenerationCounter = 0;
                }
            }

            if (steelfall)
            {
                if (Player.controlDown)
                    Player.maxFallSpeed *= 2f;
                else
                    Player.maxFallSpeed *= 1.5f;
            }

            if (flight)
            {
                // Dust
                if(Main.rand.NextBool(5) && (Player.wingTime > 0 && Player.controlJump || Player.velocity.Y > 0 && Player.controlJump))
                {
                    Vector2 dustCenter = Player.Center + new Vector2(Player.direction * -9f, 2f);
                    Vector2 dustBoxSize = new Vector2(35f, 35f);
                    Vector2 dustSpeed = new Vector2(Main.rand.NextFloat(-0.5f, 0.5f), Main.rand.NextFloat(-0.5f, 0.5f));
                    int d = Dust.NewDust(dustCenter - dustBoxSize / 2, (int)dustBoxSize.X, (int)dustBoxSize.Y, DustID.Clentaminator_Cyan, dustSpeed.X, dustSpeed.Y, 0, default, 0.7f);
                }
            }
        }

        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (discoInferno)
            {
                // Draw the flame ring - this is all code from vanilla and i cba renaming variables and optimising lmao
                Asset<Texture2D> discoRingTexture = ModContent.Request<Texture2D>(DiscoInfernoRingPath);

                float num = 1f;
                float num2 = 0.1f;
                float num3 = 0.9f;
                if (!Main.gamePaused)
                {
                    discoInfernoRingScale += 0.004f;
                    discoInfernoRingRot += 0.05f;
                }

                if (discoInfernoRingScale < 1f)
                {
                    num = discoInfernoRingScale;
                }
                else
                {
                    discoInfernoRingScale = 0.8f;
                    num = discoInfernoRingScale;
                }

                if (discoInfernoRingRot > (float)Math.PI * 2f)
                {
                    discoInfernoRingRot -= (float)Math.PI * 2f;
                }
                if (discoInfernoRingRot < (float)Math.PI * 2f)
                {
                    discoInfernoRingRot += (float)Math.PI * 2f;
                }

                for (int i = 0; i < 4; i++)
                {
                    float num4 = num + num2 * (float)i;
                    if (num4 > 1f)
                    {
                        num4 -= num2 * 2f;
                    }
                    float num5 = MathHelper.Lerp(0.8f, 0f, Math.Abs(num4 - num3) * 10f);
                    Main.spriteBatch.Draw(discoRingTexture.Value, Player.Center - Main.screenPosition, new Rectangle(0, 400 * i, 400, 400), new Color(num5, num5, num5, num5 / 2f), discoInfernoRingRot + (float)Math.PI / 3f * (float)i, new Vector2(200f, 200f), num4, SpriteEffects.None, 0f);
                }
            }
        }

        public override void PreUpdateBuffs()
        {
            if (Player.HasBuff(ModContent.BuffType<War>()) && Player.HasBuff(BuffID.Battle))
            {
                Player.ClearBuff(BuffID.Battle);
            }

            if (Player.HasBuff(ModContent.BuffType<DiscoInferno>()) && Player.HasBuff(BuffID.Inferno))
            {
                Player.ClearBuff(BuffID.Inferno);
            }

            if (Player.HasBuff(ModContent.BuffType<Orichalcumskin>()) && Player.HasBuff(BuffID.Ironskin))
            {
                Player.ClearBuff(BuffID.Ironskin);
            }

            if (Player.HasBuff(ModContent.BuffType<Orichalcumskin>()) && Player.HasBuff(BuffID.NightOwl))
            {
                Player.ClearBuff(BuffID.NightOwl);
            }

            if (Player.HasBuff(ModContent.BuffType<Orichalcumskin>()) && Player.HasBuff(BuffID.Dangersense))
            {
                Player.ClearBuff(BuffID.Dangersense);
            }

            if (Player.HasBuff(ModContent.BuffType<Orichalcumskin>()) && Player.HasBuff(BuffID.Hunter))
            {
                Player.ClearBuff(BuffID.Hunter);
            }
        }

        public override void UpdateBadLifeRegen()
        {
            if (dazzlingFlames)
            {
                // Dust
                Dust d = Dust.NewDustDirect(new Vector2(Player.position.X - 2f, Player.position.Y - 2f), Player.width + 4, Player.height + 4, DustID.HallowedTorch, Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 180, default(Color), 1.95f);
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
                Player.lifeRegen = 0;
                Player.lifeRegenTime = 0;
                Player.lifeRegen -= 12;
            }
        }


        private int[] buffs = new int[Player.MaxBuffs];
        private int[] buffTimes = new int[Player.MaxBuffs];
        private float timeMultiplier = 0.75f;


        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            // Keep buffs on death
            for (int i = 0; i < Player.buffType.Length; i++)
            {
                if (!Main.debuff[Player.buffType[i]])
                {
                    buffs[i] = Player.buffType[i];
                    buffTimes[i] = Player.buffTime[i];
                }
            }

            // Grave potion marker
            foreach (Projectile p in Main.projectile)
            {
                if (p.type == ModContent.ProjectileType<GravePotionMarker>() && p.owner == Player.whoAmI)
                    p.Kill();
            }
            int proj = Projectile.NewProjectile(Player.GetSource_Misc("-1"), Player.position, Vector2.Zero, ModContent.ProjectileType<GravePotionMarker>(), 0, 0f, Player.whoAmI);
            Main.projectile[proj].Center = Player.Center;
        }

        public override void OnRespawn(Player player)
        {
            for (int i = 0; i < Player.buffType.Length; i++)
            {
                if (buffs[i] >= 0)
                    Player.AddBuff(buffs[i], Convert.ToInt32(timeMultiplier * (float)buffTimes[i]));
            }
        }
    }
}