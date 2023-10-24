using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using TF2.Generic;
using TF2.Engineer;

namespace TF2.Engineer
{
    internal class EngineerClassBag : ModItem
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
            p.GiveItem<Shotgun>(0);
            p.GiveItem<Pistol>(1);
            p.GiveItem<Wrench>(2);
            p.GiveEquipment(new Item(ItemID.FamiliarWig), 0);
            p.GiveEquipment(new Item(ItemID.FamiliarShirt), 1);
            p.GiveEquipment(new Item(ItemID.FamiliarPants), 2);
            p.GiveEquipment<EngineerIdentifier>();

            return base.UseItem(player);
        }
    }
}
