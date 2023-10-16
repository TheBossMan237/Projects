using Terraria.Audio;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace TF2.Content.Weapons.Ranged
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
            Item.UseSound = new SoundStyle($"{nameof(TF2)}/Assets/Sounds/sniper_shoot")
            {
                Volume = .25f,
                PitchVariance = .2f,
                MaxInstances = 3,
            };
        }
    }
}
