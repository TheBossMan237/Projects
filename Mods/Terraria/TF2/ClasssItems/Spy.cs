﻿using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using TF2.Utills;

namespace TF2.ClassItems
{
    public class DisguiseKit : TF2Weapon{
        public override string Texture => Mod.Name + "/Assets/Textures/Spy/" + Name;
        public int counter = 0;
        public override void SetDefaults(){
            Item.CloneDefaults(ItemID.JimsDrone);
            WeaponData(-1, -1, 1, -1, true);
        }
        public override bool? UseItem(Player player)
        {

            return base.UseItem(player);
        }
    }
    internal class Knife : TF2Weapon
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Spy/" + Name;
        public override void SetDefaults(){
            Item.CloneDefaults(ItemID.CopperBroadsword);
            WeaponData(-1, -1, .8f, -1, true);
        }
    }
    internal class Revolver : TF2Weapon
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Spy/" + Name;
        public override void SetDefaults()
        {
            WeaponData(6, 24, .5f, 1.113f);
            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 5f;

        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(3, 1)
            .Register();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback){
            if (!CanShoot()) return false;
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
    }
    internal class SpyClassBag : ModItem
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Spy/" + Name;
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
    internal class SpyIdentifier : ModItem
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Spy/" + Name;
        public override void SetDefaults()
        {
            Item.accessory = true;

        }
    }
}
