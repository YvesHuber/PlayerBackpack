using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    //T is the Temporary Item
    public GameObject[] Slots;
    public Itemvalue[] Itemvalues;
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


    void Update()
    {
        Updatecheck();
    }

    void Addstats(Itemvalue Item)
    {
        maxHP += Item.Hp;
        stamina += Item.Staminaajust;
        Speed += Item.Speed;
        Damage += Item.Damage;
        Strength += Item.Strength;
        Defense += Item.Defense;
        Critdamage += Item.Critdamage;
        Critchance += Item.Critchance;
    }
    void Removestats(Itemvalue Item)
    {
        maxHP -= Item.Hp;
        stamina -= Item.Staminaajust;
        Speed -= Item.Speed;
        Damage -= Item.Damage;
        Strength -= Item.Strength;
        Defense -= Item.Defense;
        Critdamage -= Item.Critdamage;
        Critchance -= Item.Critchance;
    }
    void Updatecheck()
    {
        int i = 0;
        foreach (GameObject Slot in Slots)
        {
            ItemHolder Holder = Slot.GetComponent<ItemHolder>();
            Itemvalue Titem = Holder.value;
            Itemvalue Iteminslot = Itemvalues[i];
            if (Titem != null)
            {
                if (Iteminslot == null)
                {
                    Iteminslot = Titem;
                    Addstats(Iteminslot);
                }
                if (Iteminslot != Titem){
                    Removestats(Iteminslot);
                    Iteminslot = Titem;
                    Addstats(Iteminslot);
                }
                Itemvalues[i] = Iteminslot;
            }
        }
    }
}
