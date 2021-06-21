using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Enemy", menuName = "Enemy")]
public class EnemyObject : ScriptableObject
{
    public string Name;
    public float Hp;
    public float Attack;
    public float Defense;
    public GameObject[] Drop100;
    public GameObject[] Drop50;
    public GameObject[] Drop20;
    public GameObject[] Drop5;
    public GameObject[] Drop1;
}
