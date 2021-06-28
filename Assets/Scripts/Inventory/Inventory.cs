using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public GameObject[] Slots;
    public GameObject[] Equipslots;
    ItemHolder Current;
    Itemvalue CurrentItemvalue;
    int Currentamount;
    ItemHolder Future;
    Itemvalue FutureItemvalue;
    public Stats Playerstats;
    int Futureamount;
    private GameObject Slottoequip;
    private ItemHolder Slot;

    // Check for slot then Add Slot check for used slots with same item first
    public bool AddValue(Itemvalue s, bool armor)
    {
        foreach (GameObject currentSlot in Slots)
        {
            Slot = currentSlot.GetComponent<ItemHolder>();
            try
            {
                if (s.DisplayTitle == Slot.value.DisplayTitle)
                {
                    if (Slot.amount + s.StackSize <= Slot.value.MaxStackSize)
                    {
                        if (!armor == true)
                        {
                            Slot.amount += s.StackSize;
                            Slot.AddItem(s);
                            return true;
                        }
                        else
                        {
                            Slot.amount = s.StackSize;
                            Slot.AddItem(s);
                            return true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }

        }
        foreach (GameObject currentSlot in Slots)
        {
            Slot = currentSlot.GetComponent<ItemHolder>();
            if (Slot.value == null)
            {
                Slot.AddItem(s);
                return true;
            }
        }
        Slot = null;
        return false;

    }
    // Add the Item of the hit breakable in the inventory
    public void Addbreakable(Itemvalue s)
    {
        bool added = false;
        foreach (GameObject currentSlot in Slots)
        {
            Slot = currentSlot.GetComponent<ItemHolder>();
            try
            {
                if (s.DisplayTitle == Slot.value.DisplayTitle)
                {
                    if (Slot.amount + s.StackSize <= Slot.value.MaxStackSize)
                    {

                        Slot.amount = s.StackSize;
                        Slot.AddItem(s);
                        added = true;
                    }
                }
            }
            catch (Exception e)
            {
            }

        }
        foreach (GameObject currentSlot in Slots)
        {
            if (added == false)
            {
                Slot = currentSlot.GetComponent<ItemHolder>();
                if (Slot.value == null)
                {
                    Slot.AddItem(s);
                    added = true;
                }
            }
        }
        Slot = null;
    }

    public void Consume(GameObject Slot){
        ItemHolder holder = Slot.GetComponent<ItemHolder>();
        Playerstats.Addstats(holder.value);
        holder.amount -= 1;
        if (holder.amount <= 0){
            holder.value = null;
        }
    }
    //Add armor and compare the slots 
    public void Addarmor(int Enumint, GameObject selfslot)
    {
        Enumint -= 2;
        Slottoequip = Equipslots[Enumint];
        Current = selfslot.GetComponent<ItemHolder>();
        CurrentItemvalue = Current.value;
        Currentamount = Current.amount;
        Future = Slottoequip.GetComponent<ItemHolder>();
        FutureItemvalue = Future.value;
        Futureamount = Future.amount;
        copyItemholder(Current, CurrentItemvalue, Currentamount, Future, FutureItemvalue, Futureamount);

    }
    //check the slot and switch the Items
    public void checkslotandswitch(Vector3 pos, GameObject selfslot)
    {
        foreach (GameObject currentSlot in Slots)
        {
            if (currentSlot.GetComponent<Collider>().bounds.Contains(pos))
            {
                if (currentSlot != selfslot)
                {
                    //over Slot and the slot is not itself
                    Current = currentSlot.GetComponent<ItemHolder>();
                    CurrentItemvalue = Current.value;
                    Currentamount = Current.amount;
                    Future = selfslot.GetComponent<ItemHolder>();
                    FutureItemvalue = Future.value;
                    Futureamount = Future.amount;
                    copyItemholder(Current, CurrentItemvalue, Currentamount, Future, FutureItemvalue, Futureamount);

                }
            }
        }
    }
    //switch 2 slot items and the amount
    public void copyItemholder(ItemHolder C, Itemvalue CItem, int Camount, ItemHolder F, Itemvalue FItem, int Famount)
    {
        C.value = FItem;
        C.amount = Famount;
        F.value = CItem;
        F.amount = Camount;
    }

}

