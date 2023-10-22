using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using TF2.Demoman;

namespace TF2.Demoman
{
    internal class DemomanClassBag : ModItem
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
            p.GiveItem<GrenadeLauncher>(0);
            p.GiveItem<StickyBombLauncher>(1);
            p.GiveItem<Bottle>(2);
            p.GiveEquipment(new Item(ItemID.EyePatch), 0);
            p.GiveEquipment(new Item(ItemID.FamiliarShirt), 1);
            p.GiveEquipment(new Item(ItemID.FamiliarPants), 2);

            p.GiveEquipment<DemomanIdentifier>();

            return base.UseItem(player);
        }

    }
}
