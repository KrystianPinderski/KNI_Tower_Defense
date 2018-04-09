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
    public float AttackRange=2f;
    public float EnemyDamage=5f;
    public float PatrolRange = 10f;
    public GameObject PatrolPoint;
    public Transform leftPatrolPoint;
    public Transform rightPatrolPoint;

    public Boolean open;
    public Boolean close;

    public NavMeshAgent navMeshAgent;

    private EInterface enemyInterface;


    
    public  Transform player;

    void Awake()
    {
        open = false;
        close = false;
        imageBar.SetActive(true); //false
        nexus = GameObject.FindGameObjectWithTag("Nexus");
        player = FindObjectOfType<Player>().GetComponent<Transform>();
        navMeshAgent =transform.parent.GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(nexus.transform.position);
        ChangeState(new DefaultState());
    }

	public override void Start () 
	{
       
        base.Start();
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
            Player.Instance.MyHealth -= EnemyDamage ;
            Player.Instance.MyShieldBar -= 2.5f;
            Player.Instance.MyShoeBar -= 2.5f;
            Player.Instance.MySwordBar -= 2.5f;

            MyGameManager.Instance.EnemyDeath += 1;
            Destroy(this.gameObject.transform.parent.gameObject);
            //print ("Destroy: "+this.gameObject.name);
            _col.gameObject.GetComponent<Manager_Nexus> ().TakeDamage ();
		}
	}

    void OnTriggerExit(Collider _col)
    {
        if(_col.tag=="Gate"&& tag== "ModelEnemy")
        {
            imageBar.SetActive(true);
            tag = "Enemy";
            _col.GetComponent<Gate>().ResetValue(); 
        }
    }

    public override void TakeDamage(float damage,Transform myTarget,bool playerAttack)
    {
        MyAnimatorController.SetTrigger("TakeDamage");
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
        MyGameManager.Instance.EnemyDeath += 1;
        Instantiate(MaterialManager.Instance.InstantiateMaterial(), transform.position, Quaternion.identity);
        Destroy(this.gameObject.transform.parent.gameObject);
    }
}
