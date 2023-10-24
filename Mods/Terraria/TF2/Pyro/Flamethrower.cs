using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using TF2.Proj;
using TF2.Assets;
using ReLogic.Utilities;

namespace TF2.Pyro { 



    internal class Flamethrower : ModItem
    {
        public bool hasToReload = false;
        public static int AmmoCap = 200;
        public int Ammo = 200;
        public int TimePassed = 0;
        public bool isShooting = false;
        public SlotId soundPlaying;

        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.useTime = 5;
            Item.useAnimation = 5;
            Item.width = 54;
            Item.height = 16;
            Item.shoot = ModContent.ProjectileType<FlamethrowerProj>();
            Item.holdStyle = 0;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shootSpeed = 5f;
            Item.noMelee = true;
            Item.autoReuse = true;

        }
        public override void AddRecipes()
        {
            CreateRecipe().
            AddIngredient(3, 1)
            .Register();
        }
        public override void HoldItem(Player player)
        {
            if (!isShooting) {
                TimePassed = 0;
            }
            
            isShooting = false;
            base.HoldItem(player);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            TimePassed += 5;

            if (TimePassed > 150) {
                
                soundPlaying = SoundEngine.PlaySound(Sounds.flamethrower_shoot);
                TimePassed = 0;
            }
            isShooting = true;


            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }

    }
}
