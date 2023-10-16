using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using TF2.Content.Weapons.Ranged;
using TF2.Content.Weapons.Melee;
namespace TF2.Content.ClassBags
{
    internal class SniperClassBag : ModItem
    {
        public override void SetDefaults()
        {
            Item.consumable = true;
            Item.width = 32;
            Item.height = 32;
        }
        public override void RightClick(Player player)
        {
            player.QuickSpawnItem(player.GetSource_DropAsItem(), ModContent.ItemType<Kukri>());
            player.QuickSpawnItem(player.GetSource_DropAsItem(), ModContent.ItemType<SMG>());
            player.QuickSpawnItem(player.GetSource_DropAsItem(), ModContent.ItemType<SniperRifle>());

            base.RightClick(player);
        }
        public override bool CanRightClick()
        {
            return true;
        }
    }
}
