using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class StateBar : MonoBehaviour {


    [SerializeField]
    private float speed;
    [SerializeField]
    private Image imageBar;

    [SerializeField]
    private float currentHealth;
    public float  CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
        }
    }
    [SerializeField]
    private float maxHealth;
    public float MaxHealth
    {
        get
        {
            return maxHealth;
        }
        set
        {
            maxHealth = value;
        }
    }

    // Use this for initialization
    void Start () {
        CurrentHealth = MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        imageBar.fillAmount= Mathf.Lerp(imageBar.fillAmount,CurrentHealth/MaxHealth, speed * Time.deltaTime);
	}
}
