using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private Stats stats;
    public Slider healthBar;



    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
        
        healthBar.value = stats.hp;
    }

    // Update is called once per frame
    void Update()
    {
        stats.hp += 0.1f * Time.deltaTime;
        healthBar.value = stats.hp;
        if (stats.hp >= stats.maxHP)
        {
            stats.hp =stats.maxHP;
        }
        healthBar.maxValue = stats.maxHP;

    }
}
