using Microsoft.Xna.Framework.Input;
using Mono.Cecil.Rocks;
using System;
using System.Drawing;
using System.Numerics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace TF2.Content.Proj
{
    internal class HealBeamProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 10; // The width of projectile hitbox
            Projectile.height = 10; // The height of projectile hitbox
            Projectile.aiStyle = ProjAIStyleID.Beam;
            Projectile.friendly = true;
            Projectile.hostile = true;
            Projectile.penetrate = 100;
            Projectile.timeLeft = 300;
            Projectile.light = 1f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;

        }
        public override void AI()
        {

            int d = Dust.NewDust(Projectile.position, 8, 8, DustID.SpectreStaff, 0, 0, 1, Scale: 1);
            Dust dust = Main.dust[d];
            Player p = Main.player[Projectile.owner];
            dust.noGravity = true;
            if(p.position.Distance(Projectile.position) > p.position.Distance(Main.MouseWorld)) {
                Projectile.Kill();
            }
            base.AI();
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Main.NewText("AWD");
            base.OnHitNPC(target, hit, damageDone);
        }
    }
}
