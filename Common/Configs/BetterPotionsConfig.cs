using System;
using System.Collections.Generic;
using Terraria.ModLoader.Config;
using System.ComponentModel;

namespace BetterPotions.Common.Configs
{
    public class BetterPotionsConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;


        [Header("QualityOfLife")]

        [DefaultValue(true)]
        [ReloadRequired]
        public bool PersistentBuffs { get; set; }

        [DefaultValue(0.25f)]
        [Range(0f, 1f)]
        [ReloadRequired]
        public float PersistentBuffsPenalty { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsLastTenMinutes { get; set; }

        [ReloadRequired]
        public List<ItemDefinition> TenMinutePotionsBlacklist { get; set; } = new List<ItemDefinition>();

        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsAndBuffsImprovedTooltips { get; set; }

        [Header("VanillaPotionChanges")]

        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionChanges_AmmoReservation { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionChanges_Archery { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionChanges_Builder { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionChanges_ManaRegen { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionChanges_ObsidianSkin { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionChanges_Summoning { get; set; }

        [Header("ModdedPotions")]

        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsAdded_Grave { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsAdded_War { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsAdded_Instigating { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsAdded_Deterring { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsAdded_DiscoInferno { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsAdded_Orichalcumskin { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsAdded_Berserker { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsAdded_Piercing { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsAdded_Leaping { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsAdded_Steelfall { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsAdded_HeightenedSenses { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsAdded_Immovable { get; set; }

        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsAdded_Flight { get; set; }
    }
}
