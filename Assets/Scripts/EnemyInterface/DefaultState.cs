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

        rotation += Time.deltaTime;
        myEnemy.transform.eulerAngles = new Vector3(myEnemy.transform.eulerAngles.x, Mathf.Lerp(myEnemy.transform.eulerAngles.y, myEnemy.nexus.transform.eulerAngles.y,rotation), myEnemy.transform.eulerAngles.z);
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

    }
}
