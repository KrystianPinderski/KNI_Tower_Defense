using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour {

    [SerializeField]
    private string nameItem;
    public string NameItem
    {
        get
        {
            return nameItem;
        }
    }

    [SerializeField]
    private float gold;
    public float  Gold
    {
        get
        {
            return gold;
        }
    }

    [SerializeField]
    private float silver;
    public float Silver
    {
        get
        {
            return silver;
        }
    }

    [SerializeField]
    private float bronze;
    public float Bronze
    {
        get
        {
            return bronze;
        }
    }

    [SerializeField]
    private float money;
    public float Money
    {
        get
        {
            return money;
        }
    }



    [SerializeField]
    private float bulidTime;
    public float BulidTime
    {
        get
        {
            return bulidTime;
        }

        set
        {
            bulidTime = value;
        }
    }

    private int weightTower;
    public int WeightTower
    {
        get
        {
            return weightTower;
        }
        set
        {
            weightTower = value;
        }
    }

    private bool isActivate;
    public bool IsActivate
    {
        get
        {
            return isActivate;
        }
        set
        {
            isActivate = value;
        }
    }

    [SerializeField]
    private Range myRange;
    public Range MyRange
    {
        get
        {
            return myRange;
        }
    }



    // Use this for initialization
    public virtual void Start () {
        isActivate = true;
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   // public virtual void OnTriggerEnter(Collider other)
   // {
   //     if(other.gameObject.tag=="BulidItem" && other.GetComponent<Tower>().WeightTower>WeightTower)
   //     {
   //         StartCoroutine(ShowRedModel(other.gameObject));
            
   //     }
   // }

   //public virtual IEnumerator ShowRedModel(GameObject tmp)
   //{
   //     StopCoroutine(BuildSystem.Instance.startCreateTower);
   //     StartCoroutine(BuildSystem.Instance.ShowRedModel(tmp.GetComponent<Tower>()));
            
   //     tmp.GetComponent<Renderer>().material.color = Color.red;
   //     yield return new WaitForSeconds(tmp.GetComponent<Tower>().BulidTime/2);
   //     Destroy(tmp.transform.parent.gameObject);
   // }
}
