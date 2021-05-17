using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private Stats stats;
    public Slider healthBar;
    private float HP;
    private float maxHP;
    private float hpregen;



    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
        maxHP = stats.maxHP;
        hpregen = stats.hpregen;
        HP = stats.hp;
        healthBar.maxValue = maxHP;
        healthBar.value = HP;
    }

    // Update is called once per frame
    void Update()
    {
        HP += 0.1f * Time.deltaTime;
        healthBar.value = HP;
        if (HP >= maxHP)
        {
            HP = maxHP;
        }

    }
}
