using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using BetterPotions.Common.Configs;
using Terraria.DataStructures;

namespace BetterPotions.Content.Potions.Grave
{
	public class GravePotion : ModItem
	{
		public override bool IsLoadingEnabled(Mod mod)
			=> ModContent.GetInstance<BetterPotionsConfig>().PotionsAdded_Grave;

		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Teleports you to where you last died");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;

			// Dust that will appear in these colors when the item with ItemUseStyleID.DrinkLiquid is used
			ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
				new Color(247, 182, 54),
				new Color(238, 102, 70),
				new Color(193, 43, 43)
			};
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 26;
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item3;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.sellPrice(silver: 2);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient(ItemID.SpecularFish)
				.AddIngredient(ItemID.Deathweed)
				.AddTile(TileID.Bottles)
				.Register();
		}

		public override bool CanUseItem(Player player)
			=> player.GetModPlayer<GravePotionPlayer>().gravePotionPos != Vector2.Zero;

		public override void UseStyle(Player player, Rectangle heldItemFrame)
		{
			// Each frame make dust
			if (Main.rand.NextBool())
			{
				int d = Dust.NewDust(player.position, player.width, player.height, DustID.Pixie, 0f, 0f, 150, Color.White, 1.1f);
			}

			// Set up item time correctly
			if (player.itemTime == 0)
				player.ApplyItemTime(Item);

			else if (player.itemTime == player.itemTimeMax / 2) // Runs once halfway through using the item
			{
				// Make dust 70 times for cool effect
				for (int i = 0; i < 70; i++)
				{
					int d = Dust.NewDust(player.position, player.width, player.height, DustID.Pixie, 0f, 0f, 150, Color.White, 1.1f);
				}

				// This code releases all grappling hooks and kills/despawns them.
				player.grappling[0] = -1;
				player.grapCount = 0;
				for (int p = 0; p < 1000; p++)
				{
					if (Main.projectile[p].active && Main.projectile[p].owner == player.whoAmI && Main.projectile[p].aiStyle == 7)
					{
						Main.projectile[p].Kill();
					}
				}

				// The actual method that moves the player back to bed/spawn.
				player.Teleport(player.GetModPlayer<GravePotionPlayer>().gravePotionPos);
				player.GetModPlayer<GravePotionPlayer>().gravePotionPos = Vector2.Zero;

				// Make dust 70 times for a cool effect. This dust is the dust at the destination.
				for (int i = 0; i < 70; i++)
				{
					int d = Dust.NewDust(player.position, player.width, player.height, DustID.Pixie, 0f, 0f, 150, Color.White, 1.1f);
				}
			}
		}
	}

	public class GravePotionPlayer : ModPlayer
	{
		public Vector2 gravePotionPos = Vector2.Zero;

		public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
		{
			gravePotionPos = Player.position;
		}
	}
}
