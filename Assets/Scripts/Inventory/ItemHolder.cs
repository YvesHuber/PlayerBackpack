using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemHolder : MonoBehaviour
{
    public Item _script;
    public int amount = 0;
    public GameObject img;
    Image image;
    public TextMeshProUGUI counter;
    public void AddItem(Item s)
    {
        _script = s;
        if (amount > 1 ){
        amount += s.StackSize - 1;
        }
        else {
            amount += s.StackSize;
        }
        Debug.Log("Added an Item");
        if (_script != null)
        {
            image = img.GetComponent<Image>();
            image.sprite = _script.UiIcon;
            var tempColor = image.color;
            tempColor.a = 1f;
            image.color = tempColor;
            if(amount > 1) {
            string am = amount.ToString();
            counter.text = am;
            }
        }
    }
}