using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using TF2.Medic;
namespace TF2.Medic
{
    internal class MedicClassBag : ModItem
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
            p.GiveItem<MediGun>(0);
            player.hair = 115;
            p.GiveItem<SyringeGun>(1);
            p.GiveItem<Bonesaw>(2);
            p.GiveEquipment(new Item(ItemID.FamiliarWig), 0);
            p.GiveEquipment(new Item(ItemID.DrManFlyLabCoat), 1);
            p.GiveEquipment(new Item(ItemID.FamiliarPants), 2);
            p.GiveEquipment<MedicIdentifier>();

            return base.UseItem(player);
        }
    }
}
