using UnityEngine;
using System.Collections;

public class SelectItem : MonoBehaviour
{

    private Slot_Inv[] slots;
    public GameObject slotsContainer;
    void Start()
    {
        slots = slotsContainer.GetComponentsInChildren<Slot_Inv>();
    }

    void Update()
    {
        //Tutaj sprawdzamy czy stać nas na budowanie wieży czy mamy wystarczająco dużo surowców ,jeśli nie to slot jest niedostępny 
        //i aktywuje się wtedy gdy mamy odpowiednio dużo surowców 

        foreach(Slot_Inv tmp in slots)
        {
           
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            slots[0].useItem();

            slots[1].unUseItem();
            slots[2].unUseItem();
            slots[3].unUseItem();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            slots[1].useItem();

            slots[0].unUseItem();
            slots[2].unUseItem();
            slots[3].unUseItem();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            slots[2].useItem();

            slots[1].unUseItem();
            slots[0].unUseItem();
            slots[3].unUseItem();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            slots[3].useItem();

            slots[2].unUseItem();
            slots[1].unUseItem();
            slots[0].unUseItem();
        }
    }
    //Tutaj będzie wybieranie itemu np. Jęsli naciśnięto Num1 to slots[0].useItem(); i tak dalej
    //Reszta slotów (te które nie są wybrane) dla nich wywyołujemy metodę slots[x].unUseItem();
    //
    //Metody są w skrypcie Slot_Inv
}
