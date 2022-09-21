using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterPotions.Common.GlobalItems
{
    public class BetterPotionsGlobalItem : GlobalItem
    {
        #region Tooltips

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            TooltipLine line;

            switch (item.type)
            {
                case ItemID.AmmoReservationPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Increases chance to not consume ammo by 30%";
                    break;
                case ItemID.ArcheryPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Increases ranged damage and critical chance by 10%";
                    break;
                case ItemID.BattlePotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Increases enemy spawn rate and spawn cap by 100%";
                    break;
                case ItemID.BuilderPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Increases placement range by 3 tiles and placement speed by 75%";
                    break;
                case ItemID.CalmingPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Decreases enemy spawn rate by 17% and decreases enemy spawn cap by 20%";
                    break;
                case ItemID.CratePotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Increases chance to get a crate by 10%";
                    break;
                case ItemID.TrapsightPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Allows you to see nearby sources of danger";
                    break;
                case ItemID.FeatherfallPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Slows falling speed\nPress UP or DOWN to control speed of descent";
                    break;
                case ItemID.GillsPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Allows you to breathe underwater";
                    break;
                case ItemID.GravitationPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Allows you to control gravity\nPress UP to reverse gravity";
                    break;
                case ItemID.IronskinPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Increases defense by 8";
                    break;
                case ItemID.MagicPowerPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Increases magic damage by 20%";
                    break;
                case ItemID.ManaRegenerationPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Increases mana regeneration and grants a small amount of constant mana regeneration";
                    break;
                case ItemID.NightOwlPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Grants night vision";
                    break;
                case ItemID.ObsidianSkinPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Grants immunity to fire and lava";
                    break;
                case ItemID.RegenerationPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Grants life regeneration";
                    break;
                case ItemID.SummoningPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Increases your max number of minions and sentries by 1 and increases minion damage by 10%";
                    break;
                case ItemID.SwiftnessPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Increases movement speed by 25%";
                    break;
                case ItemID.TitanPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Increases knockback by 50%";
                    break;
                case ItemID.WarmthPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Reduces damage from cold sources by 30%";
                    break;
                case ItemID.WaterWalkingPotion:
                    line = tooltips.Find(x => x.Name == "Tooltip0");
                    line.Text = "Grants the ability to walk on water";
                    break;
            }
        }

        #endregion
    }
}