using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using BetterPotions.Common.Configs;

namespace BetterPotions.Content.Potions.Piercing
{
	public class PiercingPotion : ModItem
	{
		public override bool IsLoadingEnabled(Mod mod)
			=> ModContent.GetInstance<BetterPotionsConfig>().PotionsAdded_Piercing;

		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;

			ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
				new Color(190, 204, 255),
				new Color(95, 125, 255),
				new Color(34, 80, 246)
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
			Item.buffType = ModContent.BuffType<PiercingBuff>();
			Item.buffTime = 6 * 60 * 60;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient(ItemID.CrimtaneOre)
				.AddIngredient(ItemID.Deathweed)
				.AddTile(TileID.Bottles)
				.Register();

			CreateRecipe()
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient(ItemID.DemoniteOre)
				.AddIngredient(ItemID.Deathweed)
				.AddTile(TileID.Bottles)
				.Register();
		}
	}
}
