using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using TF2.Assets;
using Terraria.Audio;
using System;
using Terraria.DataStructures;
namespace TF2.Content.Proj
{
    public class Rocket : ModProjectile
    {
        

        public override void SetDefaults()
        {
            Projectile.width = 10; 
            Projectile.height = 10; 
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 100;
            Projectile.timeLeft = 300;
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



            //Rocket does 50% damage when at range;
            Player player = Main.player[Projectile.owner];
            
            SoundEngine.PlaySound(Sounds.rocket_explode);
            float distance = Projectile.position.Distance(player.position);
            if (distance < 78.1225) {
                distance = 78.1225f - distance;
                Projectile.oldVelocity = Projectile.oldVelocity * -1;
                player.velocity += Projectile.oldVelocity * (distance / 15.6245f);
                player.statLife--;
            }

            base.OnKill(timeLeft);

        }
    }
}
