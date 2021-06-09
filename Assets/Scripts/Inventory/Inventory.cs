using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public GameObject[] Slots;
    ItemHolder Current;
    ItemHolder Future;
    ItemHolder Currentcopy;
    ItemHolder Futurecopy;
    private ItemHolder Slot;

    // Check for slot then Add Slot
    public void AddValue(Itemvalue s)
    {
        foreach (GameObject currentSlot in Slots)
        {
            Slot = currentSlot.GetComponent<ItemHolder>();
            try
            {
                Debug.Log("New Item " + s.DisplayTitle + " current Slot Item " + Slot.value.DisplayTitle);
                if (s.DisplayTitle == Slot.value.DisplayTitle)
                {
                    if (Slot.amount + s.StackSize <= Slot.value.MaxStackSize)
                    {
                        Slot.amount += s.StackSize;
                        Slot.AddItem(s);
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                print("Slot empty");
            }

        }
            foreach (GameObject currentSlot in Slots)
            {
                Slot = currentSlot.GetComponent<ItemHolder>();
                if (Slot.value == null)
                {
                    Debug.Log(s.DisplayTitle);
                    Slot.AddItem(s);
                    
                    return;
                }
            }
            Slot = null;

    }
    public void copyItemholder(ItemHolder Future, ItemHolder Current, ItemHolder Futurecopy,ItemHolder Currentcopy){

        Future.value = Currentcopy.value;

        Future.amount = Currentcopy.amount;
            Debug.Log("Befor" + Current.value);
            if (Futurecopy.value != null){
                Current.value = Futurecopy.value;
            }else{
                 Current.value = null;
            }
                Debug.Log("Dann" + Current.value);
        Current.amount = Futurecopy.amount;
      
        
    }
    public void checkslotandswitch(Vector3 pos, GameObject selfslot){
        foreach (GameObject currentSlot in Slots)
        {
            if(currentSlot.GetComponent<Collider>().bounds.Contains(pos)){
                if ( currentSlot != selfslot){
                    Debug.Log("Not the same");
                    //over Slot and the slot is not itself
                    Current = currentSlot.GetComponent<ItemHolder>();
                    Currentcopy = currentSlot.GetComponent<ItemHolder>();
                    Future = selfslot.GetComponent<ItemHolder>();
                    Futurecopy = selfslot.GetComponent<ItemHolder>();
                    copyItemholder(Future,Current,Futurecopy,Currentcopy);
                    
                }
            }
        }
    }

}

