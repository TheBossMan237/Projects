using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using TF2.Spy;


namespace TF2.Spy
{
    internal class SpyClassBag : ModItem
    {
        public override void SetDefaults()
        {
            Item.useStyle = 4;
            Item.consumable = true;
            Item.width = 32;
            Item.height = 32;
        }
        public override bool? UseItem(Player player)
        {
            TF2Player p = player.GetModPlayer<TF2Player>();
            p.TF2Class = "Spy";
            p.ClearInvetory();
            p.GiveItem<Revolver>(0);
            p.GiveItem<Knife>(1);
            p.GiveItem<DisguiseKit>(2);
            p.GiveEquipment<SpyIdentifier>(3);
            p.GiveEquipment(new Item(ItemID.MiningHelmet), 0);
            p.GiveEquipment(new Item(ItemID.TuxedoShirt), 1);
            p.GiveEquipment(new Item(ItemID.TuxedoPants), 2);


            return base.UseItem(player);
        }
        public override bool CanRightClick()
        {
            return true;
        }
    }
}
