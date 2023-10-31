using Terraria;
using Terraria.ModLoader;
using TF2.Generic;
using Terraria.ID;
namespace TF2.ClassItems {
    public class EngineerClassBag : ModItem
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Engineer/" + Name;
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
            p.GiveItem<Shotgun>(0);
            p.GiveItem<Pistol>(1);
            p.GiveItem<Wrench>(2);
            p.GiveEquipment(new Item(ItemID.EngineeringHelmet), 0);
            p.GiveEquipment(new Item(ItemID.FamiliarShirt), 1);
            p.GiveEquipment(new Item(ItemID.FamiliarPants), 2);
            p.GiveEquipment<EngineerIdentifier>();

            return base.UseItem(player);
        }

    }
    public class EngineerIdentifier : ModItem
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Engineer/" + Name;

        public override void SetDefaults()
        {
            Item.accessory = true;
        }
    }
    public class Wrench : ModItem
    {
        public override string Texture => Mod.Name + "/Assets/Textures/Engineer/" + Name;

        public override void SetDefaults()
        {
            Item.damage = 65;
            Item.DamageType = DamageClass.Melee;
            Item.width = 60;
            Item.height = 26;
            Item.useTime = 45;
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