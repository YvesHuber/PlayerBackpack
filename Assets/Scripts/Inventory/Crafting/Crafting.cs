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
    //on Button press
    void TaskOnClick()
    {
        pressed = true;
    }
    //check if an crafting recipe can be crafted and display a preview
    void Update()
    {
        //check if the recipe can be crafted
        foreach (CraftingRecipe recipe in Station.recipes)
        {
            if (recipe.canbecrafted == true)
            {
                Outputholder.value = recipe.Result;
                Outputholder.amount = 1;
                Outputholder.filled = false;
            }
        }
        //reset the field after the item was taken out
        if (Outputholder.value == null)
        {
            pressed = false;
            Outputholder.filled = false;
            Outputholder.preview = true;
            Outputholder.output = false;
        }
        if (Outputholder.preview == true)
        {
            Outputholder.output = false;
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
            if (Outputholder.preview == false)
            {
                Inventory.AddValue(Outputholder.value, false);
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
    //check if any slot has the item
    bool CheckeveryslotforItem(Itemvalue Item)
    {
        foreach (GameObject Slot in CraftingSlots)
        {
            ItemHolder holder = Slot.GetComponent<ItemHolder>();
            if (holder.value == Item)
            {
                return true;
            }
        }
        return false;
    }
    //delete Item from the slot if the item is there
    void DeleteItemFromSlot(Itemvalue Item)
    {
        foreach (GameObject Slot in CraftingSlots)
        {
            ItemHolder holder = Slot.GetComponent<ItemHolder>();
            if (holder.value == Item)
            {
                holder.amount -= 1;
                if (holder.amount <= 1)
                {
                    holder.value = null;
                }
            }
        }
    }

    // check if the item is used in an recipe
    bool CheckRecepie(CraftingRecipe recipe, bool multipleitems)
    {
        if (multipleitems == true)
        {
            int t = 0;
            foreach (Itemvalue Item in recipe.Itemvalues)
            {
                if (!CheckeveryslotforItem(Item))
                {
                    return false;
                }
            }
            return true;
        }
        else
        {
            bool singlefound = false;
            bool singledifferentfound = false;
            foreach (Itemvalue Item in recipe.Itemvalues)
            {
                for (int i = 0; i < 4; i++)
                {
                    try
                    {
                        ItemHolder current = CraftingSlots[i].GetComponent<ItemHolder>();
                        if (current.value != null)
                        {
                            if (current.value != Item)
                            {
                                singledifferentfound = true;
                            }
                            if (current.value == Item && singlefound != true)
                            {
                                singlefound = true;
                            }
                            else if (current.value == Item && singlefound == true)
                            {
                                singledifferentfound = true;
                            }
                        }
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
            if (singlefound == true && singledifferentfound == false)
            {
                return true;
            }
            else if (singlefound == true && singledifferentfound == true)
            {
                return false;
            }
            return false;
        }

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
    //check if an recipe is craftable
    void Checkforrecepies()
    {
        bool OneRecepie = false;
        if (Outputholder.amount < 1)
        {
            Outputholder.value = null;
        }
        //get Recepie
        foreach (CraftingRecipe Currentrecepie in Station.recipes)
        {
            bool multipleitems = false;
            Currentrecepie.canbecrafted = false;
            if (Currentrecepie.Itemvalues.Length > 1)
            {
                multipleitems = true;
            }

            Currentrecepie.canbecrafted = CheckRecepie(Currentrecepie, multipleitems);
            //Evey Item is used you can Craft
            if (Currentrecepie.canbecrafted == true)
            {
                OneRecepie = true;
                Outputholder.output = true;
                Craft(Currentrecepie);

            }
        }
        if (OneRecepie != true && Outputholder.output != true)
        {
            Outputholder.value = null;
        }

    }
    //craft is button is pressed
    //remove all items
    //output can be grabed
    void Craft(CraftingRecipe recipe)
    {

        if (pressed == true)
        {
            foreach (Itemvalue Item in recipe.Itemvalues)
            {
                DeleteItemFromSlot(Item);
            }
            Outputholder.filled = true;
            pressed = false;
            Outputholder.preview = false;
            for (int i = 0; i < Itemvalues.Length; i++)
            {
                Itemvalues[i] = null;
            }
        }
    }
}
