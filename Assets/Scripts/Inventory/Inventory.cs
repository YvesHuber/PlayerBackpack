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
    int Futureamount;
    private GameObject Slottoequip;

    private ItemHolder Slot;
    // Check for slot then Add Slot
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
                Debug.Log(s.DisplayTitle);
                Slot.AddItem(s);

                return true;
            }
        }
        Slot = null;
        return false;

    }

    public void Addbreakable(Itemvalue s)
    {
        bool added = false;
        Debug.Log(s.DisplayTitle + "Add");
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
    public void copyItemholder(ItemHolder C, Itemvalue CItem, int Camount, ItemHolder F, Itemvalue FItem, int Famount)
    {
        C.value = FItem;
        C.amount = Famount;
        F.value = CItem;
        F.amount = Camount;
    }

}

