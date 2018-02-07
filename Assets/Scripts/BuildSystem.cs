using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.AI;

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
    private float hitRange=5f;

    private int countTower = 0;
    private bool canShoot=true;

    
    

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
        if (buildModel != null)
        {
            RaycastHit hit;
            Vector3 centerPosition = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
            Debug.DrawRay(centerPosition, fpsCam.transform.forward * hitRange, Color.red);

            if (Physics.Raycast(centerPosition, fpsCam.transform.forward, out hit, hitRange))
            {
                if (hit.collider.name == "Terrain")
                {
                    buildModel.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
                    buildModel.transform.position = hit.point;
                }
                else buildModel.transform.GetChild(0).GetComponent<Renderer>().enabled = false; 

            }
            else buildModel.transform.GetChild(0).GetComponent<Renderer>().enabled = false;

        }
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            RaycastHit hit;
            Vector3 centerPosition = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
            Debug.DrawRay(centerPosition, fpsCam.transform.forward * hitRange, Color.red);
          
            if(buildPrefab!=null)
                if (Physics.Raycast(centerPosition, fpsCam.transform.forward, out hit, hitRange))
                {
                    
                    if (hit.collider.name == "Terrain")
                    {
                        countTower++;
                     
                        GameObject tmp = (GameObject)Instantiate(buildPrefab, hit.point, Quaternion.identity);
                        Tower tmp_Tower = tmp.transform.GetChild(0).GetComponent<Tower>();
                        tmp_Tower.WeightTower = countTower;
                        startCreateTower = StartCoroutine(CreateObject(tmp_Tower));
                        //navMeshSurface.RemoveData();
                        //navMeshSurface.BuildNavMesh();
                    }
                }


        }
    }


    IEnumerator CreateObject(Tower tmp_Tower)
    {
        
        p.StopPlayerMove(true);
        canShoot = false;
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
        canShoot = true;
        sights.SetActive(true);
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
