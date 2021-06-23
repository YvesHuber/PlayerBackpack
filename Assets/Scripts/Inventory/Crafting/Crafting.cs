using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Crafting : MonoBehaviour
{
    public CraftingStation Station;
    public Button Submit;
    public GameObject[] CraftingSlots;
    public Itemvalue[] Itemvalues = new Itemvalue[64];
    public Itemvalue[] Temporaryvalues = new Itemvalue[64];
    public GameObject OutputSlot;
    public Inventory Inventory;
    private ItemHolder Outputholder;
    public bool pressed = false;

    //listen to onclick
    void Start()
    {
        Outputholder = OutputSlot.GetComponent<ItemHolder>();
        Submit.onClick.AddListener(TaskOnClick);
        Outputholder.preview = true;
    }
    void TaskOnClick()
    {
        pressed = true;
        Debug.Log("I have been pressed");
        Outputholder.preview = false;

    }
    //check if an crafting recepie can be crafted and display a preview
    void Update()
    {
        if (Outputholder.value == null)
        {
            pressed = false;
            Outputholder.filled = false;
            Outputholder.preview = true;
        }
        Slotdata();
        Checkforrecepies();
        GiveItemsBack();
    }
    //give items back to the user if he leaves and the bool saveitems is false
    void GiveItemsBack()
    {
        // Add Items back on Exit if Saveitems is false
        if (Station.Saveitems == false && CraftingSlots[1].activeInHierarchy == false)
        {
            Outputholder.value = null;
            Outputholder.filled = false;
            Outputholder.preview = true;
            for (int i = 0; i < Itemvalues.Length; i++)
            {
                if (Itemvalues[i] != null)
                {
                    bool isarmor = false;
                    if ((int)Itemvalues[i].Itemtype > 2)
                    {
                        isarmor = true;
                    }
                    if (Inventory.AddValue(Itemvalues[i], isarmor))
                    {
                        Debug.Log("Added" + Itemvalues[i]);
                        Itemvalues[i] = null;
                        foreach (GameObject Slot in CraftingSlots)
                        {
                            ItemHolder holder = Slot.GetComponent<ItemHolder>();
                            Itemvalue value = holder.value;
                            holder.value = null;
                            holder.amount = 0;
                        }
                    }
                }
            }
            gameObject.GetComponent<Crafting>().enabled = false;
        }
    }
    //get the items of each slot and add it to an array
    void Slotdata()
    {
        if (Station.Saveitems == true || CraftingSlots[1].activeInHierarchy == true)
        {
            int i = 0;
            foreach (GameObject Slot in CraftingSlots)
            {
                ItemHolder holder = Slot.GetComponent<ItemHolder>();
                Itemvalue value = holder.value;
                if (value != null)
                {
                    for (int amount = holder.amount; amount > 0; amount--)
                    {
                        Temporaryvalues[i] = value;
                        Itemvalues[i] = value;
                        i++;
                    }
                }
            }
        }
    }
    // check if the item is used in an recepie
    bool isitemfound(Itemvalue CheckItem)
    {
        for (int i = 0; i < Temporaryvalues.Length; i++)
        {
            if (Temporaryvalues[i] == CheckItem)
            {
                Temporaryvalues[i] = null;
                return true;
            }
        }
        return false;
    }
    //check if an recepie is craftable
    void Checkforrecepies()
    {
        foreach (CraftingRecepie Currentrecepie in Station.Recepies)
        {
            //get Recepie
            foreach (Itemvalue Item in Currentrecepie.Itemvalues)
            {
                //Check if needed Item is in Slot
                if (!isitemfound(Item))
                {
                    return;
                }
            }
            Currentrecepie.canbecrafted = true;
            //Evey Item is used you can Craft
            if (Currentrecepie.canbecrafted == true)
            {
                Craft(Currentrecepie);
            }
        }

    }


    //craft is button is pressed
    //remove all items
    //output can be grabed
    void Craft(CraftingRecepie recepie)
    {
        Outputholder.value = recepie.Result;
        Outputholder.amount = 1;
        Outputholder.filled = false;
        if (pressed == true)
        {
            int index = 0;
            foreach (Itemvalue Item in recepie.Itemvalues)
            {
                bool ready = false;
                while (ready == false) {
                ItemHolder h = CraftingSlots[index].GetComponent<ItemHolder>();
                if (checkforitem(Item,h.value)){
                    h.amount -= 1;
                    if (h.amount == 0){
                        index++;
                        h.value = null;
                    }
                    ready = true;
                }
                else {
                index++;
                }
                }
            }
            Outputholder.filled = true;
            pressed = false;
            for (int i = 0; i < Itemvalues.Length; i++)
            {
                Itemvalues[i] = null;
            }
        }
    }
    //compates 2 items and returns true or false
    bool checkforitem(Itemvalue one, Itemvalue two){
        if(one == two){
            return true;
        }
        return false;
    }

}
