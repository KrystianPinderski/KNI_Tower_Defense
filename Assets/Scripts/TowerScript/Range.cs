using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour {

    [SerializeField]
    private float speedScathe;

    private bool isActivate;
    public bool IsActivate
    {
        get
        {
            return isActivate;
        }
        set
        {
            isActivate = value;
        }
    }

    [SerializeField]
    private float timeAttack;

    private float timeduration;

    private Queue<Transform> enemyQueue;

    public Queue<Transform> EnemyQueue
    {
        get
        {
            return enemyQueue;
        }
    }

    private Transform target;

    public GameObject gunObjectTower;

    [SerializeField]
    private GameObject scathe;
    [SerializeField]
    private float damge;
    public float Damge
    {
        get
        {
            return damge;
        }
    }

	// Use this for initialization
	void Start () {
        enemyQueue = new Queue<Transform>();
        
	}
	
	// Update is called once per frame
	void Update () {
        timeduration += Time.deltaTime;
        //Tutaj zmiana
       
         if (target!= null && IsActivate)
        {
            gunObjectTower.transform.LookAt(target);
        }
       
        if (target!=null && timeduration >= timeAttack && IsActivate)
        {
  
            GameObject tmp = Instantiate(scathe, gunObjectTower.transform.GetChild(2).position, Quaternion.identity);
            tmp.GetComponent<Scathe>().Instance(target, speedScathe, damge, this);
            timeduration = 0;
        }
        if(target==null && enemyQueue.Count>0)
        {
            target = enemyQueue.Dequeue();
        }
        
		
        
	}

    public void GetNextTarget()
    {
        target = null;
    }
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyQueue.Enqueue(other.transform);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
           
                target = null;
            
        }
    }


    public void Rotation()
    {

        if (target != null)
        {
            Vector3 targetDir = target.transform.position - gunObjectTower.transform.position;
            //targetDir.y = gunObjectTower.transform.position.y;
            targetDir.x = gunObjectTower.transform.position.x;
            targetDir.z = gunObjectTower.transform.position.z;
            float step = 1f * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(gunObjectTower.transform.forward, targetDir, step, 0.5F);
            gunObjectTower.transform.rotation = Quaternion.LookRotation(newDir);
        }
       
    }
}
