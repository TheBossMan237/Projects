using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TF2.Generic;
using TF2.Scout;



namespace TF2.Scout
{
    internal class ScoutClassBag : ModItem
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
            p.GiveItem<ScatterShotgun>(0);
            p.GiveItem<Pistol>(1);
            p.GiveItem<Bat>(2);
            p.GiveEquipment(new Item(ItemID.GreenCap), 0);
            p.GiveEquipment(new Item(ItemID.TreasureHunterShirt), 1);
            p.GiveEquipment(new Item(ItemID.FamiliarPants), 2);
            p.GiveEquipment<ScoutIdentifier>();
            return base.UseItem(player);
        }

    }
}
