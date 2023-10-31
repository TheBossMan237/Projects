using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using TF2.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
namespace TF2.ClassItems
{
    internal class Bat : ModItem
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Scout/" + Name;
        public override void SetDefaults()
        {
            Item.damage = 65;
            Item.DamageType = DamageClass.Melee;
            Item.width = 60;
            Item.height = 26;
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = 10000;
            Item.rare = 2;
            Item.UseSound = SoundID.Item7;
            Item.autoReuse = true;
        }

    }
    internal class ScoutClassBag : ModItem
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Scout/" + Name;
        public override void SetDefaults()
        {
            Item.useStyle = 4;
            Item.consumable = true;
            Item.width = 32;
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.height = 32;
        }
        public override bool? UseItem(Player player)
        {
            TF2Player p = player.GetModPlayer<TF2Player>();
            p.ClearHotbar();
            p.GiveItem<ScatterShotgun>(0);
            p.GiveItem<Pistol>(1);
            p.GiveItem<Bat>(2);
            p.GiveEquipment(new Item(ItemID.GreenCap), 0);
            p.GiveEquipment(new Item(ItemID.TreasureHunterShirt), 1);
            p.GiveEquipment(new Item(ItemID.FamiliarPants), 2);
            p.GiveEquipment<ScoutIdentifier>();
            return base.UseItem(player);
        }

    }
    internal class ScoutIdentifier : ModItem
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Scout/" + Name;
        public override void SetDefaults()
        {
            Item.accessory = true;
        }
    }

    internal class ScatterShotgun : ModItem
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Scout/" + Name;
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 16;
            Item.shootSpeed = 5f;
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.Bullet;


        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            const int NumBullets = 8;
            for (int i = 0; i < NumBullets; i++)
            {
                Vector2 vel = velocity.RotatedByRandom(MathHelper.ToRadians(15));
                vel *= 1f - Main.rand.NextFloat(.3f);
                Projectile.NewProjectileDirect(source, position, vel, type, damage, knockback);
            }

            return true;
        }
    }
}
