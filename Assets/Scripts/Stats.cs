using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public ItemHolder CurrentHead;
    private ItemHolder Head;
    private Item Headitem;
    public ItemHolder CurrentChest;
    private ItemHolder Chest;
    private Item Chestitem;
    public ItemHolder CurrentPants;
    private ItemHolder Pants;
    private Item Pantsitem;
    public ItemHolder CurrentShoes;
    private ItemHolder Shoes;
    private Item Shoesitem;
    public ItemHolder CurrentPrimaryarm;
    private ItemHolder Primaryarm;
    private Item Primaryarmitem;
    public ItemHolder CurrentSecondaryarm;
    private ItemHolder Secondaryarm;
    private Item Secondaryarmitem;
    public ItemHolder CurrentCape;
    private ItemHolder Cape;
    private Item Capeitem;
    public ItemHolder CurrentAmulet;
    private ItemHolder Amulet;
    private Item Amuletitem;
    public float maxHP;
    public float hp;
    public float hpregen;
    public float maxStamina;
    public float stamina;
    public float Speed;
    public float sthregen;
    public float Damage;
    public float Strength;
    public float Defense;
    public float Critchance;
    public float Critdamage;


    void Update() {
        /*
        Updatecheck(CurrentHead ,Head , Headitem);
        Updatecheck(CurrentChest ,Chest , Chestitem);
        Updatecheck(CurrentPants ,Pants , Pantsitem);
        Updatecheck(CurrentShoes , Shoes, Shoesitem);
        Updatecheck(CurrentPrimaryarm ,Primaryarm , Primaryarmitem);
        Updatecheck(CurrentSecondaryarm ,Secondaryarm , Secondaryarmitem);
        Updatecheck(CurrentCape ,Cape , Capeitem);
        Updatecheck(CurrentAmulet, Amulet, Amuletitem);
        */
    }

    void Addstats(Item l){
        maxHP += l.Hp;
        stamina += l.Staminaajust;
        Speed += l.Speed;
        Damage += l.Attack;
        Strength += l.Strength;
        Defense += l.Defense;
        Critdamage += l.Critdamage;
        Critchance += l.Critchance;

    }

    void Updatecheck(ItemHolder currentslot, ItemHolder slot, Item slotitem){
        if (currentslot != slot || slot == null) {
            slot = currentslot;
            slotitem = slot._script;
            Addstats(slotitem);
        }
    }
}
