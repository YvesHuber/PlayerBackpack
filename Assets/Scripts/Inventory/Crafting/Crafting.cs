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
    private Itemvalue[] Temporaryvalues = new Itemvalue[64];
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
                    Debug.Log("not correct crafting for");
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
            foreach (GameObject Slot in CraftingSlots)
            {
                ItemHolder holder = Slot.GetComponent<ItemHolder>();
                holder.amount = 0;
                holder.value = null;
                Outputholder.filled = true;
                pressed = false;
                for (int i = 0; i < Itemvalues.Length; i++)
                {
                    Itemvalues[i] = null;
                }
            }
        }

    }
}
