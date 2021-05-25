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
    Image mage;
    public TextMeshProUGUI counter;
    public void AddItem(Item s){

        if (_script != s) {
        _script = s;
        amount = s.StackSize;
        }
        if (_script != null){
        mage = img.GetComponent<Image>();
        mage.sprite = _script.UiIcon;
        string am = amount.ToString();
        counter.text = am;
    }
}
}