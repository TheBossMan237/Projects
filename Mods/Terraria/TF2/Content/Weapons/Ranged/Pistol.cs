using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;

namespace TF2.Content.Weapons.Ranged
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
            Item.UseSound = new SoundStyle($"{nameof(TF2)}/Assets/Sounds/pistol_shoot") { Volume = .25f };
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
