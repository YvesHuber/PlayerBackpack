using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item : MonoBehaviour
{
        public int id;
        public enum type {Material,Consumable,Equipable};
        public enum raritys {Common,Uncommon,Rare,Epic,Legendary,Void};
        public enum Type{Pickaxe,Axe,Hoe,Meele,Range,Magic,Armor};
        public type Itemtype;
        public raritys rarity;
        public Sprite UiIcon;
        public string DisplayTitle;
        public string Description;
        public double Worth;
        public int StackSize;
        public int MaxStackSize;
        public double Healthajust;
        public double Staminaajust;
        public double Manaajust;
        public double Collectionspeed;
        public double Critchance;
        public double Critdamage;
        public double Strength;
        public double Defense;
        public double Attack;
        public Type Equiptype;

}