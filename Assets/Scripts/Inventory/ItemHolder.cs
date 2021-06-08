using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class ItemHolder : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Itemvalue value;
    public bool filled = false;
    public int amount = 0;
    public GameObject img;
    Image image;
    public TextMeshProUGUI counter;
    public  Image itemBeingDragged;
    Vector3 startPosition;


    public void OnBeginDrag(PointerEventData eventData){
        if (filled == true) {
        Debug.Log("Filled");
        itemBeingDragged = image;
        startPosition = transform.position;
        }
        else {
            Debug.Log("Not filled");
            return;
        }

    }
    public void OnDrag(PointerEventData eventData){
        if (filled == true) {
        transform.position = Input.mousePosition;
        }
    }
    public void OnEndDrag(PointerEventData eventData){
        //check for collision
        if (filled == true) {
        itemBeingDragged = null;
        if(GetComponent<Collider2D>().bounds.Contains(transform.position))
        {
            print("point is inside collider");
        }
        transform.position = startPosition;

        }

    }
    public void AddItem(Itemvalue s)
    {
        value = s;
        if (amount > 1 ){
        amount += s.StackSize - 1;
        }
        else {
            amount += s.StackSize;
        }
        Debug.Log("Added an Item");
        if (value != null)
        {
            filled = true;
            image = img.GetComponent<Image>();
            image.sprite = value.UiIcon;
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