using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public GameObject[] Slots;
    private ItemHolder Slot;

    // Check for slot then Add Slot
    public void AddValue(Item s)
    {
        foreach (GameObject currentSlot in Slots)
        {
            Slot = currentSlot.GetComponent<ItemHolder>();
            try {
            Debug.Log("New Item " + s.DisplayTitle + " current Slot Item " + Slot._script.DisplayTitle);
            if (s.DisplayTitle == Slot._script.DisplayTitle)
            {
                if (Slot.amount + s.StackSize <= Slot._script.MaxStackSize)
                {
                    Slot.amount += s.StackSize;
                    Slot.AddItem(s);
                    break;
                }
            }
            }
            catch (Exception e) {
            print("error");
            }  

        }
        foreach (GameObject currentSlot in Slots)
        {
            Slot = currentSlot.GetComponent<ItemHolder>();
            if (Slot._script == null)
            {
                Debug.Log(s.DisplayTitle);
                Slot.AddItem(s);
                break;
            }
        }
        Slot = null;
    
    }

}

