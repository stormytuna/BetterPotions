using Terraria;
using Terraria.ModLoader;

namespace BetterPotions.Content.Potions.Steelfall;

public class SteelfallBuff : ModBuff
{
    public override void Update(Player player, ref int buffIndex) {
        player.GetModPlayer<SteelfallPlayer>().Steelfall = true;
    }
}

public class SteelfallPlayer : ModPlayer
{
    public bool Steelfall { get; set; }

    public override void ResetEffects() {
        Steelfall = false;
    }

    public override void PostUpdateBuffs() {
        if (!Steelfall) {
            return;
        }

        Player.maxFallSpeed *= Player.controlDown ? 2f : 1.5f;
    }
}
