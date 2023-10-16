
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace TF2.Content.Weapons.Melee
{
    internal class Knife : ModItem
    {
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
        public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo)
        {
            base.OnHitPvp(player, target, hurtInfo);
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            Main.NewText(player.direction);
            base.OnHitNPC(player, target, hit, damageDone);
        }
        public override void HoldItem(Player player)
        {
            Main.NewText(player.direction);
            base.HoldItem(player);
        }
        public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
            base.ModifyWeaponDamage(player, ref damage);
        }
    }
}
