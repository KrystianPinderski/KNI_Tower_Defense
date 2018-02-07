using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {


    public GameObject nexus;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(nexus.transform.position);
        Debug.Log(Vector3.Dot(nexus.transform.position - transform.position, transform.forward));
        

    }
}
