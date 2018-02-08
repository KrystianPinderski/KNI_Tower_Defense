using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[ExecuteInEditMode]
public class Slot_Inv :MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
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

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if(item!=null)
            InfoItem.Instnace.SetInfoPanel(true,item.GetInfo());
    }


    public void OnPointerExit(PointerEventData pointerEventData)
    {
        InfoItem.Instnace.SetInfoPanel(false,null);
    }


}

