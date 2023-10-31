using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
namespace TF2.ClassItems
{
    public class DisguiseKit : ModItem{
        public override string Texture => Mod.Name + "/Assets/Textures/Spy/" + Name;
        public int counter = 0;
        public override void SetDefaults()
        {
            Item.useTime = 1;
            Item.useAnimation = 1;

            Item.useStyle = ItemUseStyleID.HoldUp;
        }
        public override bool? UseItem(Player player)
        {

            return base.UseItem(player);
        }
    }
    internal class Knife : ModItem
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Spy/" + Name;
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
        public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo)
        {
            base.OnHitPvp(player, target, hurtInfo);
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            Main.NewText(player.direction);
            base.OnHitNPC(player, target, hit, damageDone);
        }
        public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
            base.ModifyWeaponDamage(player, ref damage);
        }
    }
    internal class Revolver : ModItem
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Spy/" + Name;
        public override void SetDefaults()
        {
            Item.scale = .5f;
            Item.damage = 1;
            Item.useAnimation = 1;
            Item.useTime = 1;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 5f;

        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(3, 1)
            .Register();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

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
