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
        //if(item!=null)
            //image.sprite = item.icon;
      
    }
    public void addItem(Item item)
    {
        
        if (name == "SlotItemUse")
        {
            if(item.name== "Health1"&& MaterialManager.Instance.Value_Money >= 2)
            {
               
                Player.Instance.MyHealth += 1;
                MaterialManager.Instance.Value_Money += -2;
            }
            if (item.name == "Health2" && MaterialManager.Instance.Value_Money >= 3)
            {
                Player.Instance.MyHealth += 2;
                MaterialManager.Instance.Value_Money += -3;
            }
            if (item.name == "Health3" && MaterialManager.Instance.Value_Money >= 4)
            {
                Player.Instance.MyHealth += 3;
                MaterialManager.Instance.Value_Money += -4;
            }
            if (item.name == "Health4" && MaterialManager.Instance.Value_Money >= 5)
            {
                Player.Instance.MyHealth += 4;
                MaterialManager.Instance.Value_Money += -5;
            }
            if (item.name == "Gun1" &&  MaterialManager.Instance.Value_Money >= 2)
            {
                Player.Instance.Damage += 1;
                MaterialManager.Instance.Value_Money += -2;
            }
            if (item.name == "Gun2" && MaterialManager.Instance.Value_Money >= 3)
            {
                Player.Instance.Damage += 2;
                MaterialManager.Instance.Value_Money += -3;
            }
            if (item.name == "Gun3" && MaterialManager.Instance.Value_Money >= 4)
            {
                Player.Instance.Damage += 3;
                MaterialManager.Instance.Value_Money += -4;
            }
            if (item.name == "Gun4" && MaterialManager.Instance.Value_Money >= 5)
            {
                Player.Instance.Damage += 4;
                MaterialManager.Instance.Value_Money += -5;
            }
            if (item.name == "Shield1" && MaterialManager.Instance.Value_Money >= 2)
            {
                Player.Instance.DamageFromEnemy -= (1 / 10);
                MaterialManager.Instance.Value_Money += -2;
            }
            if (item.name == "Shield2" && MaterialManager.Instance.Value_Money >= 3)
            {
                Player.Instance.DamageFromEnemy -= (2 / 10);
                MaterialManager.Instance.Value_Money += -3;
            }
            if (item.name == "Shield3" && MaterialManager.Instance.Value_Money >= 4)
            {
                Player.Instance.DamageFromEnemy -= (3 / 10);
                MaterialManager.Instance.Value_Money += -4;
            }
            if (item.name == "Shield4" && MaterialManager.Instance.Value_Money >= 5)
            {
                Player.Instance.DamageFromEnemy -= (4 / 10);
                MaterialManager.Instance.Value_Money += -5;
            }
            if (item.name == "Shoe1" && MaterialManager.Instance.Value_Money >= 2)
            {
                Player.Instance.MySpeed += (1/10);
                MaterialManager.Instance.Value_Money += -2;
            }
            if (item.name == "Shoe2" && MaterialManager.Instance.Value_Money >= 3)
            {
                Player.Instance.MySpeed += (2 / 10);
                MaterialManager.Instance.Value_Money += -3;
            }
            if (item.name == "Shoe3" && MaterialManager.Instance.Value_Money >= 4)
            {
                Player.Instance.MySpeed += (3 / 10);
                MaterialManager.Instance.Value_Money += -4;
            }
            if (item.name == "Shoe4" && MaterialManager.Instance.Value_Money >= 5)
            {
                Player.Instance.MySpeed += (4 / 10);
                MaterialManager.Instance.Value_Money += -5;
            }
        }
        else
        {
            this.item = item;
            image.sprite = item.icon;
            image.enabled = true;
        }
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
        if(item!=null && transform.tag!="UIFastBarSlot"&& transform.parent.name!= "InventoryItemShop")
            InfoItem.Instnace.SetInfoPanel(true,item.GetInfo());
        if(transform.parent.name == "InventoryItemShop")
        {
            InfoItem.Instnace.SetInfoPanel(true, item.GetInfo());
        }
    }


    public void OnPointerExit(PointerEventData pointerEventData)
    {
        InfoItem.Instnace.SetInfoPanel(false,null);
    }


}

