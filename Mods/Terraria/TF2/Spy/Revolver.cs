using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;
using TF2.Assets;
using TF2.Proj;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace TF2.Spy
{
    internal class Revolver : ModItem
    {
        public override void SetDefaults()
        {
            Item.scale = .5f;
            Item.damage = 1;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.autoReuse = false;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 5f;
            Item.UseSound = Sounds.revolver_shoot;
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
}
