using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{

    private bool isVisible;

    // Update is called once per frame
    void Update()
    {

        isOpenInvetory();
        mouseState();

    }

    void changeVisible()
    {
        isVisible = !isVisible;
    }

    void isOpenInvetory()
    {
        if (Input.GetKeyDown(KeyCode.I))        //tutaj można dodać inne przyciski po których ma pojawić sie lub schować myszka
        {
            changeVisible();
        }
    }

    void mouseState()
    {
        if (!isVisible)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;


        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}