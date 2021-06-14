using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Itemvalue : ScriptableObject
{
    public int id;
    public enum type {Material,Consumable,Headarmor,Chestarmor,Leggingsarmor,Sheosarmor,Primaryarm,Secondaryarm};
    public enum raritys {Common,Uncommon,Rare,Epic,Legendary,Void};
    public enum Type{Pickaxe,Axe,Hoe,Meele,Range,Magic,Armor};
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
    public float Manaajust;
    public float Miningspeed;
    public float Critchance;
    public float Critdamage;
    public float Strength;
    public float Defense;
    public float Damage;
    public float Hp;
    public float Speed;
    public Type Equiptype;
}