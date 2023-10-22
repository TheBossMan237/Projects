using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using TF2.Heavy;
using TF2.Generic;
namespace TF2.Heavy
{
    internal class HeavyClassBag : ModItem
    {
        public override void SetDefaults()
        {
            Item.useStyle = 4;
            Item.consumable = true;
            Item.width = 32;
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.height = 32;
        }
        public override bool? UseItem(Player player)
        {
            TF2Player p = player.GetModPlayer<TF2Player>();
            p.ClearHotbar();
            p.GiveItem<Minigun>(0);
            p.GiveItem<Shotgun>(1);
            p.GiveItem<Fists>(2);
            p.GiveEquipment(new Item(ItemID.FamiliarWig), 0);
            p.GiveEquipment(new Item(ItemID.FamiliarShirt), 1);
            p.GiveEquipment(new Item(ItemID.FamiliarPants), 2);
            p.GiveEquipment<HeavyIdentifier>();

            return base.UseItem(player);
        }
    }
}
