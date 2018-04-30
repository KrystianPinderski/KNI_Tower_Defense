using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Collections.Generic;

public class BuildSystem : MonoBehaviour
{

    private static BuildSystem instance;
    public static BuildSystem Instance
    {
        get
        {
            if(instance==null)
            {
                instance = FindObjectOfType<BuildSystem>();
            }
            return instance;
        }
    }

    Player p;

   [SerializeField]
    private GameObject Bar;

    [SerializeField]
    private Image castingBar;

    public GameObject buildPrefab;
    public GameObject buildModel;
    public GameObject sights;
    
    public Camera fpsCam;
    private float hitRange=12f;

    private int countTower = 0;
    private bool canShoot=true;

    public bool CanShoot
    {
        get
        {
            return canShoot;
        }

        set
        {
            canShoot = value;
        }
    }


    public Coroutine startCreateTower;

   
    public void setBuild(GameObject buildPrefab,GameObject buildModel)
    {
        if (this.buildModel != null)
            Destroy(this.buildModel.gameObject);
        this.buildPrefab = buildPrefab;
        this.buildModel = Instantiate(buildModel);
    }
    private void Start()
    {
        
        p = gameObject.transform.parent.GetComponent<Player>();
    }
    void Update()
    {
        
        if(Input.GetKey(KeyCode.Escape))
        {
            InfoItem.Instnace.SetInfoPanel2(false, null);
            buildModel.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
            buildModel = null;
            buildPrefab = null;
            
        }


        if (buildModel != null)
        {
            List<Renderer> rend = new List<Renderer>();
            for (int i = 0; i < buildModel.transform.childCount; i++)
            {
                if (buildModel.transform.GetChild(i).GetComponent<Renderer>() != null)
                    rend.Add(buildModel.transform.GetChild(i).GetComponent<Renderer>());
            }


            RaycastHit hit;
            Vector3 centerPosition = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
            Debug.DrawRay(centerPosition, fpsCam.transform.forward * hitRange, Color.red);

            if (Physics.Raycast(centerPosition, fpsCam.transform.forward, out hit, hitRange))
            {
                if (hit.collider.name == "Terrain")
                {
                    for (int i = 0; i < rend.Count; i++)
                        rend[i].enabled = true;
                    buildModel.transform.position = hit.point;
                }
                else
                {
                    for (int i = 0; i < rend.Count; i++)
                        rend[i].enabled = false;
                   
                }


            }
            else
            {
                for (int i = 0; i < rend.Count; i++)
                    rend[i].enabled = false;
               
            }
           

        }
        if (Input.GetMouseButtonDown(0) && CanShoot)
        {
            RaycastHit hit;
            Vector3 centerPosition = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
            Debug.DrawRay(centerPosition, fpsCam.transform.forward * hitRange, Color.red);
          
            if(buildPrefab!=null)
                if (Physics.Raycast(centerPosition, fpsCam.transform.forward, out hit, hitRange) && CanShoot)
                {
                    
                    if (hit.collider.name == "Terrain" && MaterialManager.Instance.HaveMaterials(buildPrefab.transform.GetChild(0).gameObject))
                    {
                        
                        countTower++;
                     
                        GameObject tmp = (GameObject)Instantiate(buildPrefab, hit.point, Quaternion.identity);
                        Tower tmp_Tower = tmp.transform.GetChild(0).GetComponent<Tower>();

                        MaterialManager.Instance.GetMaterial(tmp_Tower);
                        InfoItem.Instnace.SetInfoPanel2(false, string.Empty);

                        tmp_Tower.WeightTower = countTower;
                        startCreateTower = StartCoroutine(CreateObject(tmp_Tower));
                        Destroy(buildModel);
                        buildModel = null;
                        buildPrefab = null;


                    }
                }


        }
    }

    IEnumerator CreateObject(Tower tmp_Tower)
    {
        Player.Instance.myAnimator.SetTrigger("Idle");
        Player.Instance.myAnimator.SetTrigger("Build");
        p.StopPlayerMove(true);
        CanShoot = false;
        sights.SetActive(false);
        Bar.SetActive(true);
        float rate = 1 / tmp_Tower.BulidTime;
        float progress = 0f;
        castingBar.color = new Color32(44, 216, 81, 255);
        while (progress<=1)
        {
            castingBar.fillAmount = Mathf.Lerp(0, 1, progress);
            progress += rate * Time.deltaTime;
            yield return null;
        }
        p.StopPlayerMove(false);
        Bar.SetActive(false);
        CanShoot = true;
        tmp_Tower.SetActivateTower();
        sights.SetActive(true);
        Player.Instance.myAnimator.SetTrigger("NotBuild");
    }


    //public IEnumerator ShowRedModel(Tower tmp_Tower)
    //{
    //    Bar.SetActive(true);
    //    canShoot = false;
    //    sights.SetActive(false);
    //    float rate = 1 /(tmp_Tower.BulidTime/2);
    //    float progress = 0f;
    //    castingBar.color = new Color32(219, 45, 49, 255);
    //    while (progress <= 1)
    //    {
    //        castingBar.fillAmount = Mathf.Lerp(0, 1, progress);
    //        progress += rate * Time.deltaTime;
    //        yield return null;
    //    }
    //    canShoot = true;
    //    sights.SetActive(true);
    //    Bar.SetActive(false);
    //}


    
    }
