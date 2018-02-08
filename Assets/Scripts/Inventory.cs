using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour
{

    public GameObject inventoryUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(inventoryUI.active)
            {
                InfoItem.Instnace.SetInfoPanel(false, null);
            }
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            gameObject.GetComponent<UIDragger>().enabled = inventoryUI.activeSelf;
        }
           
    }
}
