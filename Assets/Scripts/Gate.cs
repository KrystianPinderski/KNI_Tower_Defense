using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {

    [SerializeField]
    private Animator animatorController;
    float count = 0;
    // Use this for initialization


    void Start () {
        
        //startrotationparent = parent.rotation;
        //parent = transform.parent.transform;
    }
	
	// Update is called once per frame
	void Update () {

        Debug.Log(count);
        
	}

    public void OnTriggerEnter(Collider other)
    {
       
        if(other.tag=="ModelEnemy" )
        {
            if (other.GetComponent<Control_Enemy>() != null)
            {
                if (other.GetComponent<Control_Enemy>().open == false)
                {
                    other.GetComponent<Control_Enemy>().open = true;
                    if (count == 0)
                    {
                        animatorController.SetTrigger("Open");
                    }
                    count++;
                }
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
       
    }

    public void ResetValue()
    {
        count -= 1f;
        if (count == 0)
        {
            animatorController.SetTrigger("Close");
        }
    }

}

