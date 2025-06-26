using BetterPotions.Common.Configs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace BetterPotions.Common.GlobalItems;

public class TenMinutePotionsGlobalItem : GlobalItem
{
    public override bool IsLoadingEnabled(Mod mod) => BetterPotionsConfig.Instance.PotionsLastTenMinutes;

    public override bool AppliesToEntity(Item entity, bool lateInstantiation) {
        if (!ItemID.Search.TryGetName(entity.type, out string itemName)) {
            return false;
        }

        bool notInBlacklist = !BetterPotionsConfig.Instance.TenMinutePotionsBlacklist.Contains(new ItemDefinition(itemName));
        bool buffCanBeTenMinutes = BuffShouldBeTenMinutes(entity.buffType);
        bool buffIsLessThanTenMinutes = entity.buffTime < 10 * 60 * 60;
        return lateInstantiation && notInBlacklist && buffCanBeTenMinutes && buffIsLessThanTenMinutes;
    }

    public override void SetDefaults(Item entity) {
        entity.buffTime = 10 * 60 * 60;
    }

    private bool BuffShouldBeTenMinutes(int buffType) {
        if (buffType < 0) {
            return false;
        }

        return !Main.debuff[buffType] && !Main.vanityPet[buffType] && !Main.lightPet[buffType] && !Main.buffNoTimeDisplay[buffType];
    }
}
