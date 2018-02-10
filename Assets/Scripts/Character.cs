using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    [SerializeField]
    private StateBar HealthBar;

   

    public float MyHealth
    {
        get
        {
            return HealthBar.CurrentHealth;
        }
    }
    //protected float myHealth;
    // Use this for initialization
    void Start()
    {

    }
	
	// Update is called once per frame
	public virtual void Update () {
       
        // myHealth = HealthBar.CurrentHealth;
    }

    public virtual void TakeDamage(float damage, Transform myTarget,bool playerAttack)
    {
        HealthBar.CurrentHealth -= damage;
        
        if (HealthBar.CurrentHealth<=0)
        {
            Death();
            
        }
    }

    public abstract void Death();
}
