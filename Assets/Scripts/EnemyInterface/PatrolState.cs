using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : EInterface {

    private float timerPatrol = 4f;
    private float remaingTime;
    float myValueRotation;
    private int whichside;//jezeli prawda to obraca sie w lewo jezeli falsz to obraca sie prawo

    Control_Enemy myEnemy;

    public void OnEnter(Control_Enemy enemy)
    {
        this.myEnemy = enemy;
        whichside = Random.Range(0, 2);
        remaingTime = 0;

        //myEnemy.SetLayerAnimation(0);
    }

    public void OnUpdate()
    {
        myEnemy.MyAnimatorController.SetTrigger("Patrol");
        Rotation();
        myEnemy.navMeshAgent.SetDestination(myEnemy.transform.position);
        remaingTime += Time.deltaTime;
        if(remaingTime > timerPatrol)
        {
            
            myEnemy.ChangeState(new DefaultState());
        }
        if(Patrol())
        {
           
            myEnemy.ChangeState(new WalkState());
        }

    }


    public void OnTriggerEnter()
    {

    }

    public void OnExit()
    {
        myEnemy.MyAnimatorController.ResetTrigger("Patrol");
    }

    public bool Patrol()
    {
        RaycastHit hit;
        if (Physics.Raycast(myEnemy.PatrolPoint.transform.position, myEnemy.PatrolPoint.transform.forward, out hit, myEnemy.PatrolRange) && hit.collider.tag=="Player")
        {
            return true;
        }
        return false;
    }


    public void Rotation()
    {

        Vector3 point = Vector3.zero;
        if(whichside==0)
        {
            point = myEnemy.leftPatrolPoint.position;
        }
        else
        {
            point = myEnemy.rightPatrolPoint.position;
        }
        Vector3 targetDir = point - myEnemy.transform.position;
        targetDir.y = myEnemy.transform.position.y;
        float step = 0.5f * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(myEnemy.transform.forward, targetDir, step, 0.0F);
        myEnemy.transform.rotation = Quaternion.LookRotation(newDir);
        newDir.y = myEnemy.PatrolPoint.transform.position.y;
        myEnemy.PatrolPoint.transform.rotation = Quaternion.LookRotation(newDir);
        

    }
}
