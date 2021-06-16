using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public BreakableObject Object;
    public float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= Object.Timebetweenbreaks)
        {
            timer = Object.Timebetweenbreaks;
        }
    }


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
    public Itemvalue[] returnItems()
    {
        Itemvalue[] RNGitems = new Itemvalue[64];
        int i = 0;
        int random = 0;
        foreach (Itemvalue value in Object.Drop100)
        {
            random = (int)Random.Range(0, 100);
            if (random <= 100)
            {
                RNGitems[i] = value;
                Debug.Log(value);
            }
            i++;
        }
        foreach (Itemvalue value in Object.Drop50)
        {
            random = (int)Random.Range(0, 100);
            if (random <= 50)
            {
                RNGitems[i] = value;
                Debug.Log(value);
            }
            i++;
        }
        foreach (Itemvalue value in Object.Drop20)
        {
            random = (int)Random.Range(0, 100);
            if (random <= 20)
            {
                RNGitems[i] = value;
                Debug.Log(value);
            }
            i++;
        }
        foreach (Itemvalue value in Object.Drop5)
        {
            random = (int)Random.Range(0, 100);
            if (random <= 5)
            {
                RNGitems[i] = value;
                Debug.Log(value);
            }
            i++;
        }
        foreach (Itemvalue value in Object.Drop1)
        {
            random = (int)Random.Range(0, 100);
            if (random <= 1)
            {
                RNGitems[i] = value;
                Debug.Log(value);
            }
            i++;
        }
        return RNGitems;

    }
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
