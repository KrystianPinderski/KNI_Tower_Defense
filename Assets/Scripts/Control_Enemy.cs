using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System;

public class Control_Enemy : Character {

	[Header("Speed - Move Mobs")]
	public float speed = 0.50f;
	public GameObject nexus;


    public GameObject imageBar;
    public Transform MyTarget;
    public float AttackRange=4f;
    public float EnemyDamage=5f;
    public float PatrolRange = 5f;
    public GameObject PatrolPoint;
    public Transform leftPatrolPoint;
    public Transform rightPatrolPoint;

    public NavMeshAgent navMeshAgent;

    private EInterface enemyInterface;


    
    public  Transform player;

    void Awake()
    {
        nexus = GameObject.FindGameObjectWithTag("Nexus");
        player = FindObjectOfType<Player>().GetComponent<Transform>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(nexus.transform.position);
        ChangeState(new DefaultState());
    }

	void Start () 
	{

       
        
       
    }
	

	public override void  Update ()
    {
        enemyInterface.OnUpdate();
        imageBar.transform.eulerAngles=new Vector3(imageBar.transform.eulerAngles.x, player.transform.eulerAngles.y, imageBar.transform.eulerAngles.z);
	}

	void OnTriggerEnter(Collider _col)
	{
		if (_col.gameObject.tag.Equals ("Nexus"))
		{
			Destroy(this.gameObject);
			//print ("Destroy: "+this.gameObject.name);
			_col.gameObject.GetComponent<Manager_Nexus> ().TakeDamage ();
		}
	}

    public override void TakeDamage(float damage,Transform myTarget,bool playerAttack)
    { 
        if (playerAttack && (enemyInterface is DefaultState))
        {
            this.MyTarget = myTarget;
        }
        base.TakeDamage(damage,myTarget,playerAttack);
    }


    public void ChangeState(EInterface newState)
    {

        if(enemyInterface != null)
        {
            enemyInterface.OnExit();
        }

        enemyInterface = newState;
        enemyInterface.OnEnter(this);
    }

    public override void Death()
    {
        Instantiate(MaterialManager.Instance.InstantiateMaterial(), transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
