using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;
using TF2.Assets;

namespace TF2.Generic
{

    internal class Pistol : ModItem
    {
        public override void SetDefaults()
        {
            Item.shoot = ProjectileID.Bullet;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 9;
            Item.useTime = 9;
            Item.height = 30;
            Item.width = 42;
            Item.scale = .5f;
            Item.shootSpeed = 5f;
            Item.UseSound = Sounds.pistol_shoot;
            Item.autoReuse = false;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(3, 1)
            .Register();
        }

    }
}
