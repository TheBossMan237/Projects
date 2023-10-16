using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace TF2.Content.Proj
{
    internal class Rocket : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 10; // The width of projectile hitbox
            Projectile.height = 10; // The height of projectile hitbox
            Projectile.aiStyle = ProjAIStyleID.Beam;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 100;
            Projectile.timeLeft = 30;
            Projectile.light = 0f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;

        }
        public override void AI()
        {

            base.AI();
        }
        public override void OnKill(int timeLeft)
        {
            Player player = Main.player[Projectile.owner];
            if (Projectile.position.Distance(player.position) < 78.1225) {
                Projectile.oldVelocity = Projectile.oldVelocity * -1;
                player.velocity += Projectile.oldVelocity;
            }

            base.OnKill(timeLeft);

        }
    }
}
