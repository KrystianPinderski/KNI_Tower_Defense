using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour
{


    private static Inventory instance;
    public static Inventory Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Inventory>();
            }
            return instance;
        }
    }

    public bool IsOpen;
    public GameObject inventoryUI;
    public GameObject imageSlotItemUI;
    public GameObject inventoryUIText;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(inventoryUI.active)
            {
                InfoItem.Instnace.SetInfoPanel(false, null);
            }
            inventoryUIText.SetActive(!inventoryUIText.activeSelf);
            imageSlotItemUI.SetActive(!imageSlotItemUI.activeSelf);
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            IsOpen = inventoryUI.active;
            gameObject.GetComponent<UIDragger>().enabled = inventoryUI.activeSelf;
        }
           
    }
}
