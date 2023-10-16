using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
namespace TF2.Common.Systems
{
    internal class Keybinds : ModSystem
    {
        public static ModKeybind ReloadKeybind { get; private set; }
        public override void Load() {
            ReloadKeybind = KeybindLoader.RegisterKeybind(Mod, "Reload", "R");
        }
        public override void Unload()
        {
            ReloadKeybind = null;
        }
    }
}
