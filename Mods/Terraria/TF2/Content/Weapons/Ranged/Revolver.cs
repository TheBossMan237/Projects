using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;

namespace TF2.Content.Weapons.Ranged
{
    internal class Revolver : ModItem
    {
        public override void SetDefaults()
        {
            Item.scale = .5f;
            Item.shoot = ProjectileID.Bullet;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.autoReuse = false;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shootSpeed = 5f;
            Item.UseSound = new SoundStyle($"{nameof(TF2)}/Assets/Sounds/revolver_shoot")
            {
                Volume = .25f,
                PitchVariance = .2f,
                MaxInstances = 3,
            };

        }
        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(3, 1)
            .Register();
        }
    }
}
