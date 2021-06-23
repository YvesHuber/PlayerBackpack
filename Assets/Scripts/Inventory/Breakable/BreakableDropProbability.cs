using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Drop", menuName = "Drops/Breakable")]

public class BreakableDropProbability : ScriptableObject
{
    public Itemvalue Drops;
    public float Probabilty;
}
