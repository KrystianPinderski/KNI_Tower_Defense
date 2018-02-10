using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Create Item")]

public class Item : ScriptableObject 
{
	
	new public string name = "Name";
	public Sprite icon;

	virtual public void Use()
	{
		Debug.Log("Use object: "+name);
	}
    virtual public void UnUse()
    {
        Debug.Log("UnUse object: " + name);
    }

    //Dodana funckja
    virtual public  string GetInfo()
    {
        return null;
    }
}

	
