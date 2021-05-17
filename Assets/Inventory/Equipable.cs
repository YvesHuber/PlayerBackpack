using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipable : MonoBehaviour
{
        public enum raritys {Common,Uncommon,Rare,Epic,Legendary,Void};
        public enum Type{X,Pickaxe,Axe,Hoe,Meele,Range,Magic,Armor}
        public string DisplayTitle;
        public string Description;
        public double Worth;
        public int StackSize;
        public int MaxStackSize = 1;
        public double Collectionspeed;
        public double Critchance;
        public double Critdamage;
        public double Strength;
        public double Defense;
        public double Attack;
        public Type Equiptype;
        public string Itemtype = "Equipable";
        public raritys rarity;
        public int id;
        public Sprite UiIcon;
}
