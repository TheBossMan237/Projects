using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using TF2.Generic;
using TF2.Proj;
namespace TF2.ClassItems
{
    internal class Fireaxe : ModItem
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Pyro/" + Name;
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
            Item.UseSound = SoundID.Item7;
            Item.autoReuse = true;
        }
    }
    internal class Flamethrower : ModItem
    {
        public bool hasToReload = false;
        public static int AmmoCap = 200;
        public int Ammo = 200;
        public int TimePassed = 0;
        public bool isShooting = false;
        public override string Texture => Mod.Name + "/Assets/Textures/Pyro/" + Name;
        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.width = 54;
            Item.height = 16;
            Item.shoot = ModContent.ProjectileType<FlamethrowerProj>();
            Item.holdStyle = 0;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shootSpeed = 5f;
            Item.noMelee = true;
            Item.autoReuse = true;

        }
        public override void HoldItem(Player player)
        {
            if (!isShooting)
            {
                TimePassed = 0;
            }

            isShooting = false;
            base.HoldItem(player);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {


            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }

    }
    internal class PyroClassBag : ModItem
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Pyro/" + Name;
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
    internal class PyroIdentifier : ModItem
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Pyro/" + Name;
        public override void SetDefaults()
        {
            Item.accessory = true;
        }
    }
}
