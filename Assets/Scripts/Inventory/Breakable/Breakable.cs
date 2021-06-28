using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Breakable : MonoBehaviour
{
    public BreakableObject Object;
    public float timer = 0;
    //update the timer
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= Object.Timebetweenbreaks)
        {
            timer = Object.Timebetweenbreaks;
        }
    }

    //check if the timer is Timebetweenbreaks 
    public bool checktime()
    {
        if (timer >= Object.Timebetweenbreaks)
        {
            timer = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
    //get an array of random items each with their own drop chance
    public List<Itemvalue> getitems()
    {
        List<Itemvalue> items = new List<Itemvalue>();

        foreach (BreakableDropProbability Drop in Object.Drops)
        {
            float random = Random.Range(0, 100);
            if (random <= Drop.Probabilty + 0.01)
            {
                items.Add(Drop.Drops);
            }
        }
        return items;
    }
    //check if the used tool is the same as the Breakablescriptableobjec
    public bool Checktools(GameObject ItemSlot)
    {
        ItemHolder holder = ItemSlot.GetComponent<ItemHolder>();
        Itemvalue value = holder.value;
        if ((int)value.Equiptype == (int)Object.Breakeme)
        {
            return true;
        }
        return false;
    }
}
