using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Server;
using TF2.Proj;
using TF2.Assets;
using TF2.Buffs;

namespace TF2.Medic
{
    internal class MediGun : ModItem

    {
        public float spacing = 1f;
        public bool LockOnTarget = false;
        public NPC target; //CHANGE TO PLAYER 
        public bool isShooting = false;
        public float distance = 0f;
        public override void SetDefaults()
        {
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.width = 54;
            Item.height = 20;
            Item.shoot = ModContent.ProjectileType<BlankBullet>();
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shootSpeed = 5f;
            Item.noMelee = true;
            Item.autoReuse = true;

        }
        public override void HoldItem(Player player)
        {
            
            if (!isShooting || distance > 500f) { target = null; }

            isShooting = false;
            base.HoldItem(player);
            
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            
            isShooting = true;
            Vector2 MoveTowards = Main.MouseWorld;
            TF2Player p = player.GetModPlayer<TF2Player>();
            
            Color c = player.team == 0 ? Color.Blue : Color.Red;
            
            


            if (target == null && p.MouseOver != null) { target = p.MouseOver; }
            else if (target != null) { MoveTowards = target.position; target.AddBuff(ModContent.BuffType<HealEffect>(), 1);  }
            else { return false; }

            distance = MoveTowards.Distance(position);
            position += velocity * 10;
            for (float i = 0; i < distance; i += spacing){
                position = position.MoveTowards(MoveTowards, spacing);
                int dust = Dust.NewDust(position, 1, 1, DustID.Stone, 0, 0, 20, c);
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