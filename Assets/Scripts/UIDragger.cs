using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIDragger : MonoBehaviour
{

    public const string DRAGGABLE_TAG = "UIDraggable";
    public const string FASTBARSLOT_TAG = "UIFastBarSlot";


    private Transform objectToDrag;
    private Transform objectToDrop;
    public Transform itemHolder;
    ItemHolder ItemHolderScript;
    List<RaycastResult> hitObjects = new List<RaycastResult>();

    private void Start()
    {
        ItemHolderScript = itemHolder.GetComponent<ItemHolder>();
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            objectToDrag = GetDraggableTransformUnderMouse();
         
           
            if(objectToDrag!=null)
               ItemHolderScript.AddItem(objectToDrag.GetComponent<Slot_Inv>().item);
           
           


        }

        if (Input.GetMouseButtonUp(0))
        {
            objectToDrop=GetObjectUnderMouse().transform;
            if (objectToDrop != null&&objectToDrop.tag==FASTBARSLOT_TAG)
            {
                
                objectToDrop.GetComponent<Slot_Inv>().addItem(ItemHolderScript.getItem()) ;
                
            }
           
            ItemHolderScript.Clear();
                

        }
    }
    private GameObject GetObjectUnderMouse()
    {
        var pointer = new PointerEventData(EventSystem.current);

        pointer.position = Input.mousePosition;

        EventSystem.current.RaycastAll(pointer, hitObjects);

        if (hitObjects.Count <= 0) return null;
        return hitObjects[0].gameObject;

    }
    private Transform GetDraggableTransformUnderMouse()
    {
        GameObject clicedObject = GetObjectUnderMouse();
        
        if (clicedObject != null && clicedObject.tag == DRAGGABLE_TAG)
        {
           
            return clicedObject.transform;
        }
        return null;
    }
}
