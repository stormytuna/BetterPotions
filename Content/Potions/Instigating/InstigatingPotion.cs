using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using BetterPotions.Common.Configs;

namespace BetterPotions.Content.Potions.Instigating
{
	public class InstigatingPotion : ModItem
	{
		public override bool IsLoadingEnabled(Mod mod)
			=> ModContent.GetInstance<BetterPotionsConfig>().PotionsAdded_Instigating;

		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;

			ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
				new Color(236, 170, 171),
				new Color(255, 125, 129),
				new Color(255, 210, 211)
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
			Item.rare = ItemRarityID.Green;
			Item.value = Item.sellPrice(silver: 2);
			Item.buffType = ModContent.BuffType<InstigatingBuff>();
			Item.buffTime = 8 * 60 * 60;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient(ItemID.TissueSample)
				.AddIngredient(ItemID.Deathweed)
				.AddTile(TileID.Bottles)
				.Register();
		}
	}
}
