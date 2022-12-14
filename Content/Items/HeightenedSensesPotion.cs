using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using BetterPotions.Content.Buffs;
using BetterPotions.Common.Configs;

namespace BetterPotions.Content.Items
{
	public class HeightenedSensesPotion : ModItem
	{
		public override bool IsLoadingEnabled(Mod mod)
			=> ModContent.GetInstance<BetterPotionsConfig>().PotionsAdded_HeightenedSenses;

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Allows you to see nearby sources of danger, see better in the dark and see nearby enemies\nMutually exclusive with Dangersense, Night Owl and Hunter");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;

			// Dust that will appear in these colors when the item with ItemUseStyleID.DrinkLiquid is used
			ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
				new Color(255, 250, 112),
				new Color(254, 246, 37),
				new Color(255, 156, 12)
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
			Item.rare = ItemRarityID.Pink;
			Item.value = Item.sellPrice(silver: 2);
			Item.buffType = ModContent.BuffType<HeightenedSenses>();
			Item.buffTime = 8 * 60 * 60;
		}

        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient(ItemID.SoulofSight)
				.AddIngredient(ItemID.Daybloom)
				.AddIngredient(ItemID.Blinkroot)
				.AddTile(TileID.Bottles)
				.Register();
        }
    }
}