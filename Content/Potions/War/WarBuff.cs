using Terraria;
using Terraria.ModLoader;

namespace BetterPotions.Content.Potions.War;

public class WarBuff : ModBuff
{
    public override void Update(Player player, ref int buffIndex) {
        player.GetModPlayer<WarPlayer>().War = true;
    }
}

public class WarGlobalNPC : GlobalNPC
{
    public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns) {
        if (player.GetModPlayer<WarPlayer>().War) {
            spawnRate = (int)(spawnRate * 0.2f);
            maxSpawns *= 5;
        }
    }
}

public class WarPlayer : ModPlayer
{
    public bool War { get; set; }

    public override void ResetEffects() {
        War = false;
    }
}
