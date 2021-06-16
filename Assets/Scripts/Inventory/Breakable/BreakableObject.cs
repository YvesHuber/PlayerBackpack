using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BreakableObject", menuName = "BreakableObject")]
public class BreakableObject : ScriptableObject {

    public enum Type{Pickaxe,Axe,Hoe};
    public float Timebetweenbreaks;
    public string Name;
    public Type Breakeme; 
    public Itemvalue[] Drop100;
    public Itemvalue[] Drop50;
    public Itemvalue[] Drop20;
    public Itemvalue[] Drop5;
    public Itemvalue[] Drop1;
}