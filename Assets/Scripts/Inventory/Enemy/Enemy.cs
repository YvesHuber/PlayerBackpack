using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyObject Object;
    public float Hp;
    public float Attack;
    public float Defense;

    void Start(){
    Hp = Object.Hp;
    Attack = Object.Attack;
    Defense = Object.Defense;
    }

    //get the damage and if the hp is 0 destroy self and spawn items
    public void doDamage(float value){
        Hp -= value;

        if (Hp <= 0){
            Destroy(this.gameObject);
            ondeath();
        }
    }
    //get the random items and instatiate them all
    public void ondeath(){
        GameObject[] Spawnitems = getItems();


        foreach (GameObject prefab in Spawnitems)
        {
            Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
        }
    }
    //get the random items of each array
    public GameObject[] getItems(){
        GameObject[] RNGitems = new GameObject[64];
        int i = 0;
        int random = 0;
        foreach (GameObject value in Object.Drop100)
        {
            random = (int)Random.Range(0, 100);
            if (random <= 100)
            {
                RNGitems[i] = value;
                Debug.Log(value);
            }
            i++;
        }
        foreach (GameObject value in Object.Drop50)
        {
            random = (int)Random.Range(0, 100);
            if (random <= 50)
            {
                RNGitems[i] = value;
                Debug.Log(value);
            }
            i++;
        }
        foreach (GameObject value in Object.Drop20)
        {
            random = (int)Random.Range(0, 100);
            if (random <= 20)
            {
                RNGitems[i] = value;
                Debug.Log(value);
            }
            i++;
        }
        foreach (GameObject value in Object.Drop5)
        {
            random = (int)Random.Range(0, 100);
            if (random <= 5)
            {
                RNGitems[i] = value;
                Debug.Log(value);
            }
            i++;
        }
        foreach (GameObject value in Object.Drop1)
        {
            random = (int)Random.Range(0, 100);
            if (random <= 1)
            {
                RNGitems[i] = value;
                Debug.Log(value);
            }
            i++;
        }
        return RNGitems;

    }
}
