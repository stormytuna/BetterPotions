using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using BetterPotions.Content.Buffs;

namespace BetterPotions.Content.Items
{
	public class DiscoInfernoPotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Engulf nearby enemies in dazzling flames\nMutually exclusive with Inferno\n'Burn baby burn!'");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;

			// Dust that will appear in these colors when the item with ItemUseStyleID.DrinkLiquid is used
			ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
				new Color(119, 178, 247),
				new Color(255, 139, 234),
				new Color(251, 251, 251)
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
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.sellPrice(silver: 2);
			Item.buffType = ModContent.BuffType<DiscoInferno>();
			Item.buffTime = 10 * 60 * 60;
		}

        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient(ItemID.CrystalShard)
				.AddIngredient(ItemID.FlarefinKoi)
				.AddIngredient(ItemID.Fireblossom)
				.AddTile(TileID.Bottles)
				.Register();
        }
    }
}