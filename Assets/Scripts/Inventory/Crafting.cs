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
    void Start()
    {
        Submit.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        Debug.Log("I have been pressed");
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

    bool checkifequal(Itemvalue CheckItem)
    {
        for (int i = 0; i < Itemvalues.Length; i++)
        {
            if (Itemvalues[i] == CheckItem)
            {
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
                    if ( checkifequal(Item)){
                        Debug.Log(Item + "Is needed");
                    }
                }
                Debug.Log("Failed");
                
                Everyitem = true;
            }

        }
    }
