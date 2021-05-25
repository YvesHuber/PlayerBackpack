using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemHolder : MonoBehaviour
{
    public Item _script;
    public int amount;
    public GameObject img;
    Image image;
    public TextMeshProUGUI counter;
    public void AddItem(Item s)
    {
        Debug.Log(s + "Bevor");
        _script = s;
        Debug.Log(_script + " After " + s);
        amount = s.StackSize;
        if (_script != null)
        {
            image = img.GetComponent<Image>();
            image.sprite = _script.UiIcon;
            var tempColor = image.color;
            tempColor.a = 1f;
            image.color = tempColor;
            string am = amount.ToString();
            counter.text = am;
        }
    }
}