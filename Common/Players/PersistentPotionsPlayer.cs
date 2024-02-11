using System;
using BetterPotions.Common.Configs;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace BetterPotions.Common.Players;

public class PersistentPotionsPlayer : ModPlayer
{
    private readonly int[] buffs = new int[Player.MaxBuffs];
    private readonly int[] buffTimes = new int[Player.MaxBuffs];

    public override bool IsLoadingEnabled(Mod mod) => BetterPotionsConfig.Instance.PersistentBuffs;

    public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource) {
        for (int i = 0; i < Player.buffType.Length; i++) {
            if (Main.debuff[Player.buffType[i]]) {
                continue;
            }

            buffs[i] = Player.buffType[i];
            buffTimes[i] = Player.buffTime[i];
        }
    }

    public override void OnRespawn() {
        for (int i = 0; i < Player.buffType.Length; i++) {
            if (buffs[i] >= 0) {
                Player.AddBuff(buffs[i], Convert.ToInt32((1f - BetterPotionsConfig.Instance.PersistentBuffsPenalty) * buffTimes[i]));
            }
        }
    }
}
