using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterPotions.Content.DecorativePotions;

public class DecorativePotionItem(int potionItemType, int placeTileType) : ModItem
{
    protected override bool CloneNewInstances => true;

    public override string Name => GetInternalNameFromPotionItemType(potionItemType);

    public static string GetInternalNameFromPotionItemType(int potionItemType) => $"Decorative{ItemID.Search.GetName(potionItemType)}";

    public override void SetDefaults() {
        Item.DefaultToPlaceableTile(placeTileType);
        Item.SetShopValues(ItemRarityID.White, Item.sellPrice(silver: 1));

        Item.maxStack = Item.CommonMaxStack;
        Item.width = 20;
        Item.height = 20;
    }

    public override void AddRecipes() {
        CreateRecipe()
            .AddIngredient(potionItemType)
            .AddTile(TileID.HeavyWorkBench)
            .Register();
    }

    public class DecorativePotionLoader : ILoadable
    {
        public void Load(Mod mod) {
            Register(mod, ItemID.HealingPotion);
            Register(mod, ItemID.GreaterHealingPotion);
            Register(mod, ItemID.SuperHealingPotion);
            Register(mod, ItemID.ManaPotion);
            Register(mod, ItemID.GreaterManaPotion);
            Register(mod, ItemID.SuperManaPotion);
        }

        public void Unload() { }

        private void Register(Mod mod, int potionItemType) {
            DecorativePotionTile tile = new(potionItemType);
            mod.AddContent(tile);
            mod.AddContent(new DecorativePotionItem(potionItemType, tile.Type));
        }
    }
}
