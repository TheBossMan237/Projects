using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TF2.Assets;
namespace TF2.Demoman
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
            Item.UseSound = Sounds.grenadelauncher_shoot;
        }


    }
}
