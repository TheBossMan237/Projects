using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using TF2.Assets;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using TF2;

namespace TF2.Sniper
{
    public class SMG : ModItem
    {


        public override void SetDefaults()
        {

            Item.scale = .5f;
            Item.damage = 14;
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.width = 54;
            Item.height = 20;
            Item.shoot = AmmoID.Bullet;
            Item.holdStyle = 0;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = Sounds.smg_shoot;
            Item.shootSpeed = 5f;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.mana = 1;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            SoundEngine.PlaySound(Sounds.smg_shoot);
            return base.Shoot(player, source, position, velocity, type, damage, knockback);

        }
    }
}
