using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;
using TF2.Content.Proj;
namespace TF2.Content.Weapons.Ranged
{
    internal class RocketLauncher : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.useTime = 5;
            Item.useAnimation = 5;
            Item.width = 54;
            Item.height = 16;
            Item.shoot = ModContent.ProjectileType<Rocket>();
            Item.holdStyle = 0;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shootSpeed = 5f;
            Item.noMelee = true;
            Item.autoReuse = true;
        }


    }
}
