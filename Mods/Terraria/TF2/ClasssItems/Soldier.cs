using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using TF2.Generic;
using TF2.Proj;
namespace TF2.ClassItems
{
    public class MarketGardener : ModItem {
        public override string Texture => Mod.Name + "/Assets/Textures/Soldier/" + Name;
    }
    internal class Shovel : ModItem
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Soldier/" + Name;
        public override void SetDefaults()
        {
            Item.damage = 65;
            Item.DamageType = DamageClass.Melee;
            Item.width = 60;
            Item.height = 26;
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = 10000;
            Item.rare = 2;
            Item.autoReuse = true;
        }
    }
    internal class SoldierClassBag : ModItem
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Soldier/" + Name;
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
            p.GiveItem<RocketLauncher>(0);
            p.GiveItem<Shotgun>(1);
            p.GiveItem<Shovel>(2);
            p.GiveEquipment(new Item(ItemID.FamiliarWig), 0);
            p.GiveEquipment(new Item(ItemID.FamiliarShirt), 1);
            p.GiveEquipment(new Item(ItemID.FamiliarPants), 2);
            p.GiveEquipment<SoldierIdentifier>();
            return base.UseItem(player);
        }
    }
    internal class SoldierIdentifier : ModItem
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Soldier/" + Name;
        public override void SetDefaults()
        {
            Item.accessory = true;
        }
    }
    internal class RocketLauncher : ModItem
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Soldier/" + Name;
        public override void SetDefaults()
        {
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.width = 54;
            Item.height = 16;
            Item.shoot = ModContent.ProjectileType<Rocket>();
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.shootSpeed = 5f;
            Item.noMelee = true;
            Item.autoReuse = true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
    }
}
