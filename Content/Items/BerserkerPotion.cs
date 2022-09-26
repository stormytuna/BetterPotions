using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using BetterPotions.Content.Buffs;
using BetterPotions.Common.Configs;

namespace BetterPotions.Content.Items
{
	public class BerserkerPotion : ModItem
	{
		public override bool IsLoadingEnabled(Mod mod)
			=> ModContent.GetInstance<BetterPotionsConfig>().PotionsAdded_Berserker;
        public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increases melee damage and speed by 10%");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;

			// Dust that will appear in these colors when the item with ItemUseStyleID.DrinkLiquid is used
			ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
				new Color(178, 244, 255),
				new Color(95, 229, 255),
				new Color(34, 211, 246)
			};
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 40;
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item3;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.sellPrice(silver: 2);
			Item.buffType = ModContent.BuffType<Berserker>();
			Item.buffTime = 8 * 60 * 60;
		}

        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient(ItemID.RottenChunk)
				.AddIngredient(ItemID.Shiverthorn)
				.AddIngredient(ItemID.Fireblossom)
				.AddTile(TileID.Bottles)
				.Register();

			CreateRecipe()
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient(ItemID.Vertebrae)
				.AddIngredient(ItemID.Shiverthorn)
				.AddIngredient(ItemID.Fireblossom)
				.AddTile(TileID.Bottles)
				.Register();
		}
    }
}