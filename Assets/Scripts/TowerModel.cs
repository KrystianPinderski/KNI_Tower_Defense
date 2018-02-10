using UnityEngine;
using System.Collections;

public class TowerModel : MonoBehaviour
{

    bool build = false;

    public void Update()
    {
        if (GetComponent<Renderer>().material.color== new Color32(158, 23, 0, 130))
        {
            BuildSystem.Instance.CanShoot = false;
        }
        else
        {
            BuildSystem.Instance.CanShoot = true;
        }
    }
  
    public void OnTriggerEnter(Collider other)
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = new Color32(158, 23, 0, 130);
    }
  
    public void OnTriggerStay(Collider other)
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = new Color32(158, 23, 0, 130);
    }
    public void OnTriggerExit(Collider other)
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = new Color32(38, 158, 0, 130);
    }

}
