using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject Slot1;
    public ItemHolder _script;




    // Check for slot then Add item
    public void AddValue(Item s){
        _script = Slot1.GetComponent<ItemHolder>();
        _script.AddItem(s);
    }
}

