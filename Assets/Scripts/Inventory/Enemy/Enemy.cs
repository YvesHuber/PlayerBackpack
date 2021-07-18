using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
using System.Linq;
public class Enemy : MonoBehaviour
{
    public EnemyObject Object;
    public float Maxhp;
    public float Hp;
    public float Attack;
    public float Defense;

    void Start()
    {
        Maxhp = Object.Hp;
        Hp = Object.Hp;
        Attack = Object.Attack;
        Defense = Object.Defense;
    }

    //get the damage and if the hp is 0 destroy self and spawn items
    public void doDamage(float value)
    {
        Debug.Log(value + "dealt damage");
        Hp -= value;
        if (Hp <= 0)
        {
            Destroy(this.gameObject);
            ondeath();
        }
    }
    //get the random items and instatiate them all
    public void ondeath()
    {
        List<GameObject> Itemstospawn =  getitems();

        try
        {
            
            foreach (GameObject prefab in Itemstospawn)
            {
                Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
            }
            
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        
    }
    //get the random items of each array
    public List<GameObject> getitems(){
        List<GameObject> items = new List<GameObject>();

        foreach(DropObjectProbability Drop in Object.Spawnitems){
            float random = Random.Range(0,100);
            if (random <= Drop.Probabilty + 0.01){
                items.Add(Drop.Object);
            }
        }
        return items;
    }
}
