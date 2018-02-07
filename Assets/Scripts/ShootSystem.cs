using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{

    public float range = 50f; // zasięg broni
    private RaycastHit hit;
    private Rect position;

    public Camera cam;  // główna kamera postaci
    public Texture2D cross; //  tekstura celownika
    public GameObject trafiony; // obiekt dziura po kuli // zależnie od tekstury

    void OnGUI()
    {
       GUI.DrawTexture(position, cross); // rysowanie celownika
    }
    void Start()
    {
        position = new Rect((Screen.width - cross.width) / 2,   // ustawianie celownika
            (Screen.height - cross.height) / 2,
            cross.width,
            cross.height);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                if (hit.transform.tag == "Enemy" && hit.distance < range) // tworzenie obiektu dziury po kuli
                {
                    GameObject go;
                    go = Instantiate(trafiony, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal)) as GameObject; // klonowanie trafienia
                    Destroy(go, 5);
                    Debug.Log("Trafiony");
                }
                else if (hit.distance < range)
                {
                    Debug.Log("Podlo");
                }
            }
        }
    }
}
