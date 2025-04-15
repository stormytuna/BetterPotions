using System.Collections.Generic;
using System.Linq;
using BetterPotions.Common.Configs;
using BetterPotions.Content.Potions.Predator;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace BetterPotions.Common.VanillaChanges;

public class Archery : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod) => BetterPotionsConfig.Instance.PotionChanges_Archery;

    public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.type == ItemID.ArcheryPotion;

    public override void SetDefaults(Item entity) {
        entity.SetNameOverride(Language.GetTextValue("Mods.BetterPotions.VanillaChanges.ArcheryRename"));
        entity.buffType = ModContent.BuffType<PredatorBuff>();
    }

    public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
        TooltipLine line = tooltips.FirstOrDefault(tip => tip.Name == "Tooltip0");
        if (line is null) {
            return;
        }

        line.Text = Language.GetTextValue("Mods.BetterPotions.VanillaChanges.ArcheryPotion");
    }
}
