using TF2.Content.Proj;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TF2.Content.Weapons.Melee
{
    public class Bonesaw : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.TF2.hjson file.
        public override void SetDefaults()
        {
            
            Item.damage = 65;
            Item.DamageType = DamageClass.Melee;
            Item.width = 60;
            Item.height = 26;
            Item.useTime = 48;
            Item.useAnimation = 48;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = 10000;
            Item.rare = 2;
            Item.UseSound = SoundID.Item7;
            Item.autoReuse = true;
        }
    }
}