using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace BetterPotions.Content.Potions.Flight
{
    [AutoloadEquip(EquipType.Wings)]
    public class FlightPotionWings : ModItem
    {
        public override void SetStaticDefaults()
        {
            ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(80, 4.5f, 1.5f);
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 28;
            Item.value = Item.sellPrice(platinum: 999);
            Item.rare = ItemRarityID.Expert;
            Item.accessory = true;
        }
    }
}
