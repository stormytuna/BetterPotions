using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using BetterPotions.Content.Projectiles;

namespace BetterPotions.Content.Items
{
	public class GravePotion : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Teleports you to where you last died");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;

			// Dust that will appear in these colors when the item with ItemUseStyleID.DrinkLiquid is used
			ItemID.Sets.DrinkParticleColors[Type] = new Color[3] {
				new Color(240, 240, 240),
				new Color(200, 200, 200),
				new Color(140, 140, 140)
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
			Item.value = Item.buyPrice(gold: 1);
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
			=> player.ownedProjectileCounts[ModContent.ProjectileType<GravePotionMarker>()] > 0;

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
				Projectile marker = new Projectile();
				player.creativeInterface = false;
				player.StopVanityActions();
				foreach (Projectile p in Main.projectile)
                {
					if (p.owner == player.whoAmI && p.type == ModContent.ProjectileType<GravePotionMarker>())
                    {
						marker = p;
						continue;
                    }
                }
				player.wet = false;
				player.wetCount = 0;
				player.lavaWet = false;
				Vector2 oldPos = player.position;
				player.Center = marker.Center;
				player.fallStart = (int)(player.position.Y / 16f);
				player.fallStart2 = player.fallStart;
				player.velocity.X = 0f;
				player.velocity.Y = 0f;
				player.ResetAdvancedShadows();
				for (int i = 0; i < 3; i++)
					player.UpdateSocialShadow();
				player.oldPosition = player.position + player.BlehOldPositionFixer;
				player.SetTalkNPC(-1);
				if (player.whoAmI == Main.myPlayer)
                {
					Main.npcChatCornerItem = 0;
					if (Vector2.Distance(oldPos, player.position) < new Vector2(Main.screenWidth, Main.screenHeight).Length() / 2f + 100f)
                    {
						Main.SetCameraLerp(0.1f, 0);
                    }
					else
                    {
						Main.BlackFadeIn = 255;
						Lighting.Clear();
						Main.screenLastPosition = Main.screenPosition;
						Main.instantBGTransitionCounter = 10;
						Main.renderNow = true;
						Main.screenPosition.X = player.position.X + (float)(player.width / 2) - (float)(Main.screenWidth / 2);
						Main.screenPosition.Y = player.position.Y + (float)(player.height / 2) - (float)(Main.screenHeight / 2);
						player.ForceUpdateBiomes();
					}
				}
				marker.Kill();


				// Make dust 70 times for a cool effect. This dust is the dust at the destination.
				for (int i = 0; i < 70; i++)
				{
					int d = Dust.NewDust(player.position, player.width, player.height, DustID.Pixie, 0f, 0f, 150, Color.White, 1.1f);
				}
			}

        }
    }
}