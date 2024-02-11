using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterPotions.Content.Potions.Flight;

public class FlightBuff : ModBuff
{
    public override void Update(Player player, ref int buffIndex) {
        for (int i = 0; i < player.armor.Length; i++) {
            if (player.armor[i].wingSlot > 0) {
                return;
            }
        }

        Item wingItem = new(ModContent.ItemType<FlightPotionWings>());
        player.wingsLogic = wingItem.wingSlot;
        player.wingTimeMax = 50;
        player.noFallDmg = true;
        player.GetModPlayer<FlightBuffPlayer>().Flight = true;
    }
}

public class FlightBuffPlayer : ModPlayer
{
    public bool Flight { get; set; }

    public override void ResetEffects() {
        Flight = false;
    }

    public override void PostUpdateBuffs() {
        if (!Flight || !Main.rand.NextBool(5) || ((!(Player.wingTime > 0) || !Player.controlJump) && (!(Player.velocity.Y > 0) || !Player.controlJump))) {
            return;
        }

        Vector2 dustCenter = Player.Center + new Vector2(Player.direction * -9f, 2f);
        Vector2 dustBoxSize = new(35f, 35f);
        Vector2 dustSpeed = new(Main.rand.NextFloat(-0.5f, 0.5f), Main.rand.NextFloat(-0.5f, 0.5f));
        int d = Dust.NewDust(dustCenter - dustBoxSize / 2, (int)dustBoxSize.X, (int)dustBoxSize.Y, DustID.Clentaminator_Cyan, dustSpeed.X, dustSpeed.Y, 0, default, 0.7f);
    }
}
