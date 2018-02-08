using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.EventSystems; // add PointerEventData

public class Manager_UI : MonoBehaviour{//, IPointerEnterHandler {

	public GameObject canvas_Menu_Items;
	private bool canvas_Switch_Active = false;

	private float offset_X;
	private float offset_Y;

	public GameObject[] slots; // No General Slot

	private Transform parent_Before;
	private GameObject temp_Item;
	private bool come_Back = false;

	void Start () {
		

		if (canvas_Menu_Items.activeSelf == false)
			print ("If you want to disable gameObject (one can): "+canvas_Menu_Items.name);
			else
		canvas_Menu_Items.SetActive (false);
	}
	

	void Update () {

		if (Input.GetKeyDown (KeyCode.I)) 
		{
                Metod_Active_Menu();
		}


		if (temp_Item != null) 
		{
			if (temp_Item.transform.parent.name.Equals("Canvas (Script)") && come_Back == true)
				temp_Item.transform.SetParent (parent_Before);
		}

	}

	public void Metod_Active_Menu()
	{
		canvas_Switch_Active=!canvas_Switch_Active;
		canvas_Menu_Items.SetActive (canvas_Switch_Active);
	}



	public void Begin_Drag(GameObject _Item)
	{
		come_Back = false;

		parent_Before = _Item.transform.parent ;

		offset_X = _Item.transform.position.x - Input.mousePosition.x;
		offset_Y = _Item.transform.position.y - Input.mousePosition.y;
		_Item.transform.SetParent (this.transform);

		_Item.GetComponent<CanvasGroup> ().blocksRaycasts = false;

		for (int i = 0; i < slots.Length; i++) 
		{
			if(slots[i].transform.childCount==1)
			slots[i].transform.GetChild(0).GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}
	}


	public void Drag(GameObject _Item)
	{

		_Item.transform.position = new Vector2 (Input.mousePosition.x + offset_X, Input.mousePosition.y + offset_Y);

	}

	public void End_Drag(GameObject _Item)
	{
		
		_Item.GetComponent<CanvasGroup> ().blocksRaycasts = true;

		for (int i = 0; i < slots.Length; i++) 
		{
			if(slots[i].transform.childCount==1)
				slots[i].transform.GetChild(0).GetComponent<CanvasGroup> ().blocksRaycasts = true;
		}
	
		temp_Item = _Item;
		come_Back = true;
	}


	/*

	public void OnPointerEnter(PointerEventData _data) //name metod - don't change (IPointerEnterHandler)
	{
		Debug.Log(_data.pointerCurrentRaycast.gameObject.name);
	}
	
	*/
}
