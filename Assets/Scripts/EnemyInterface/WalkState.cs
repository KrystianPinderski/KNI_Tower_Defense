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

        //myEnemy.SetLayerAnimation(0);
    }

    public void OnUpdate()
    {
        myEnemy.MyAnimatorController.SetTrigger("FastWalk");
        rotation += Time.deltaTime;
        myEnemy.navMeshAgent.SetDestination(myEnemy.player.position);

        Rotation();

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
        myEnemy.MyAnimatorController.ResetTrigger("FastWalk");
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
