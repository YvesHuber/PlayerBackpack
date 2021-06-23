using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "new Enemy", menuName = "Enemy")]
public class EnemyObject : ScriptableObject
{
    public string Name;
    public float Hp;
    public float Attack;
    public float Defense;
    
    [SerializeField]
    public List <DropObjectProbability> Spawnitems  = new List<DropObjectProbability>(); 

}
