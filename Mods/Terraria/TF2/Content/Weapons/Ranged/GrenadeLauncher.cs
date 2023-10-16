using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TF2.Content.Weapons.Ranged
{
    internal class GrenadeLauncher : ModItem
    {
        public override void SetDefaults()
        {
            Item.shoot = ProjectileID.Grenade;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.autoReuse = false;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shootSpeed = 5f;
            Item.width = 56;
            Item.height = 22;
        }
    }
}
