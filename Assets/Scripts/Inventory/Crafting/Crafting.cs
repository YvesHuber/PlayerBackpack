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
    public GameObject Output;
    public Inventory Inventory;
    private ItemHolder Outputholder;
    public bool pressed = false;
    void Start()
    {

        Outputholder = Output.GetComponent<ItemHolder>();
        Submit.onClick.AddListener(TaskOnClick);
        Outputholder.preview = true;
    }
    void TaskOnClick()
    {
        pressed = true;
        Debug.Log("I have been pressed");
        Outputholder.preview = false;

    }
    void Update()
    {
        if (Outputholder.value == null)
        {
            Outputholder.filled = false;
            Outputholder.preview = true;
        }
        Slotdata();
        Checkforrecepies();
        GiveItemsBack();
    }
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
                            holder.value =  null;
                            holder.amount = 0;
                        }
                    }
                }
            }
        }
    }
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
    void Checkforrecepies()
    {
        bool Everyitem = false;
        bool Itemthere = true;
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
                else
                {
                }
            }
            //Evey Item is used you can Craft
            Craft(Currentrecepie);
        }

    }
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
