using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using BetterPotions.Content.Buffs;

namespace BetterPotions.Content.Items
{
	public class ImmovablePotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Grants you immunity to knockback");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;

			// Dust that will appear in these colors when the item with ItemUseStyleID.DrinkLiquid is used
			ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
				new Color(216, 177, 236),
				new Color(189, 124, 224),
				new Color(160, 70, 209)
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
			Item.buffType = ModContent.BuffType<Immovable>();
			Item.buffTime = 10 * 60 * 60;
		}

        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient(ItemID.SoulofMight)
				.AddIngredient(ItemID.Shiverthorn)
				.AddIngredient(ItemID.Moonglow)
				.AddTile(TileID.Bottles)
				.Register();
        }
    }
}