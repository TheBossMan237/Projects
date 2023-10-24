
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using System.Threading;
using TF2.Assets;


namespace TF2.Generic
{
    internal class Shotgun : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.width = 40;
            Item.height = 16;
            Item.shootSpeed = 5f;
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = false;
            Item.shoot = ProjectileID.Bullet;
            Item.UseSound = Sounds.shotgun_shoot;


        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumBullets = 8;
            for (int i = 0; i < NumBullets; i++)
            {
                Vector2 vel = velocity.RotatedByRandom(MathHelper.ToRadians(15));
                vel *= 1f - Main.rand.NextFloat(.3f);
                Projectile.NewProjectileDirect(source, position, vel, type, Main.rand.Next(0,101) < 5 ? damage * 2 : damage, knockback);
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
