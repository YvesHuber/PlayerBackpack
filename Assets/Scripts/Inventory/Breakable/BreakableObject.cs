using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[CreateAssetMenu(fileName = "BreakableObject", menuName = "BreakableObject")]
public class BreakableObject : ScriptableObject {

    public enum Type{Pickaxe,Axe,Hoe};
    public float Timebetweenbreaks;
    public string Name;
    public Type Tool; 
    [SerializeField]
    public List<BreakableDropProbability> Drops;
}