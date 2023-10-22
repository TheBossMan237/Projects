﻿using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using TF2.Spy;
using TF2.Medic;
using TF2.Sniper;
using TF2.Pyro;
using TF2.Engineer;
using TF2.Scout;
using TF2.Heavy;
using TF2.Demoman;
using TF2.Soldier;

namespace TF2
{
    internal class TF2Player : ModPlayer
    {
        public string TF2Class = "";
        public string TF2Disguise = "";
        public bool IsDev = true;
        public bool isRed = false;
        public void GiveItem(Item i, int slot=1) {Player.inventory[slot] = i; }
        public void GiveItem<T>(int slot = 0) where T : ModItem { Player.inventory[slot] = new Item(ModContent.ItemType<T>(), 1); }
        public void GiveEquipment<T>(int slot = 3) where T : ModItem {Player.armor[slot] = new Item(ModContent.ItemType<T>(), 1); }
        public void GiveEquipment(Item i, int slot = 3) { Player.armor[slot] = i;}
        public void DeleteItem(int slot) {Player.inventory[slot] = new Item();}
        public void GiveArmor(int item) {
            Player.bank.AddItemToShop(new Item(item));
            Player.armor[0] = Player.bank.item[0];
        }
        public void ClearInvetory() {
            for (int i = 0; i < 50; i++) {
                Player.inventory[i] = new Item();
            }
        }
        public void ClearHotbar() {
            for (int i = 0; i < 9; i++) {
                Player.inventory[i] = new Item();
            }
        }
        public void SpyInit() {
            this.GiveItem(new Item(ModContent.ItemType<Revolver>()), 0);
            this.GiveItem(new Item(ModContent.ItemType<DisguiseKit>()), 0);
        }
        
        public override void OnEnterWorld()
        {
            if (Player.armor[3].Name != "") {
                TF2Class = Player.armor[3].Name.Split("Identifier")[0];
                return;
            }
            for (int i = 0; i < 10; i++) {
                if (Player.inventory[i].Name != "") {

                    return;

                }
                
            }
            
            GiveItem<ScoutClassBag>(1);
            GiveItem<SoldierClassBag>(2);
            GiveItem<PyroClassBag>(3);
            GiveItem<DemomanClassBag>(4);
            GiveItem<HeavyClassBag>(5);
            GiveItem<EngineerClassBag>(6);
            GiveItem<MedicClassBag>(7);
            GiveItem<SniperClassBag>(8);
            GiveItem<SpyClassBag>(9);


            base.OnEnterWorld();
        }
    }
}
