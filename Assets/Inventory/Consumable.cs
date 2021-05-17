using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
        public string DisplayTitle;
        public string Description;
        public double Worth;
        public int StackSize;
        public int MaxStackSize;
        public double Healthajust;
        public double Staminaajust;
        public double Manaajust;
        public enum raritys {Common,Uncommon,Rare,Epic,Legendary,Void};
        public string Itemtype = "Consumable";
        public raritys rarity;
        public int id;
        public Sprite UiIcon;
}
