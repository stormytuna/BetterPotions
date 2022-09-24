using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using BetterPotions.Content.Projectiles;
using BetterPotions.Content.Buffs;
using BetterPotions.Content.Items;
using BetterPotions.Common.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using ReLogic.Content;

namespace BetterPotions.Common
{
    public class FlightPlayerDrawLayer : PlayerDrawLayer
    {
        private Asset<Texture2D> wingsTexture;

        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
            => drawInfo.drawPlayer.GetModPlayer<BetterPotionsPlayer>().flight;
            
        public override Position GetDefaultPosition()
            => new BeforeParent(PlayerDrawLayers.Wings);

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            if (wingsTexture == null)
                wingsTexture = ModContent.Request<Texture2D>("BetterPotions/Content/Buffs/FlightPotionWings");

            Player drawPlayer = drawInfo.drawPlayer;

            Vector2 position = drawInfo.Center + (new Vector2(-9f, 0f) * drawPlayer.direction) + new Vector2(0f, 2f) - Main.screenPosition;
            position = new Vector2((int)position.X, (int)position.Y);

            SpriteEffects effects = SpriteEffects.None;
            if (drawPlayer.direction == -1)
                effects = SpriteEffects.FlipHorizontally;

            // Queue drawing of sprite
            drawInfo.DrawDataCache.Add(new DrawData(
                wingsTexture.Value,
                position,
                new Rectangle(0, 62 * drawPlayer.wingFrame, 86, 62),
                new Color(80, 80, 80, 0),
                0f,
                new Vector2(43, 31),
                1f,
                effects,
                0
                ));
        }
    }
}