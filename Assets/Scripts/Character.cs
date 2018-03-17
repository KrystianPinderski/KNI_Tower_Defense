using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

    [SerializeField]
    private StateBar HealthBar;

    [SerializeField]
    private Animator animatorController;
    public Animator MyAnimatorController
    {
        get
        {
            return animatorController;
        }
    }

    public float MyHealth
    {
        get
        {
            return HealthBar.CurrentHealth;
        }
        set
        {
            HealthBar.CurrentHealth = value;
        }
    }
    //protected float myHealth;
    // Use this for initialization
    public virtual void Start()
    {
        if(GetComponent<Animator>()!=null)
        animatorController = GetComponent<Animator>();
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

    //Ustawienie danego layotu animacji ,reszta anulowana 
    public void SetLayerAnimation(int index)
    {
        for(int i=0;i<MyAnimatorController.layerCount;i++)
        {
            if(i!=index)
            {
                MyAnimatorController.SetLayerWeight(i, 0);
            }
            else
            {
                MyAnimatorController.SetLayerWeight(index, 1);
            }
        }
    }

    public abstract void Death();
}
