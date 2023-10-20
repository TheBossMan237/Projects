using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Server;
using TF2.Content.Proj;

namespace TF2.Content.Weapons.Ranged
{
    internal class MediGun : ModItem

    {
        public override void SetDefaults()
        {
            Item.damage = 1;
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.width = 54;
            Item.height = 20;
            Item.holdStyle = 0;
            Item.shoot = ModContent.ProjectileType<HealProj>();
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shootSpeed = 5f;
            Item.noMelee = true;
            Item.autoReuse = true;

        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Microsoft.Xna.Framework.Vector2 position, Microsoft.Xna.Framework.Vector2 velocity, int type, int damage, float knockback)
        {
            float spacing = 1f;
            float distance = Main.MouseWorld.Distance(position);
            Color c = new Color(255, 255, 255);
            if (player.team == 0) c = new Color(255, 0, 0);
            else c = new Color(0, 0, 255);
            Vector2 pos = position + velocity * 10;
            damage = damage * 10;
            
            for (float i = 0; i < distance; i += spacing) {
                pos = pos.MoveTowards(Main.MouseWorld, spacing);
                int dust = Dust.NewDust(pos,1, 1, DustID.Stone, 0, 0, 20, c);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].scale = .5f;

            }
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            
            base.OnHitNPC(player, target, hit, damageDone);
            
        }   


    }
}
