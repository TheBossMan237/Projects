using Terraria.Audio;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using TF2.Assets;

namespace TF2.Sniper
{
    internal class SniperRifle : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 62;
            Item.height = 24;
            Item.shoot = ProjectileID.Bullet;
            Item.useAnimation = 120;
            Item.useTime = 120;
            Item.autoReuse = false;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shootSpeed = 5f;
            Item.UseSound = Sounds.sniper_shoot;
        }
    }
}
