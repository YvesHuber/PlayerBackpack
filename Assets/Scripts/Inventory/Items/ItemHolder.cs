using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;
public class ItemHolder : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Inventory inv;
    public Itemvalue value;
    public bool filled = false;
    public int amount = 0;
    public GameObject img;
    public bool Equipmentslot;
    public bool output;
    public bool preview;
    Image image;
    public TextMeshProUGUI counter;
    Image itemBeingDragged;
    Vector3 startPosition;
    GameObject Self;
    //check the counter and image of the Slot
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
                string amountstr = amount.ToString();
                counter.text = amountstr;
            }
        }
        else
        {
            filled = false;
            image.sprite = null;
            var tempColor = image.color;
            tempColor.a = 0f;
            image.color = tempColor;
            amount = 0;
        }
    }
    //if the slot is clicked Add the Armor to the specific slot
    public void OnPointerDown(PointerEventData eventData) {
        if (filled == true && preview == false) 
        {
            try {
            if ((int)value.Itemtype == 1 && output == false){
                inv.Consume(transform.gameObject);
            }
            if ((int)value.Itemtype >= 2 && output == false)
            {
                inv.Addarmor((int)value.Itemtype,transform.gameObject);
            }
            
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
    //check the slot if it is dragable and set the startposition
    public void OnBeginDrag(PointerEventData eventData)
    {

        if (filled == true && preview == false) 
        {
            itemBeingDragged = image;
            startPosition = transform.position;
                
        }

    }
    //On drag set the Image position on the mouse if it is filled and not a preview
    public void OnDrag(PointerEventData eventData)
    {
        if (filled == true && preview == false)
        {
            transform.position = Input.mousePosition;
        }
    }
    //On drop check the slot and switch the items and amounts
    public void OnDrop(PointerEventData enventData)
    {
        // Cant drop in specific Slots
        if (preview == false && Equipmentslot == false){
        Self = transform.gameObject;
        inv.checkslotandswitch(transform.position, Self);
        }
    }
    //On end of drag put the Image to the startposition
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
    //set the amount of the Item in the slot
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
}