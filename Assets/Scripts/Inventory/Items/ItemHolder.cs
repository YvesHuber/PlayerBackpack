using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;
public class ItemHolder : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerExitHandler
{
    public Inventory inv;
    public Itemvalue value;
    public bool filled = false;
    public int amount = 0;
    public GameObject img;
    public bool Equipmentslot;
    public bool output;
    public bool preview;
    public TextMeshProUGUI hovertext;
    Image image;
    public TextMeshProUGUI counter;
    Image itemBeingDragged;
    Vector3 startPosition;
    GameObject Self;
    void Update()
    {
        counter.text = " ";
        image = img.GetComponent<Image>();
        if (value != null)
        {
            filled = true;
            image.sprite = value.UiIcon;
            var tempColor = image.color;
            tempColor.a = 1f;
            image.color = tempColor;
            if (amount > 1)
            {
                string am = amount.ToString();
                counter.text = am;
            }
        }
        else
        {
            filled = false;
            image.sprite = null;
            var tempColor = image.color;
            tempColor.a = 0f;
            image.color = tempColor;
        }
    }


    public void OnPointerEnter(PointerEventData eventData){
        if(value != null){
            hovertext.text =
            value.DisplayTitle + "\n"+
            value.Description + "\n" +
            value.Worth;
        }
    }
    public void OnPointerExit(PointerEventData eventData){
        hovertext.text = null;
    }    
    public void OnPointerDown(PointerEventData eventData) {
        if (filled == true && preview == false) 
        {
            if ((int)value.Itemtype >= 2 && output == false)
            {
                inv.Addarmor((int)value.Itemtype,transform.gameObject);
            }
            try {
            if((int)value.Itemtype >= 2 && Equipmentslot == true){
                if(inv.AddValue(value,true) == true){
                    value = null;
                }
            }
            }
            catch (Exception e){

            }
                
        }
    }
    public void AddItem(Itemvalue s)
    {
        value = s;
        if (amount > 1)
        {
            amount += s.StackSize - 1;
        }
        else
        {
            amount += s.StackSize;
        }
    }
        public void OnBeginDrag(PointerEventData eventData)
    {

        if (filled == true && preview == false) 
        {
            itemBeingDragged = image;
            startPosition = transform.position;
                
        }

    }
    public void OnDrag(PointerEventData eventData)
    {
        if (filled == true && preview == false)
        {
            transform.position = Input.mousePosition;
        }
    }
    public void OnDrop(PointerEventData enventData)
    {
        // Cant drop in specific Slots
        if (output == false && preview == false && Equipmentslot == false){
        Self = transform.gameObject;
        inv.checkslotandswitch(transform.position, Self);
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //check for collision
        if (filled == true && preview == false) 
        {
            itemBeingDragged = null;
            // if collision
            gameObject.transform.position = startPosition;
        }
    }
}