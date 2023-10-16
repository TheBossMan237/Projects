using Microsoft.Xna.Framework.Input;
using System.Numerics;
using Terraria;
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
            Item.damage = -1;
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.width = 54;
            Item.height = 20;
            Item.shoot = ModContent.ProjectileType<HealBeamProj>();
            Item.holdStyle = 0;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shootSpeed = 5f;
            Item.noMelee = true;
            Item.autoReuse = true;

        }
        public override bool? CanHitNPC(Player player, NPC target)
        {
            return true;
        }
    }
}
