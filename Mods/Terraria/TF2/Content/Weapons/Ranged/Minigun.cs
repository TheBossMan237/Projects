
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using TF2.Content.Proj;

namespace TF2.Content.Weapons.Ranged
{
    internal class Minigun : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.useTime = 2;
            Item.useAnimation = 2;
            Item.width = 56;
            Item.height = 20;
            Item.shoot = ProjectileID.Bullet;
            Item.holdStyle = 0;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shootSpeed = 5f;
            Item.noMelee = true;
            Item.autoReuse = true;

        }
    }
}
