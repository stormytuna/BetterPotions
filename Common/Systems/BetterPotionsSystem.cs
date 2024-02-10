using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using System;
using System.Linq;
using BetterPotions.Content.Potions.Grave;
using BetterPotions.Content.Potions.Instigating;
using BetterPotions.Content.Potions.Deterring;
using BetterPotions.Content.Potions.Berserker;
using BetterPotions.Content.Potions.Piercing;
using BetterPotions.Content.Potions.Leaping;
using BetterPotions.Content.Potions.Steelfall;
using BetterPotions.Content.Potions.War;
using BetterPotions.Content.Potions.DiscoInferno;
using BetterPotions.Content.Potions.Orichalcumskin;
using BetterPotions.Content.Potions.HeightenedSenses;
using BetterPotions.Content.Potions.Immovable;
using BetterPotions.Content.Potions.Flight;

namespace BetterPotions.Common.Systems
{
    public class BetterPotionsSystem : ModSystem
    {
        public override void PostWorldGen()
        {
            List<int> undergroundChests = new List<int>
            {
                1*36, 8*36, 11*36, 13*36, 15*36, 17*36, 52*36, 51*36
            };

            for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];
                bool[] placedPotions = new bool[7] { false, false, false, false, false, false, false };

                // Undeground chests (Gold, Frozen, Rich Mahogony, Skyware, Water, Web Covered, Marble, Granite)
                if (chest != null && Main.tile[chest.x, chest.y].TileType == TileID.Containers && undergroundChests.Contains(Main.tile[chest.x, chest.y].TileFrameX))
                {
                    placedPotions = new bool[7] { false, false, false, false, false, false, false };

                    for (int invIndex = 0; invIndex < 40; invIndex++)
                    {
                        if (chest.item[invIndex].type == ItemID.None)
                        {
                            // Grave
                            if (Main.rand.NextBool(10) && !placedPotions[0])
                            {
                                chest.item[invIndex].SetDefaults(ModContent.ItemType<GravePotion>());
                                chest.item[invIndex].stack = Main.rand.Next(1, 4);
                                placedPotions[0] = true;
                                continue;
                            }

                            // Instigating
                            if (Main.rand.NextBool(7) && !placedPotions[1])
                            {
                                chest.item[invIndex].SetDefaults(ModContent.ItemType<InstigatingPotion>());
                                chest.item[invIndex].stack = Main.rand.Next(1, 4);
                                placedPotions[1] = true;
                                continue;
                            }

                            // Deterring
                            if (Main.rand.NextBool(7) && !placedPotions[2])
                            {
                                chest.item[invIndex].SetDefaults(ModContent.ItemType<DeterringPotion>());
                                chest.item[invIndex].stack = Main.rand.Next(1, 4);
                                placedPotions[2] = true;
                                continue;
                            }

                            // Berserker
                            if (Main.rand.NextBool(6) && !placedPotions[3])
                            {
                                chest.item[invIndex].SetDefaults(ModContent.ItemType<BerserkerPotion>());
                                chest.item[invIndex].stack = Main.rand.Next(1, 4);
                                placedPotions[3] = true;
                                continue;
                            }

                            // Piercing
                            if (Main.rand.NextBool(6) && !placedPotions[4])
                            {
                                chest.item[invIndex].SetDefaults(ModContent.ItemType<PiercingPotion>());
                                chest.item[invIndex].stack = Main.rand.Next(1, 4);
                                placedPotions[4] = true;
                                continue;
                            }

                            // Leaping
                            if (Main.rand.NextBool(7) && !placedPotions[5])
                            {
                                chest.item[invIndex].SetDefaults(ModContent.ItemType<LeapingPotion>());
                                chest.item[invIndex].stack = Main.rand.Next(1, 4);
                                placedPotions[5] = true;
                                continue;
                            }

                            // Steelfall
                            if (Main.rand.NextBool(10) && !placedPotions[6])
                            {
                                chest.item[invIndex].SetDefaults(ModContent.ItemType<SteelfallPotion>());
                                chest.item[invIndex].stack = Main.rand.Next(1, 4);
                                placedPotions[6] = true;
                                continue;
                            }

                            break;
                        }
                    }
                }

