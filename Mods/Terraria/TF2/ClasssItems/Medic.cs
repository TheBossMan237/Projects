using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using TF2.Proj;
using TF2.Utills;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using TF2.Buffs;


namespace TF2.ClassItems
{
    public class SyringeGun : ModItem
    {
        public override string Texture => $"{nameof(TF2)}/Assets/Textures/Medic/SyringeGun";

        public override void SetDefaults()
        {
            Item.shoot = ModContent.ProjectileType<SyringeProj>();
            Item.useAnimation = 1;
            Item.useTime = 1;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shootSpeed = 5f;
        }
    }
    internal class MediGun : ModItem

    {
        public override string Texture => $"{nameof(TF2)}/Assets/Textures/Medic/MediGun";
        public float spacing = 1f;
        public bool LockOnTarget = false;
        public NPC target; //CHANGE TO PLAYER 
        public bool isShooting = false;
        public float distance = 0f;
        public Timer timer = new Timer();
        public int uberChargePercent = 0;
        public bool IsUbercharging = false;
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
        public override bool AltFunctionUse(Player player)
        {
            if (IsUbercharging)
            {

            }
            return base.AltFunctionUse(player);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            isShooting = true;
            Vector2 MoveTowards = Main.MouseWorld;
            TF2Player p = player.GetModPlayer<TF2Player>();

            Color c = player.team == 0 ? Color.Blue : Color.Red;









            if (target == null && p.MouseOver != null) { target = p.MouseOver; }
            else if (target != null)
            {
                MoveTowards = target.position;
                //Every 3 frames heal the target
                if (timer.TimePassed(3))
                {
                    target.AddBuff(ModContent.BuffType<HealEffect>(), 1);
                }
                if (p.UberChargePercent < 100f && !IsUbercharging)
                {
                    p.UberChargePercent += 0.2083f;
                    IsUbercharging = p.UberChargePercent >= 100f;
                }
                if (IsUbercharging)
                {

                }

            }
            else { return false; }

            distance = MoveTowards.Distance(position);
            position += velocity * 10;
            for (float i = 0; i < distance; i += spacing)
            {
                position = position.MoveTowards(MoveTowards, spacing);
                int dust = Dust.NewDust(position, 1, 1, DustID.Stone, 0, 0, 20, c);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].scale = .5f;
            }
            timer.Tick();
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {

            base.OnHitNPC(player, target, hit, damageDone);

        }


    }
    internal class MedicClassBag : ModItem
    {
        public override string Texture => $"{nameof(TF2)}/Assets/Textures/Medic/MedicClassBag";
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
            p.GiveItem<MediGun>(0);
            player.hair = 115;
            p.GiveItem<SyringeGun>(1);
            p.GiveItem<Bonesaw>(2);
            player.hair = 115;
            p.GiveEquipment(new Item(ItemID.DrManFlyLabCoat), 1);
            p.GiveEquipment(new Item(ItemID.FamiliarPants), 2);

            p.GiveEquipment<MedicIdentifier>();

            return base.UseItem(player);
        }
    }
    internal class MedicIdentifier : ModItem
    {
        public override string Texture => $"{nameof(TF2)}/Assets/Textures/Medic/MedicIdentifier";
        public override void SetDefaults()
        {
            Item.accessory = true;
        }
    }
    public class Bonesaw : ModItem
    {
        public override string Texture => $"{nameof(TF2)}/Assets/Textures/Medic/Bonesaw";
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.TF2.hjson file.
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
}
