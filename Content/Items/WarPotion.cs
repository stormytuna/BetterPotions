using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using BetterPotions.Content.Buffs;

namespace BetterPotions.Content.Items
{
	public class WarPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increases enemy spawn rate and spawn cap by 400%\nMutually Exclusive with Battle");

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
			Item.rare = ItemRarityID.Pink;
			Item.value = Item.sellPrice(silver: 2);
			Item.buffType = ModContent.BuffType<War>();
			Item.buffTime = 8 * 60 * 60;
		}

        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient(ItemID.SoulofFright)
				.AddIngredient(ItemID.Blinkroot)
				.AddIngredient(ItemID.Shiverthorn)
				.AddTile(TileID.Bottles)
				.Register();
        }
    }
}