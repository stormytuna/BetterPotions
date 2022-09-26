using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using BetterPotions.Content.Buffs;
using BetterPotions.Common.Configs;

namespace BetterPotions.Content.Items
{
	public class LeapingPotion : ModItem
	{
		public override bool IsLoadingEnabled(Mod mod)
			=> ModContent.GetInstance<BetterPotionsConfig>().PotionsAdded_Leaping;

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increased jump speed by 50% and enables auto-jump");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;

			// Dust that will appear in these colors when the item with ItemUseStyleID.DrinkLiquid is used
			ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
				new Color(255, 221, 146),
				new Color(255, 206, 95),
				new Color(246, 181, 34)
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
			Item.buffType = ModContent.BuffType<Leaping>();
			Item.buffTime = 8 * 60 * 60;
		}

        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient(ItemID.Cloud)
				.AddIngredient(ItemID.Blinkroot)
				.AddIngredient(ItemID.Waterleaf)
				.AddTile(TileID.Bottles)
				.Register();
		}
    }
}