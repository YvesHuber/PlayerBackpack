using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Drop", menuName = "Drops")]

public class DropObjectProbability : ScriptableObject
{
    public GameObject Object;
    public float Probabilty;
}
