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
    }

    public void OnUpdate()
    {
        myEnemy.navMeshAgent.SetDestination(myEnemy.transform.position);
        Debug.Log("PatrolState");
        remaingTime += Time.deltaTime;
        if(remaingTime > timerPatrol)
        {
            myEnemy.ChangeState(new DefaultState());
        }
        if(Patrol())
        {
            myEnemy.ChangeState(new WalkState());
        }

        if (whichside == 1)
        {
            myEnemy.transform.Rotate(0, 1f, 0);
        }
        else
        {
            myEnemy.transform.Rotate(0, -1f, 0);
        }
    }


    public void OnTriggerEnter()
    {

    }

    public void OnExit()
    {

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
}
