using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScathe : MonoBehaviour {


    private Rigidbody myRigidboy;
    private Transform target;
    private float speed;
    private float damage;
    Vector3 targetdir;
    

    void Awake()
    {
        targetdir = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        myRigidboy = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 pos = targetdir;
        Vector3 dir = (this.transform.position - targetdir).normalized;
        Debug.DrawLine(pos, pos + dir * 10, Color.red, Mathf.Infinity);
        myRigidboy.velocity = targetdir;
        //transform.position = Vector3.MoveTowards(transform.position,, speed * Time.deltaTime);
    }

    public void Instance(Transform target, float speed, float damage, Range myTower)
    {
        this.target = target;
        this.speed = speed;
        this.damage = damage;
        this.targetdir = transform.position - target.position;
    }
}