                // Dungeon chests
                if (chest != null && Main.tile[chest.x, chest.y].TileType == TileID.Containers && Main.tile[chest.x, chest.y].TileFrameX == 2 * 36)
                {
                    placedPotions = new bool[7] { false, false, false, false, false, false, false };

                    for (int invIndex = 0; invIndex < 40; invIndex++)
                    {
                        if (chest.item[invIndex].type == ItemID.None)
                        {
                            // Grave
                            if (Main.rand.NextBool(4) && !placedPotions[0])
                            {
                                chest.item[invIndex].SetDefaults(ModContent.ItemType<GravePotion>());
                                chest.item[invIndex].stack = Main.rand.Next(1, 4);
                                placedPotions[0] = true;
                                continue;
                            }

                            // War
                            if (Main.rand.NextBool(5) && !placedPotions[1])
                            {
                                chest.item[invIndex].SetDefaults(ModContent.ItemType<WarPotion>());
                                placedPotions[1] = true;
                                continue;
                            }

                            // Disco Inferno
                            if (Main.rand.NextBool(7) && !placedPotions[2])
                            {
                                chest.item[invIndex].SetDefaults(ModContent.ItemType<DiscoInfernoPotion>());
                                placedPotions[2] = true;
                                continue;
                            }

                            // Orichalcumskin
                            if (Main.rand.NextBool(7) && !placedPotions[3])
                            {
                                chest.item[invIndex].SetDefaults(ModContent.ItemType<OrichalcumskinPotion>());
                                placedPotions[3] = true;
                                continue;
                            }

                            // Heightened Senses
                            if (Main.rand.NextBool(5) && !placedPotions[4])
                            {
                                chest.item[invIndex].SetDefaults(ModContent.ItemType<HeightenedSensesPotion>());
                                placedPotions[4] = true;
                                continue;
                            }

                            // Immovable
                            if (Main.rand.NextBool(7) && !placedPotions[5])
                            {
                                chest.item[invIndex].SetDefaults(ModContent.ItemType<ImmovablePotion>());
                                placedPotions[5] = true;
                                continue;
                            }

                            // Flight
                            if (Main.rand.NextBool(8) && !placedPotions[6])
                            {
                                chest.item[invIndex].SetDefaults(ModContent.ItemType<FlightPotion>());
                                placedPotions[6] = true;
                                continue;
                            }

                            break;
                        }
                    }
                }

                // Shadow chests
                if (chest != null && Main.tile[chest.x, chest.y].TileType == TileID.Containers && Main.tile[chest.x, chest.y].TileFrameX == 4 * 36)
                {
                    placedPotions = new bool[7] { false, false, false, false, false, false, false };

                    for (int invIndex = 0; invIndex < 40; invIndex++)
                    {
                        if (chest.item[invIndex].type == ItemID.None)
                        {
                            // Grave
                            if (Main.rand.NextBool(4) && !placedPotions[0])
                            {
                                ItemSorting.SortChest();

                                chest.item[invIndex].SetDefaults(ModContent.ItemType<GravePotion>());
                                chest.item[invIndex].stack = Main.rand.Next(1, 4);
                                placedPotions[0] = true;
                                continue;
                            }

                            // War
                            if (Main.rand.NextBool(5) && !placedPotions[1])
                            {
                                chest.item[invIndex].SetDefaults(ModContent.ItemType<WarPotion>());
                                placedPotions[1] = true;
                                continue;
                            }

                            // Disco Inferno
                            if (Main.rand.NextBool(7) && !placedPotions[2])
                            {
                                chest.item[invIndex].SetDefaults(ModContent.ItemType<DiscoInfernoPotion>());
                                placedPotions[2] = true;
                                continue;
                            }

                            // Orichalcumskin
                            if (Main.rand.NextBool(7) && !placedPotions[3])
                            {
                                chest.item[invIndex].SetDefaults(ModContent.ItemType<OrichalcumskinPotion>());
                                placedPotions[3] = true;
                                continue;
                            }

                            // Heightened Senses
                            if (Main.rand.NextBool(5) && !placedPotions[4])
                            {
                                chest.item[invIndex].SetDefaults(ModContent.ItemType<HeightenedSensesPotion>());
                                placedPotions[4] = true;
                                continue;
                            }

                            // Immovable
                            if (Main.rand.NextBool(7) && !placedPotions[5])
                            {
                                chest.item[invIndex].SetDefaults(ModContent.ItemType<ImmovablePotion>());
                                placedPotions[5] = true;
                                continue;
                            }

                            // Flight
                            if (Main.rand.NextBool(8) && !placedPotions[6])
                            {
                                chest.item[invIndex].SetDefaults(ModContent.ItemType<FlightPotion>());
                                placedPotions[6] = true;
                                continue;
                            }

                            break;
                        }
                    }
                }
            }
        }
    }
}
