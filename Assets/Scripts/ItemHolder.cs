using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemHolder : MonoBehaviour
{

    private Item item;

    public bool empty = true;
    public void Clear()
    {
        item = null;
        empty = true;
        gameObject.GetComponent<Image>().enabled = false;
    }
    public void AddItem(Item item)
    {
        this.item = item;

        gameObject.GetComponent<Image>().sprite = item.icon;
        gameObject.GetComponent<Image>().enabled = true;

        empty = false;
    }
    public Item getItem()
    {
        return item;
    }

    private void Start()
    {
        gameObject.GetComponent<Image>().raycastTarget = false;
    }
    private void Update()
    {
        transform.position = Input.mousePosition;
    }
}
