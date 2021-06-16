using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New CraftingStation", menuName ="Crafting/CraftingStation")]
public class CraftingStation : ScriptableObject{
    public string Name;

    public CraftingRecepie[] Recepies;

    public bool Saveitems;

    }
