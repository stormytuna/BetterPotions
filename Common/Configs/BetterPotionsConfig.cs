using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

using BetterPotions.Common.Players;
using BetterPotions.Content.Items;
using Terraria.ModLoader.Config;
using System.ComponentModel;

namespace BetterPotions.Common.Configs
{
    public class BetterPotionsConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;


        [Header("Quality of Life Changes")]

        [Label("[i:1353] Buffs are persistent")]
        [Tooltip("When you die, your buffs will be reapplied on respawn")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool PersistentBuffs { get; set; }

        [Label("[i:216] Persistent buffs penalty")]
        [Tooltip("How much of the remaining time on each buff is lost. 0 is 0% penalty, 1 is 100% penalty")]
        [DefaultValue(0.25f)]
        [Range(0f, 1f)]
        [ReloadRequired]
        public float PersistentBuffsPenalty { get; set; }

        [Label("[i:17] Potions last 10 minutes")]
        [Tooltip("Changes most potions. Potions that last over 10 minutes and potions that rely on duration time for their effect are unchanged")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsLastTenMinutes { get; set; }

        [Label("[i:4084] 10 minute potions blacklist")]
        [Tooltip("Adding a potion to this blacklist will prevent its time being changed to 10 minutes")]
        [ReloadRequired]
        public List<ItemDefinition> TenMinutePotionsBlacklist { get; set; } = new List<ItemDefinition>();

        [Label("[i:531] Potions and buffs have improved tooltips")]
        [Tooltip("Changes some potions and buffs to be more informative and worded more consistently")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsAndBuffsImprovedTooltips { get; set; }

        [Header("Vanilla Potion Changes")]

        [Label("[i:2344] Ammo Reservation Potion changes")]
        [Tooltip("30% (was 20%) chance not to consume ammo")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionChanges_AmmoReservation { get; set; }

        [Label("[i:303] Archery Potion changes")]
        [Tooltip("Reworked to be \"Predator Potion\" - 10% increased ranged damage and critical chance")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionChanges_Archery { get; set; }

        [Label("[i:2325] Builder Potion changes")]
        [Tooltip("Increased placement range by 3 (was 1) and increased placement speed by 50% (was 25%)")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionChanges_Builder { get; set; }

        [Label("[i:293] Mana Regeneration changes")]
        [Tooltip("Also grants a constant 4 mana regeneration per second which happens even when you're using a magic weapon")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionChanges_ManaRegen { get; set; }

        [Label("[i:288] Obsidian Skin Potion changes")]
        [Tooltip("Also makes you immune to Cursed Inferno and Ichor")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionChanges_ObsidianSkin { get; set; }

        [Label("[i:2328] Summoning Potion changes")]
        [Tooltip("Also increases sentry slots by 1 and increases summoning damage by 10%")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionChanges_Summoning { get; set; }

        [Header("Modded Potions")]

        [Label("$Mods.BetterPotions.Config.Grave")]
        [Tooltip("Teleports you to where you last died. Crafted with bottled water, specular fish and deathweed")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsAdded_Grave { get; set; }

        [Label("$Mods.BetterPotions.Config.War")]
        [Tooltip("Increases enemy spawn rate and cap by 400%. Crafted with bottled water, soul of fright, blinkroot and shiverthorn. Mutually exclusive with Battle")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsAdded_War { get; set; }

        [Label("$Mods.BetterPotions.Config.Instigating")]
        [Tooltip("Makes enemies more likely to target you. Crafted with bottled water, tissue sample and deathweed")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsAdded_Instigating { get; set; }

        [Label("$Mods.BetterPotions.Config.Deterring")]
        [Tooltip("Makes enemies less likely to target you. Crafted with bottled water, shadow scale and deathweed")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsAdded_Deterring { get; set; }

        [Label("$Mods.BetterPotions.Config.DiscoInferno")]
        [Tooltip("Engulf nearby enemies in dazzling flames. Crafted with bottled water, crystal shard, flarefin koi and fireblossom. Mutually exclusive with Inferno")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsAdded_DiscoInferno { get; set; }

        [Label("$Mods.BetterPotions.Config.Orichalcumskin")]
        [Tooltip("Increases defense by 14. Crafted with bottled water, daybloom and orichalcum/mythril or. Mutually exclusive with Ironskin")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsAdded_Orichalcumskin { get; set; }

        [Label("$Mods.BetterPotions.Config.Berserker")]
        [Tooltip("Increases melee damage and speed by 10%. Crafted with bottled water, rotten chunk/vertebrae, shiverthorn and fireblossom")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsAdded_Berserker { get; set; }

        [Label("$Mods.BetterPotions.Config.Piercing")]
        [Tooltip("Increases armor penetration by 10. Crafted with bottled water, demonite/crimtane ore, deathweed")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsAdded_Piercing { get; set; }

        [Label("$Mods.BetterPotions.Config.Leaping")]
        [Tooltip("Increases jump speed by 50% and enables auto-jump. Crafted with bottled water, cloud, blinkroot, waterleaf")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsAdded_Leaping { get; set; }

        [Label("$Mods.BetterPotions.Config.Steelfall")]
        [Tooltip("Increases falling speed, press DOWN to fall faster. Crafted with bottled water, daybloom, blinkroot and iron/lead bar")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsAdded_Steelfall { get; set; }

        [Label("$Mods.BetterPotions.Config.HeightenedSenses")]
        [Tooltip("See nearby sources of danger, see better in the dark and see the location of enemies. Crafted with bottled water, soul of sight, daybloom and blinkroot")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsAdded_HeightenedSenses { get; set; }

        [Label("$Mods.BetterPotions.Config.Immovable")]
        [Tooltip("Grants immunity to knockback. Crafted with bottled water, soul of might, shiverthorn and moonglow")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsAdded_Immovable { get; set; }

        [Label("$Mods.BetterPotions.Config.Flight")]
        [Tooltip("Grants you ethereal wings to fly with. Crafted with bottled water, soul of flight, feather and daybloom")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool PotionsAdded_Flight { get; set; }
    }
}