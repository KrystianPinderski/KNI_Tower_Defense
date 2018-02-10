using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour {

    [SerializeField]
    private float speedScathe;

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


        if(target!=null && timeduration >= timeAttack)
        {
            GameObject tmp = Instantiate(scathe, transform.position, Quaternion.identity);
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
}
