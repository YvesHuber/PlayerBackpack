using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
        public Itemvalue value;
        public enum type {Material,Consumable,Headarmor,Chestarmor,Leggingsarmor,Sheosarmor,Primaryarm,Secondaryarm};
        public enum raritys {Common,Uncommon,Rare,Epic,Legendary};
        public enum Type{Pickaxe,Axe,Hoe,Meele,Range,Magic,Armor};
        public int id;
        public type Itemtype;
        public raritys rarity;
        public Sprite UiIcon;
        public string DisplayTitle;
        public string Description;
        public float Worth;
        public int StackSize;
        public int MaxStackSize;
        public float Healthajust;
        public float Staminaajust;
        public float Miningspeed;
        public float Critchance;
        public float Critdamage;
        public float Strength;
        public float Defense;
        public float Damage;
        public float Hp;
        public float Speed;
        public Type Equiptype;

    void Start() {
        //Convert the Itemvalue ScirpableObject to Monobehaviour data
         id = value.id;
        Itemtype = (type)value.Itemtype;
        //rarity = value.rarity;
        UiIcon = value.UiIcon;
        DisplayTitle = value.DisplayTitle;
        Description = value.Description;
        Worth = value.Worth;
        StackSize = value.StackSize;
        MaxStackSize = value.MaxStackSize;
        Healthajust = value.Healthajust;
        Staminaajust = value.Staminaajust;
        Miningspeed = value.Miningspeed;
        Critchance = value.Critchance;
        Critdamage = value.Critdamage;
        Strength = value.Strength;
        Defense = value.Defense;
        Damage = value.Damage;
        Hp = value.Hp;
        Speed = value.Speed;
        //Equiptype = Itemvalue.Equiptype;
    }
}
