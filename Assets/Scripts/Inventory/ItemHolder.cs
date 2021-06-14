using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class ItemHolder : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Inventory inv;
    public Itemvalue value;
    public bool filled = false;
    public int amount = 0;
    public GameObject img;
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

        if (filled == true)
        {
            itemBeingDragged = image;
            startPosition = transform.position;
            if ((int)value.Itemtype >= 2)
            {
                inv.Addarmor((int)value.Itemtype,transform.gameObject);
                gameObject.transform.position = startPosition;
                return;
            }
            else
            {
                return;
            }
        }

    }
    public void OnDrag(PointerEventData eventData)
    {
        if (filled == true)
        {
            transform.position = Input.mousePosition;
        }
    }
    public void OnDrop(PointerEventData enventData)
    {
        Self = transform.gameObject;
        inv.checkslotandswitch(transform.position, Self);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //check for collision
        if (filled == true)
        {
            itemBeingDragged = null;
            // if collision
            gameObject.transform.position = startPosition;
        }
    }
}