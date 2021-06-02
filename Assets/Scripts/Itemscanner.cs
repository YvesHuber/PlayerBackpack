using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Itemscanner : MonoBehaviour
{
    private GameObject Object = null;
    public Item Player;
    public Item _script;
    public TextMeshProUGUI textMesh;
    // Start is called before the first frame update
    public GameObject canvasObject;
    private Inventory _inv;
    private bool active = false;
    void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 3, Color.yellow);
        Object = null;
        _script = null;
        textMesh.text = null;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3))
        {
            if (hit.collider.CompareTag("Enemy")){
                Object = hit.transform.gameObject;
                _script = Object.GetComponent<Item>();
                textMesh.text = _script.DisplayTitle;
                if (Input.GetMouseButtonDown(0)){
                    float Damage = Player.Damage * Player.Strength;
                    //DMG
                }
            }
            if (hit.collider.CompareTag("Item"))
            {
                Object = hit.transform.gameObject;
                _script = Object.GetComponent<Item>();
                textMesh.text = _script.DisplayTitle;
                int rarval = (int)_script.rarity;
                if (rarval == 0) { textMesh.color = new Color(255, 255, 255, 255); }
                if (rarval == 1) { textMesh.color = new Color(0, 227, 0, 255); }
                if (rarval == 2) { textMesh.color = new Color(0, 0, 277, 255); }
                if (rarval == 3) { textMesh.color = new Color(186, 0, 254, 255); }
                if (rarval == 4) { textMesh.color = new Color(214, 0, 0, 255); }
                if (rarval == 5) { textMesh.color = new Color(0, 0, 0, 255); }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _inv = canvasObject.GetComponent<Inventory>();
                    _inv.AddValue(_script);
                    GameObject.Destroy(Object);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (active == false)
            {
                canvasObject.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                active = true;
            }
            else if (active == true)
            {
                canvasObject.SetActive(false);
                Cursor.visible = false;
                active = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }


    }
}