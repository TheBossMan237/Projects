using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
namespace TF2.Proj
{
    internal class BlankBullet : ModProjectile
    {
        public override void OnSpawn(IEntitySource source)
        {
            Projectile.Kill();
            return;
        }
    }
}
