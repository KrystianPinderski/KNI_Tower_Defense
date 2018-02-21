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
        

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Wyswietlanie po wyborze klawisza 1 informacji o wybranej wiezy 
            InfoItem.Instnace.SetInfoPanel2(true,slots[0].item.GetInfo(false));

            slots[0].useItem();

            slots[1].unUseItem();
            slots[2].unUseItem();
            slots[3].unUseItem();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Wyswietlanie po wyborze klawisza 2 informacji o wybranej wiezy 
            InfoItem.Instnace.SetInfoPanel2(true, slots[1].item.GetInfo(false));

            slots[1].useItem();

            slots[0].unUseItem();
            slots[2].unUseItem();
            slots[3].unUseItem();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //Wyswietlanie po wyborze klawisza 3 informacji o wybranej wiezy 
            InfoItem.Instnace.SetInfoPanel2(true, slots[2].item.GetInfo(false));

            slots[2].useItem();

            slots[1].unUseItem();
            slots[0].unUseItem();
            slots[3].unUseItem();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {

            //Wyswietlanie po wyborze klawisza 3 informacji o wybranej wiezy 
            InfoItem.Instnace.SetInfoPanel2(true, slots[3].item.GetInfo(false));

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
