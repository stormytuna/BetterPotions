using System.Collections.Generic;
using BetterPotions.Content.Potions.DiscoInferno;
using BetterPotions.Content.Potions.HeightenedSenses;
using BetterPotions.Content.Potions.Orichalcumskin;
using BetterPotions.Content.Potions.War;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterPotions.Common.Players;

public class MutuallyExclusiveBuffsPlayer : ModPlayer
{
    private static readonly Dictionary<int, int[]> mutuallyExclusiveBuffMap = new();

    public override void SetStaticDefaults() {
        mutuallyExclusiveBuffMap.Add(ModContent.BuffType<WarBuff>(), [BuffID.Battle]);
        mutuallyExclusiveBuffMap.Add(ModContent.BuffType<DiscoInfernoBuff>(), [BuffID.Inferno]);
        mutuallyExclusiveBuffMap.Add(ModContent.BuffType<OrichalcumskinBuff>(), [BuffID.Ironskin]);
        mutuallyExclusiveBuffMap.Add(ModContent.BuffType<HeightenedSensesBuff>(), [BuffID.NightOwl, BuffID.Dangersense, BuffID.Hunter]);
    }

    public override void PreUpdateBuffs() {
        foreach ((int buffToKeep, int[] mutuallyExclusiveBuffs) in mutuallyExclusiveBuffMap) {
            if (Player.HasBuff(buffToKeep)) {
                foreach (int mutuallyExclusiveBuff in mutuallyExclusiveBuffs) {
                    Player.ClearBuff(mutuallyExclusiveBuff);
                }
            }
        }
    }

    public override bool CanUseItem(Item item) {
        foreach ((int buffToKeep, int[] mutuallyExclusiveBuffs) in mutuallyExclusiveBuffMap) {
            if (!Player.HasBuff(buffToKeep)) {
                continue;
            }

            foreach (int mutuallyExclusiveBuff in mutuallyExclusiveBuffs) {
                if (item.buffType == mutuallyExclusiveBuff) {
                    return false;
                }
            }
        }

        return base.CanUseItem(item);
    }
}
