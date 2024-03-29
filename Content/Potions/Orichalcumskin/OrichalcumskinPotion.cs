using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using BetterPotions.Common.Configs;

namespace BetterPotions.Content.Potions.Orichalcumskin
{
	public class OrichalcumskinPotion : ModItem
	{
		public override bool IsLoadingEnabled(Mod mod)
			=> ModContent.GetInstance<BetterPotionsConfig>().PotionsAdded_Orichalcumskin;

		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;

			ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
				new Color(254, 198, 251),
				new Color(239, 113, 248),
				new Color(205, 30, 199)
			};
		}

		public override void SetDefaults()
		{
			Item.width = 12;
			Item.height = 30;
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item3;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.sellPrice(silver: 2);
			Item.buffType = ModContent.BuffType<OrichalcumskinBuff>();
			Item.buffTime = 8 * 60 * 60;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.IronskinPotion)
				.AddIngredient(ItemID.OrichalcumOre)
				.AddTile(TileID.Bottles)
				.Register();

			CreateRecipe()
				.AddIngredient(ItemID.IronskinPotion)
				.AddIngredient(ItemID.MythrilOre)
				.AddTile(TileID.Bottles)
				.Register();
		}
	}
}
