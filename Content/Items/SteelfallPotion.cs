using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using BetterPotions.Content.Buffs;
using BetterPotions.Common.Configs;

namespace BetterPotions.Content.Items
{
	public class SteelfallPotion : ModItem
	{
		public override bool IsLoadingEnabled(Mod mod)
			=> ModContent.GetInstance<BetterPotionsConfig>().PotionsAdded_Steelfall;

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increases falling speed\nPress DOWN to fall faster");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;

			// Dust that will appear in these colors when the item with ItemUseStyleID.DrinkLiquid is used
			ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
				new Color(247, 157, 162),
				new Color(242, 94, 101),
				new Color(219, 23, 33)
			};
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 30;
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item3;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(silver: 2);
			Item.buffType = ModContent.BuffType<Steelfall>();
			Item.buffTime = 10 * 60 * 60;
		}

        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient(ItemID.Daybloom)
				.AddIngredient(ItemID.Blinkroot)
				.AddIngredient(ItemID.LeadBar)
				.AddTile(TileID.Bottles)
				.Register();

			CreateRecipe()
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient(ItemID.Daybloom)
				.AddIngredient(ItemID.Blinkroot)
				.AddIngredient(ItemID.IronBar)
				.AddTile(TileID.Bottles)
				.Register();
		}
    }
}