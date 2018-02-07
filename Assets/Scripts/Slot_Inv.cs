using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode]
public class Slot_Inv :MonoBehaviour
{
    public Item item;
    public Image image;
    public void Start()
    {
        transform.GetChild(0).GetComponent<Image>().raycastTarget = false;
        if(item!=null)
            image.sprite = item.icon;
      
    }
    public void addItem(Item item)
    {
        this.item = item;
        image.sprite = item.icon;
        image.enabled = true;
    }
    public void useItem()
    {
        if(item!=null)
            item.Use();
    }
    public void unUseItem()
    {
        if(item!=null)
         item.UnUse();
    }
}

