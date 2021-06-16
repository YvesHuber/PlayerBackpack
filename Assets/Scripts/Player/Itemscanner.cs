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
    public Item Player;
    public Item Itemobject;
    public Itemvalue Scriptableobject;
    public TextMeshProUGUI textMesh;
    public TextMeshProUGUI FPS;
    // Start is called before the first frame update
    public GameObject canvasObject;
    public GameObject Equip;
    public GameObject Crafting;
    private Inventory inv;
    private bool UIEquipment = false;
    private bool UICrafting = false;
    float time = 0;

    void Update()
    {
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
            if (hit.collider.CompareTag("Enemy"))
            {
                Itemobject = Object.GetComponent<Item>();
                Scriptableobject = Itemobject.value;
                textMesh.text = Scriptableobject.DisplayTitle;
                if (Input.GetMouseButtonDown(0))
                {
                    float Damage = Player.Damage * Player.Strength;
                    //DMG
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
                if (rarval == 5) { textMesh.color = new Color(0, 0, 0, 255); }
                //Collect Item
                if (Input.GetKeyDown(KeyCode.E))
                {
                    inv = canvasObject.GetComponent<Inventory>();
                    if (inv.AddValue(Scriptableobject, false) == true)
                    {
                        GameObject.Destroy(Object);
                    }
                }
            }
            if (hit.collider.CompareTag("Crafting"))
            {
                Crafting crafting = Object.GetComponent<Crafting>();
                CraftingStation Station = crafting.Station;
                textMesh.text = Station.Name;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //deactivate other if on
                    if (UIEquipment == true)
                    {
                        SetUIActive(canvasObject, Equip, UIEquipment);
                    }
                    UICrafting = SetUIActive(canvasObject, Crafting, UICrafting);
                }
            }
            if (hit.collider.CompareTag("Breakable"))
            {
                Breakable breakable = Object.GetComponent<Breakable>();
                textMesh.text = breakable.Object.Name + " \n Requires " + breakable.Object.Breakeme + " to break";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    try
                    {
                        if (breakable.Checktools(inv.Equipslots[4]) == true || breakable.Checktools(inv.Equipslots[5]) == true)
                        {
                            if (breakable.checktime() == true)
                            {
                                //Get array of every random Item Pool
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
        // Show and Hide Inventory
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