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

        foreach (CraftingRecepie recepie in Station.Recepies)
        {
            if (recepie.canbecrafted == true)
            {
                Outputholder.value = recepie.Result;
                Outputholder.amount = 1;
                Outputholder.filled = false;
            }
        }
        if (Outputholder.value == null)
        {
            pressed = false;
            Outputholder.filled = false;
            Outputholder.preview = true;
        }
        if (checkemptyslots() == true && Outputholder.amount != 1)
        {
            Outputholder.value = null;
        }
        Checkforrecepies();
        GiveItemsBack();
    }
    //give items back to the user if he leaves and the bool saveitems is false
    void GiveItemsBack()
    {
        // Add Items back on Exit if Saveitems is false
        if (Station.Saveitems == false && CraftingSlots[1].activeInHierarchy == false)
        {
            if (Outputholder.preview == false) {
            Inventory.AddValue(Outputholder.value,false);
            }
            Outputholder.value = null;
            Outputholder.output = false;
            Outputholder.preview = true;
            foreach (GameObject Slot in CraftingSlots)
            {
                ItemHolder holder = Slot.GetComponent<ItemHolder>();
                if (holder.value != null)
                {
                    for (int i = 0; i < holder.amount; i++)
                    {
                        if (holder.value != null)
                        {
                            Inventory.AddValue(holder.value, false);
                        }
                        holder.amount--;
                        if (holder.amount == 0)
                        {
                            holder.value = null;
                        }
                    }
                }
            }
            gameObject.GetComponent<Crafting>().enabled = false;
        }
    }

    // check if the item is used in an recepie
    bool isitemfound(Itemvalue CheckItem, bool morethanoneitem)
    {
        bool itemtrue = false;
        bool singeitemcheck = true;
        foreach (GameObject Slot in CraftingSlots)
        {
            ItemHolder holder = Slot.GetComponent<ItemHolder>();
            if (holder.value != null)
            {
                if (morethanoneitem == true)
                {
                    if (holder.value == CheckItem)
                    {
                        return true;
                    }
                }
                else
                {
                    if (holder.value == CheckItem && singeitemcheck == true)
                    {
                        itemtrue = true;
                    }
                    else if (holder.value != CheckItem)
                    {
                        singeitemcheck = false;
                        itemtrue = false;
                    }
                }

            }

        }
        return itemtrue;
    }
    bool checkemptyslots()
    {
        bool checkedall = false;
        int check = 0;
        bool allempty = false;
        foreach (GameObject Slot in CraftingSlots)
        {
            ItemHolder Slotholder = Slot.GetComponent<ItemHolder>();
            if (Slotholder.value == null)
            {
                check++;
            }
            if (check == 4)
            {
                checkedall = true;
                allempty = true;
            }
        }
        return allempty;
    }
    //check if an recepie is craftable
    void Checkforrecepies()
    {
        if (Outputholder.amount != 1)
        {
            Outputholder.value = null;
        }
        bool multipleitems = false;
        //get Recepie
        foreach (CraftingRecepie Currentrecepie in Station.Recepies)
        {
            Currentrecepie.canbecrafted = false;
            //Check if needed Item is in Slot
            foreach (Itemvalue Item in Currentrecepie.Itemvalues)
            {
                if (Currentrecepie.Itemvalues.Length > 1)
                {
                    multipleitems = true;
                }
                if (!isitemfound(Item, multipleitems))
                {
                    Currentrecepie.canbecrafted = false;
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

        if (pressed == true)
        {
            int index = 0;
            foreach (Itemvalue Item in recepie.Itemvalues)
            {
                bool ready = false;
                while (ready == false)
                {
                    ItemHolder h = CraftingSlots[index].GetComponent<ItemHolder>();
                    if (checkforitem(Item, h.value))
                    {
                        h.amount -= 1;
                        if (h.amount == 0)
                        {
                            index++;
                            h.value = null;
                        }
                        ready = true;
                    }
                    else
                    {
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
    bool checkforitem(Itemvalue one, Itemvalue two)
    {
        if (one == two)
        {
            return true;
        }
        return false;
    }

}
