using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "New Recipe", menuName ="Crafting/CraftingRecipe")]
public class CraftingRecipe : ScriptableObject
{
    public CraftingStation Place;
    public Itemvalue[] Itemvalues;
    public Itemvalue Result;
    public bool canbecrafted;
}
