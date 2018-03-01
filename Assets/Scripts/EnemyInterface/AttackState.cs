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

        myEnemy.SetLayerAnimation(1);
    }

    public void OnUpdate()
    {
        Debug.Log(myEnemy.navMeshAgent.remainingDistance);
        myEnemy.navMeshAgent.SetDestination(myEnemy.MyTarget.position);
        rotation += Time.deltaTime;
        Rotation();
        remaingTime += Time.deltaTime;
        if(remaingTime>timerAttack)
        {
            myEnemy.MyAnimatorController.SetTrigger("CanAttack");
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
        myEnemy.SetLayerAnimation(0);
    }

    public void Attack()
    {
        player.TakeDamage(myEnemy.EnemyDamage, null, false);
    }


    public void Rotation()
    {
        
        Vector3 targetDir = myEnemy.MyTarget.position - myEnemy.transform.position;
        targetDir.y = myEnemy.transform.position.y;
        float step = 1f * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(myEnemy.transform.forward, targetDir, step, 0.0F);
        myEnemy.transform.rotation = Quaternion.LookRotation(newDir);

    }
}
