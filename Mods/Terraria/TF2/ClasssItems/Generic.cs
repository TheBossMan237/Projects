using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
namespace TF2.ClassItems
{
    public class Pistol : ModItem
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Generic/" + Name;
        public override void SetDefaults()
        {
            Item.shoot = ProjectileID.Bullet;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 1;
            Item.useTime = 1;
            Item.height = 30;
            Item.width = 42;
            Item.scale = .5f;
            Item.shootSpeed = 5f;

            Item.autoReuse = true;

        }


    }
    internal class Shotgun : ModItem
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Generic/" + Name;
        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.width = 40;
            Item.height = 16;
            Item.shootSpeed = 5f;
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.Bullet;


        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumBullets = 8;
            for (int i = 0; i < NumBullets; i++)
            {
                Vector2 vel = velocity.RotatedByRandom(MathHelper.ToRadians(15));
                vel *= 1f - Main.rand.NextFloat(.3f);
                Projectile.NewProjectileDirect(source, position, vel, type, Main.rand.Next(0, 101) < 5 ? damage * 2 : damage, knockback);
            }

            return true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(3, 1)
           .Register();
        }
    }

}
