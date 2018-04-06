using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scathe : MonoBehaviour {

    private Transform target;
    private float speed;
    private float damage;
    private Range myTower;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, target.position.y + 1.11f, target.position.z), speed * Time.deltaTime);
        }
        else
        {
            if(myTower!=null)
            myTower.GetNextTarget();//tutaj powiadomic wieze ze celu już nie ma  i bierzemy następne z kolejki
            Destroy(this.gameObject);
            
        }
    }

    public void Instance(Transform target,float speed,float damage,Range myTower)
    {
        this.target = target;
        this.speed = speed;
        this.damage = damage;
        this.myTower = myTower;
        
    }
    
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="Enemy")
        {
            
            if(other.transform.GetComponent<Character>().MyHealth-damage<=0 && myTower != null)
            {
                myTower.GetNextTarget();//tutaj powiadomic wieze ze cel zniszczony i wziaść nastepne z kolejki
            }
            other.transform.GetComponent<Character>().TakeDamage(damage,null,false);
            Destroy(this.gameObject);
        }
    }
}
