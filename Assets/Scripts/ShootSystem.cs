using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{

    public float range = 50f; // zasięg broni
    private RaycastHit hit;
    Player player;
    public Animator gunAnimator;

    public GameObject gunPoint;
    public GameObject scathe;


    public GameObject target;
   // private Rect position;

    public Camera cam;  // główna kamera postaci
   // public Texture2D cross; //  tekstura celownika
   // public GameObject trafiony; // obiekt dziura po kuli // zależnie od tekstury

    void OnGUI()
    {
     //  GUI.DrawTexture(position, cross); // rysowanie celownika
    }
    void Start()
    {
       player = transform.GetComponent<Player>();
        //  position = new Rect((Screen.width - cross.width) / 2,   // ustawianie celownika
        //      (Screen.height - cross.height) / 2,
        //      cross.width,
        //      cross.height);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1")&& Player.Instance.CanAttack)
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                if (hit.transform.tag == "Enemy" && hit.distance < range) // tworzenie obiektu dziury po kuli
                {
                    // GameObject go;
                    //   go = Instantiate(trafiony, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal)) as GameObject; // klonowanie trafienia
                    //   Destroy(go, 5);
                    //Debug.Log("Trafiony");
                    //Control_Enemy enemy = hit.transform.GetComponent<Control_Enemy>();

                    target = hit.transform.gameObject;
                   
                    //Player player = transform.GetComponent<Player>();
                   // GameObject tmp = Instantiate(scathe, gunPoint.transform.position, Quaternion.identity);
                    //tmp.GetComponent<Scathe>().Instance(target.transform, 10f, player.Damage, null);
                   // target = null;
                    //gunAnimator.SetTrigger("Attack");
                    player.myAnimator.SetTrigger("Shoot");
                    StartCoroutine("Shoot");
                   
                }
                else if (hit.distance < range)
                {
                    //Debug.Log("Podlo");
                }
            }
        }
    }

    public void Attack()
    {
        Player player = transform.GetComponent<Player>();
        GameObject tmp = Instantiate(scathe, gunPoint.transform.position, Quaternion.identity);
        tmp.GetComponent<Scathe>().Instance(target.transform, 10f, player.Damage, null);
        target = null;
    }


    public  IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1);
        Player player = transform.GetComponent<Player>();
        target.GetComponent<Control_Enemy>().TakeDamage(0, player.transform, true);
        GameObject tmp = Instantiate(scathe, gunPoint.transform.position, Quaternion.identity);
        tmp.GetComponent<Scathe>().Instance(target.transform, 50f, player.Damage, null);
        target = null;
    }
}
