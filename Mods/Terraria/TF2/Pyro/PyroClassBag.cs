using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using TF2.Generic;
using TF2.Pyro;

namespace TF2.Pyro
{
    internal class PyroClassBag : ModItem
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
            p.GiveItem<Flamethrower>(0);
            p.GiveItem<Shotgun>(1);
            p.GiveItem<Fireaxe>(2);
            p.GiveEquipment<PyroIdentifier>();
            return base.UseItem(player);
        }
    }
}
