using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "New Recepie", menuName ="Crafting/CraftingRecepie")]
public class CraftingRecepie : ScriptableObject
{
    public CraftingStation Place;
    public Itemvalue[] Itemvalues;
    public Itemvalue Result;
}
