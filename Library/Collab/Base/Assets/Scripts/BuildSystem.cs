using UnityEngine;
using System.Collections;

public class BuildSystem : MonoBehaviour
{
    //skrypt to budowania itemów przekazanych do pola buildPrefab
    //po naciśnięciu lewego przycisku myszy zostaje postawiony obiekt w miejscu w które wskazuje kamera
    //można użyć do tego raycast, raycasthit

    public GameObject buildPrefab;

    
    public Camera fpsCam;
    private float hitRange=5f;


    private void Start()
    {
        
    }
    void Update()
    {
      if(Input.GetMouseButtonDown(0))
      {
            RaycastHit hit;
            Vector3 centerPosition  = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f,0f));
            Debug.DrawRay(centerPosition, fpsCam.transform.forward* hitRange, Color.red);
            //W przyszłosci mozna sprawdzać czy nasz promien(hit) przechodzi przez jakieś miejsce przeznaczone na budowe wiezy
            // i jezeli miejsce jest puste to wtedy w to miejsce wybodowac wiezę  
            if(Physics.Raycast(centerPosition,fpsCam.transform.forward,out hit,hitRange))
            {
                if(hit.collider.name=="Terrain")
                {
                    Instantiate(buildPrefab, hit.point, Quaternion.identity);
                }
            }
            else
            {
               
            } 
            
      }  
    }
}
