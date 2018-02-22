using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoItem : MonoBehaviour {

    private static InfoItem instance;
    public static InfoItem Instnace
    {
        get
        {
            if(instance==null)
            {
                instance = GameObject.FindObjectOfType<InfoItem>();
            }
            return instance;
        }
    }

    [SerializeField]
    private GameObject infoImage;
    [SerializeField]
    private Vector2 offset;

    [SerializeField]
    private Text textsize;

    [SerializeField]
    private Text textable;


    [SerializeField]
    private GameObject infoImage2;

    [SerializeField]
    private Text textsize2;

    [SerializeField]
    private Text textable2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(infoImage.active)
        {
            infoImage.transform.position = new Vector3(Input.mousePosition.x+offset.x, Input.mousePosition.y+ offset.y, 0);
        }
	}

    public void SetInfoPanel(bool tmp,string information)
    {
        if (true)
        {
            textsize.text = information;
            textable.text = information;
        }
        else
        {
            textsize.text = string.Empty;
            textable.text = string.Empty;
        }  
         infoImage.SetActive(tmp);
    }

    public void SetInfoPanel2(bool tmp, string information)
    {
        if (true)
        {
            textsize2.text = information;
            textable2.text = information;
        }
        else
        {
            textsize2.text = string.Empty;
            textable2.text = string.Empty;
        }
        infoImage2.SetActive(tmp);
    }




}
