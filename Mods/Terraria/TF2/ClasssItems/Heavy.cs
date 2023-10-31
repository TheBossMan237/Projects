using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using TF2.Generic;
namespace TF2.ClassItems
{
    public class HeavyIdentifier : ModItem
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Heavy/" + Name;
        public override void SetDefaults()
        {
            Item.accessory = true;
        }
    }
    internal class HeavyClassBag : ModItem
    {
        public override string Texture => $"{nameof(TF2)}/Assets/Textures/Heavy/HeavyClassBag";
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
            p.GiveItem<Minigun>(0);
            p.GiveItem<Shotgun>(1);
            p.GiveItem<Fists>(2);
            player.hair = 15;
            p.GiveEquipment(new Item(ItemID.FamiliarShirt), 1);
            p.GiveEquipment(new Item(ItemID.FamiliarPants), 2);
            p.GiveEquipment<HeavyIdentifier>();

            return base.UseItem(player);
        }
    }
    internal class Minigun : ModItem
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Heavy/" + Name;
        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.width = 56;
            Item.height = 20;
            Item.shoot = ProjectileID.Bullet;
            Item.holdStyle = 0;
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
    internal class Fists : ModItem
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Heavy/" + Name;
        public override void SetDefaults()
        {
            Item.scale = .5f;
            Item.damage = 65;
            Item.DamageType = DamageClass.Melee;
            Item.width = 60;
            Item.height = 26;
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.useStyle = ItemUseStyleID.Guitar;
            Item.holdStyle = ItemHoldStyleID.HoldFront;
            Item.knockBack = 6;
            Item.value = 10000;
            Item.rare = 2;
            Item.UseSound = SoundID.Item7;
            Item.autoReuse = true;
        }
    }
}
