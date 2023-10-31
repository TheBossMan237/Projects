using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TF2.Assets;
namespace TF2.ClassItems
{
    public class GrenadeLauncher : ModItem
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Demoman/" + Name;
        public override void SetDefaults()
        {
            Item.shoot = ProjectileID.Grenade;
            Item.useAnimation = 1;
            Item.useTime = 1;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shootSpeed = 5f;

        }
    }
    public class StickyBombLauncher : ModItem
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Demoman/" + Name;
        public override void SetDefaults()
        {
            Item.shoot = ProjectileID.StickyGrenade;
            Item.useAnimation = 1;
            Item.useTime = 1;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shootSpeed = 5f;

        }
    }
    public  class Bottle : ModItem
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Demoman/" + Name;
        public override void SetDefaults()
        {
            Item.damage = 65;
            Item.DamageType = DamageClass.Melee;
            Item.width = 60;
            Item.height = 26;
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
        }
    }
    public class DemomanClassBag : ModItem
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Demoman/" + Name;
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
    public class DemomanIdentifier : ModItem
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Demoman/" + Name;
        public override void SetDefaults()
        {
            Item.accessory = true;
        }
    }
}
