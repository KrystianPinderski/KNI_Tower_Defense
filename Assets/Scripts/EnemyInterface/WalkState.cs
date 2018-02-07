using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : EInterface {

    Control_Enemy myEnemy;
    float rotation;

    public void OnEnter(Control_Enemy enemy)
    {
        this.myEnemy = enemy;
        rotation = 0;
        myEnemy.navMeshAgent.speed = myEnemy.navMeshAgent.speed * 2;
    }

    public void OnUpdate()
    {
        rotation += Time.deltaTime;
        myEnemy.navMeshAgent.SetDestination(myEnemy.player.position);
        myEnemy.transform.eulerAngles = new Vector3(myEnemy.transform.eulerAngles.x, Mathf.Lerp(myEnemy.transform.eulerAngles.y, myEnemy.player.transform.eulerAngles.y, rotation), myEnemy.transform.eulerAngles.z);

        if (myEnemy.navMeshAgent.remainingDistance <= myEnemy.AttackRange && myEnemy.navMeshAgent.remainingDistance > 0 )
        {
            myEnemy.ChangeState(new AttackState());
        }


    }


    public void OnTriggerEnter()
    {

    }

    public void OnExit()
    {
        myEnemy.navMeshAgent.speed = myEnemy.navMeshAgent.speed / 2;
    }
}
