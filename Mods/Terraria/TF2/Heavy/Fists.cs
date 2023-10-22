using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace TF2.Heavy
{
    internal class Fists : ModItem
    {
        public override void SetDefaults()
        {
            Item.scale = .5f;
            Item.damage = 65;
            Item.DamageType = DamageClass.Melee;
            Item.width = 60;
            Item.height = 26;
            Item.useTime = 48;
            Item.useAnimation = 48;
            Item.useStyle = ItemUseStyleID.Guitar;
            Item.holdStyle = ItemHoldStyleID.HoldFront;
            Item.knockBack = 6;
            Item.value = 10000;
            Item.rare = 2;
            Item.UseSound = SoundID.Item7;
            Item.autoReuse = true;
        }
    }
}
