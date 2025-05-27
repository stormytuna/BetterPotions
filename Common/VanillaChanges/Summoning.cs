using System.Collections.Generic;
using System.Linq;
using BetterPotions.Common.Configs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace BetterPotions.Common.VanillaChanges;

public class SummoningGlobalBuff : GlobalBuff
{
    public override bool IsLoadingEnabled(Mod mod) => BetterPotionsConfig.Instance.PotionChanges_Summoning;

    public override void Update(int type, Player player, ref int buffIndex) {
        if (type != BuffID.Summoning) {
            return;
        }

        player.maxTurrets++;
        player.GetDamage(DamageClass.Summon) += 0.1f;
    }

    public override void ModifyBuffText(int type, ref string buffName, ref string tip, ref int rare) {
        if (type != BuffID.Summoning) {
            return;
        }

        tip = Language.GetTextValue("Mods.BetterPotions.VanillaChanges.BuffSummoning");
    }
}

public class SummoningGlobalItem : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod) => BetterPotionsConfig.Instance.PotionChanges_Summoning;

    public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.type == ItemID.SummoningPotion;

    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
        TooltipLine line = tooltips.FirstOrDefault(tip => tip.Name == "Tooltip0");
        if (line is null) {
            return;
        }

        line.Text = Language.GetTextValue("Mods.BetterPotions.VanillaChanges.SummoningPotion");
    }
}
