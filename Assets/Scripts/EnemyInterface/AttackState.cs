using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : EInterface {

    private float timerAttack=2f;
    private float remaingTime;
    float rotation;
    Control_Enemy myEnemy;
    private Player player;

    public void OnEnter(Control_Enemy enemy)
    {
        this.myEnemy = enemy;
        rotation = 0;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        remaingTime = timerAttack;
    }

    public void OnUpdate()
    {
        rotation += Time.deltaTime;
        myEnemy.navMeshAgent.SetDestination(myEnemy.player.position);
        myEnemy.transform.eulerAngles = new Vector3(myEnemy.transform.eulerAngles.x, Mathf.Lerp(myEnemy.transform.eulerAngles.y, myEnemy.player.transform.eulerAngles.y,rotation), myEnemy.transform.eulerAngles.z);
        remaingTime += Time.deltaTime;
        if(remaingTime>timerAttack)
        {
            Attack();//tutaj jest attack na przeciwnika 
            remaingTime = 0;
        }
        if ( myEnemy.navMeshAgent.remainingDistance > myEnemy.AttackRange + 1 )
        {
            myEnemy.ChangeState(new PatrolState());
        }      
    }


    public void OnTriggerEnter()
    {

    }

    public void OnExit()
    {

    }

    public void Attack()
    {
        player.TakeDamage(myEnemy.EnemyDamage, null, false);
    }
}
