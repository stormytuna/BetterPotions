using Terraria.ModLoader;
using BetterPotions.Content.Items;

namespace BetterPotions
{
    public class BetterPotions : Mod
    {
        public override void Load()
        {
            AddToggle("Mods.BetterPotions.Config.Grave", "Grave Potion", ModContent.ItemType<GravePotion>(), "ffffff");
            AddToggle("Mods.BetterPotions.Config.War", "War Potion", ModContent.ItemType<WarPotion>(), "ffffff");
            AddToggle("Mods.BetterPotions.Config.Instigating", "Instigating Potion", ModContent.ItemType<InstigatingPotion>(), "ffffff");
            AddToggle("Mods.BetterPotions.Config.Deterring", "Deterring Potion", ModContent.ItemType<DeterringPotion>(), "ffffff");
            AddToggle("Mods.BetterPotions.Config.DiscoInferno", "DiscoInferno Potion", ModContent.ItemType<DiscoInfernoPotion>(), "ffffff");
            AddToggle("Mods.BetterPotions.Config.Orichalcumskin", "Orichalcumskin Potion", ModContent.ItemType<OrichalcumskinPotion>(), "ffffff");
            AddToggle("Mods.BetterPotions.Config.Berserker", "Berserker Potion", ModContent.ItemType<BerserkerPotion>(), "ffffff");
            AddToggle("Mods.BetterPotions.Config.Piercing", "Piercing Potion", ModContent.ItemType<PiercingPotion>(), "ffffff");
            AddToggle("Mods.BetterPotions.Config.Leaping", "Leaping Potion", ModContent.ItemType<LeapingPotion>(), "ffffff");
            AddToggle("Mods.BetterPotions.Config.Steelfall", "Steelfall Potion", ModContent.ItemType<SteelfallPotion>(), "ffffff");
            AddToggle("Mods.BetterPotions.Config.HeightenedSenses", "Heightened Senses Potion", ModContent.ItemType<HeightenedSensesPotion>(), "ffffff");
            AddToggle("Mods.BetterPotions.Config.Immovable", "Immovable Potion", ModContent.ItemType<ImmovablePotion>(), "ffffff");
            AddToggle("Mods.BetterPotions.Config.Flight", "Flight Potion", ModContent.ItemType<FlightPotion>(), "ffffff");
        }

        private void AddToggle(string toggle, string name, int item, string color)
        {
            ModTranslation text = LocalizationLoader.CreateTranslation(toggle);
            text.SetDefault("[i:" + item + "] [c/" + color + ": " + name + "]");
            LocalizationLoader.AddTranslation(text);
        }
    }
}