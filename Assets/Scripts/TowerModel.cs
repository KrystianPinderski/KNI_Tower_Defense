using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerModel : MonoBehaviour
{

    bool build = false;

    List<Renderer> rend = new List<Renderer>();
    public void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Renderer>() != null)
                rend.Add(transform.GetChild(i).GetComponent<Renderer>());
        }
    }


    public void Update()
    {
		if(rend.Count>0){
			
			if (rend[0].material.color== new Color32(158, 23, 0, 130))
			{
				BuildSystem.Instance.CanShoot = false;
			}
			else
			{
				BuildSystem.Instance.CanShoot = true;
			}
		}
       
    }
  

    public void OnTriggerEnter(Collider other)
    {
        for(int i=0;i<rend.Count;i++)
            rend[i].material.color= new Color32(158, 23, 0, 130);
        
    }
  
    public void OnTriggerStay(Collider other)
    {
        for (int i = 0; i < rend.Count; i++)
            rend[i].material.color = new Color32(158, 23, 0, 130);
      
    }
    public void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < rend.Count; i++)
            rend[i].material.color = new Color32(38, 158, 0, 130);
      
    }

}
