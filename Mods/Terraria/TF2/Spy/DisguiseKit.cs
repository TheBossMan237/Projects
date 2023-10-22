using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Map;
using TF2.Spy;
using TF2.Scout;
namespace TF2.Spy
{
    public class DisguiseKit : ModItem
    {
        public int counter = 0;
        public override void SetDefaults()
        {
            Item.useTime = 1;
            Item.useAnimation = 1;

            Item.useStyle = ItemUseStyleID.HoldUp;
        }
        public override bool? UseItem(Player player)
        {

            return base.UseItem(player);
        }
    }
}
