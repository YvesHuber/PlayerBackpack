using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;
public class Itemscanner : MonoBehaviour
{
    private GameObject Object = null;
    public Stats Player;
    public Item Itemobject;
    public Itemvalue Scriptableobject;
    public TextMeshProUGUI textMesh;
    public TextMeshProUGUI FPS;
    public TextMeshProUGUI Enemytext;
    public Slider Enemyhealthbar;
    public TextMeshProUGUI StationText;
    public GameObject canvasObject;
    public GameObject Equip;
    public GameObject Crafting;
    private Inventory inv;
    private bool UIEquipment = false;
    private bool UICrafting = false;
    float enemytimer = 5;

    float time = 0;

    void Update()
    {
        enemytimer += Time.deltaTime;
        Enemyhealthbar.gameObject.SetActive(false);
        if (enemytimer <= 5){
        Enemyhealthbar.gameObject.SetActive(true);
        }
        // FPS counter
        float fps = 1.0f / Time.deltaTime;
        if (time > 1f)
        {
            fps = Mathf.Floor(fps);
            FPS.text = fps.ToString() + "FPS";
            time = 0f;
        }
        time += Time.deltaTime;
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 3, Color.yellow);
        Object = null;
        Itemobject = null;
        Scriptableobject = null;
        textMesh.text = null;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3))
        {
            Object = hit.transform.gameObject;
            //if lazer hits enemy set the text to the name
            if (hit.collider.CompareTag("Enemy"))
            {

                Enemy enemy = Object.GetComponent<Enemy>();
                Enemyhealthbar.gameObject.SetActive(true);
                enemytimer = 0;
                EnemyObject enemyobject = enemy.Object;
                Enemytext.text = enemyobject.Name;
                Enemyhealthbar.maxValue = enemy.Maxhp;
                Enemyhealthbar.value = enemy.Hp;
                textMesh.color = new Color(255, 40, 40, 255);
                //if left mouse is pressed
                if (Input.GetMouseButtonDown(0))
                {
                    //calculate damage and deal it to the enemy
                    float Damage = Player.Damage * Player.Strength;
                    enemy.doDamage(Damage);
                }
            }
            if (hit.collider.CompareTag("Item"))
            {
                Itemobject = Object.GetComponent<Item>();
                Scriptableobject = Itemobject.value;
                textMesh.text = Scriptableobject.DisplayTitle;
                //Get rarity and change the color of the Text
                int rarval = (int)Scriptableobject.rarity;
                if (rarval == 0) { textMesh.color = new Color(255, 255, 255, 255); }
                if (rarval == 1) { textMesh.color = new Color(0, 227, 0, 255); }
                if (rarval == 2) { textMesh.color = new Color(0, 0, 277, 255); }
                if (rarval == 3) { textMesh.color = new Color(186, 0, 254, 255); }
                if (rarval == 4) { textMesh.color = new Color(214, 0, 0, 255); }
                //Collect Item
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //get inventory
                    inv = canvasObject.GetComponent<Inventory>();
                    //if Item is added destroy it
                    if (inv.AddValue(Scriptableobject, false) == true)
                    {
                        GameObject.Destroy(Object);
                    }
                }
            }
            //lazer hits Crafting set the text to the name
            if (hit.collider.CompareTag("Crafting"))
            {

                Crafting crafting = Object.GetComponent<Crafting>();
                crafting.enabled = true;
                CraftingStation Station = crafting.Station;
                textMesh.text = Station.Name;
                textMesh.color = new Color(255, 255, 255, 255);
                StationText.text = Station.Name;
                //if the player presses E
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //deactivate other UI if on and set UI actibe
                    if (UIEquipment == true)
                    {
                        SetUIActive(canvasObject, Equip, UIEquipment);
                    }
                    UICrafting = SetUIActive(canvasObject, Crafting, UICrafting);
                }
            }
            //Lazer hits a breakable set the text to the name and display the tool
            if (hit.collider.CompareTag("Breakable"))
            {
                textMesh.color = new Color(255, 255, 255, 255);
                Breakable breakable = Object.GetComponent<Breakable>();
                textMesh.text = breakable.Object.Name + " \n Requires " + breakable.Object.Breakeme + " to break";
                //presses E
                if (Input.GetKeyDown(KeyCode.E))
                {
                    try
                    {
                        //check the tool
                        if (breakable.Checktools(inv.Equipslots[4]) == true || breakable.Checktools(inv.Equipslots[5]) == true)
                        {
                            //if the timer is ready
                            if (breakable.checktime() == true)
                            {
                                //Get array of every random item pool and add it
                                Itemvalue[] alldrops = breakable.returnItems();
                                foreach (Itemvalue Dropeditem in alldrops){inv.Addbreakable(Dropeditem);}
                                

                            }
                        }
                    }
                    catch (Exception e)
                    {

                    }
                }

            }
        }
        // Show and Hide Inventory with I 
        if (Input.GetKeyDown(KeyCode.I))
        {
            //deactivate other if on
            if (UICrafting == true)
            {
                SetUIActive(canvasObject, Crafting, UICrafting);
            }
            UIEquipment = SetUIActive(canvasObject, Equip, UIEquipment);
        }


    }
    // Set 2 UI items active
    bool SetUIActive(GameObject one, GameObject two, bool active)
    {

        if (active == false)
        {
            one.SetActive(true);
            two.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            active = true;
        }
        else if (active == true)
        {
            one.SetActive(false);
            two.SetActive(false);
            Cursor.visible = false;
            active = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        return active;
    }
}