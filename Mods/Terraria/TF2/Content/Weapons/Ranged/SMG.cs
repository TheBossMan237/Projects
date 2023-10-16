using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using TF2.Content.Proj;

namespace TF2.Content.Weapons.Ranged
{
    internal class SMG : ModItem
    {
        public override void SetDefaults()
        {
            Item.scale = .5f;
            Item.damage = 14;
            Item.useTime = 5;
            Item.useAnimation = 5;
            Item.width = 54;
            Item.height = 20;
            Item.shoot = ModContent.ProjectileType<HealBeamProj>();
            Item.holdStyle = 0;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shootSpeed = 5f;
            Item.noMelee = true;
            Item.autoReuse = true;

        }
    }
}
