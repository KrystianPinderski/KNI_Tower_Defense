using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultState : EInterface {

    Control_Enemy myEnemy;
    float rotation;

    public void OnEnter(Control_Enemy enemy)
    {
        this.myEnemy = enemy;
        rotation = 0;
        myEnemy.MyTarget = null;
        myEnemy.navMeshAgent.SetDestination(myEnemy.nexus.transform.position);
       

        
    }

    public void OnUpdate()
    {

        myEnemy.MyAnimatorController.SetTrigger("DefaultWalk");
        rotation += Time.deltaTime;

        Rotation();

        myEnemy.navMeshAgent.SetDestination(myEnemy.nexus.transform.position);


        if (myEnemy.MyTarget!=null)
        {
            myEnemy.navMeshAgent.SetDestination(myEnemy.player.position);
            myEnemy.ChangeState(new WalkState());
        }
    }


    public void OnTriggerEnter()
    {

    }

    public void OnExit()
    {
        myEnemy.MyAnimatorController.ResetTrigger("DefaultWalk");
    }


    public void Rotation()
    {
        Vector3 targetDir = myEnemy.nexus.transform.position - myEnemy.transform.position;
        targetDir.y = myEnemy.transform.position.y;
        float step = 1f * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(myEnemy.transform.forward, targetDir, step, 0.0F);
        myEnemy.transform.rotation = Quaternion.LookRotation(newDir);

    }
}
