using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TF2.Assets;
namespace TF2.Demoman
{
    internal class StickyBombLauncher : ModItem
    {
        public override void SetDefaults()
        {
            Item.shoot = ProjectileID.StickyGrenade;
            Item.useAnimation = 120;
            Item.useTime = 120;
            Item.autoReuse = false;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shootSpeed = 5f;
            Item.UseSound = Sounds.stickybomblaunher_shoot;
        }
    }
}
