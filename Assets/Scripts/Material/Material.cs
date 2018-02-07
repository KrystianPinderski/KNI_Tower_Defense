using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Material : MonoBehaviour {



    
    public string nameMaterial;
    public float Price;
    public float value;
    public GameObject prefabMaterial;

    [SerializeField]
    private float howLong;
    private float currentTime=0f;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public virtual void  Update () {
        currentTime += Time.deltaTime;
        if(currentTime>=howLong)
        {
            Destroy(this.gameObject);
        }
	}


    public abstract void TakeMaterial();

}
