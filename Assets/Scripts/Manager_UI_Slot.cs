using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Manager_UI_Slot : MonoBehaviour, IDropHandler {

	public Transform parent_Items_Panel_Content_1;

    //tu zakomentowałem
    //private GameObject item;

    public Item item;
	private GameObject slot;

	public void OnDrop(PointerEventData _eventData) //name metod - don't change (IDropHandler)
	{
		

		//item = _eventData.pointerDrag.gameObject;
		slot = this.gameObject;

		print (slot.transform.childCount);

		if (slot.transform.childCount == 1 && this.gameObject.name!="Panel - Content (1) (Script)") 
		{
			slot.transform.GetChild(0).gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;

			//slot.transform.GetChild(0).gameObject.transform.SetParent (parent_Items_Panel_Content_1.transform.GetChild(slot.transform.GetChild(0).gameObject.GetComponent<Item>().Get_Id()).transform); //old
			//item.transform.SetParent (this.transform); //new
			
		} 
		else
		{
			//item.transform.SetParent (this.transform);
		}

		//print ("Drop - Item name: " + item.name + ", Slot name: " + slot.name);


		if (slot.name.Equals ("Panel - Content (1) (Script)")) 
		{
			//item.transform.SetParent (slot.transform.GetChild(item.GetComponent<Item>().Get_Id()).transform);


		}

	}


}
