using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private ItemHolder Head;
    private Item Headitem;
    private ItemHolder Chest;
    private Item Chestitem;
    private ItemHolder Pants;
    private Item Pantsitem;
    private ItemHolder Shoes;
    private Item Shoesitem;
    private ItemHolder Primaryarm;
    private Item Primaryarmitem;
    private ItemHolder Secondaryarm;
    private Item Secondaryarmitem;
    private ItemHolder Cape;
    private Item Capeitem;
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

    void Addstats(Itemvalue l){
        maxHP += l.Hp;
        stamina += l.Staminaajust;
        Speed += l.Speed;
        Damage += l.Damage;
        Strength += l.Strength;
        Defense += l.Defense;
        Critdamage += l.Critdamage;
        Critchance += l.Critchance;

    }

    void Updatecheck(ItemHolder currentslot, ItemHolder slot, Itemvalue slotitem){
        if (currentslot != slot || slot == null) {
            slot = currentslot;
            slotitem = slot.value;
            Addstats(slotitem);
        }
    }
}
