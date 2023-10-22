using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using TF2.Assets;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using TF2.Proj;

namespace TF2.Soldier
{
    internal class RocketLauncher : ModItem
    {
        public override void SetDefaults()
        {
            Item.useTime = 48;
            Item.useAnimation = 48;
            Item.width = 54;
            Item.height = 16;
            Item.shoot = ModContent.ProjectileType<Rocket>();
            Item.holdStyle = 0;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = Sounds.rocket_launcher_shoot;
            Item.shootSpeed = 5f;
            Item.noMelee = true;
            Item.autoReuse = true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
    }
}
