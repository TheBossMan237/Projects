using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TF2.Content.Proj;

namespace TF2.Content.Weapons.Ranged
{
    internal class SyringeGun : ModItem
    {
        public override void SetDefaults()
        {
            Item.shoot = ModContent.ProjectileType<SyringeProj>();
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.autoReuse = false;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shootSpeed = 5f;
        }
    }
}
