using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{
    public CraftingStation Station;
    public Button Submit;
    public GameObject[] CraftingSlots;
    public Itemvalue[] Itemvalues = new Itemvalue[64];
    public GameObject Output;
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
    void Update() {
        if(Outputholder.value == null){
            Outputholder.filled = false;
            Outputholder.preview = true;
        }
        Slotdata();
        Checkforrecepies();
    }
    void Slotdata()
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
                    Itemvalues[i] = value;
                    i++;
                }
            }
        }
    }

    bool isitemfound(Itemvalue CheckItem)
    {
        for (int i = 0; i < Itemvalues.Length; i++)
        {
            if (Itemvalues[i] == CheckItem)
            {
                Itemvalues[i] = null;
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
                    if (!isitemfound(Item)){
                        return;

                    }else {
                    }
                }
                //Evey Item is used you can Craft
                Craft(Currentrecepie);
            }

        }
        void Craft(CraftingRecepie recepie){
            Outputholder.value = recepie.Result;
            Outputholder.amount = 1;
            Outputholder.filled = false;
            if (pressed == true){
                foreach(GameObject Slot in CraftingSlots){
                    ItemHolder holder = Slot.GetComponent<ItemHolder>();
                    holder.amount = 0;
                    holder.value = null;
                    Outputholder.filled = true;
                }
            }
        }
    }
