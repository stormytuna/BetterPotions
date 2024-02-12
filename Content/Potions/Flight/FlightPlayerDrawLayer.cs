using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace BetterPotions.Content.Potions.Flight;

public class FlightPlayerDrawLayer : PlayerDrawLayer
{
    private Asset<Texture2D> wingsTexture;

    public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
        => drawInfo.drawPlayer.GetModPlayer<FlightBuffPlayer>().Flight;

    public override Position GetDefaultPosition()
        => new BeforeParent(PlayerDrawLayers.Wings);

    protected override void Draw(ref PlayerDrawSet drawInfo) {
        if (wingsTexture == null) {
            wingsTexture = ModContent.Request<Texture2D>("BetterPotions/Content/Potions/Flight/FlightPotionOnPlayerWings");
        }

        Player drawPlayer = drawInfo.drawPlayer;

        Vector2 position = drawInfo.Center + new Vector2(-9f, 0f) * drawPlayer.direction + new Vector2(0f, 2f) - Main.screenPosition;
        position = new Vector2((int)position.X, (int)position.Y);

        SpriteEffects effects = SpriteEffects.None;
        if (drawPlayer.direction == -1) {
            effects = SpriteEffects.FlipHorizontally;
        }

        // Queue drawing of sprite
        drawInfo.DrawDataCache.Add(new DrawData(
            wingsTexture.Value,
            position,
            new Rectangle(0, 62 * drawPlayer.wingFrame, 86, 62),
            new Color(80, 80, 80, 0),
            0f,
            new Vector2(43, 31),
            1f,
            effects
        ));
    }
}
