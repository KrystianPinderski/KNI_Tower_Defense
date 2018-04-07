using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Player : Character {


    public GameObject GunToWalk;
    public GameObject GunToBuild;

    public GameObject MlotToWalk;
    public GameObject MlotToBuild;



    [SerializeField]
    private StateBar ShoeBar;
    [SerializeField]
    private StateBar SwordBar;
    [SerializeField]
    private StateBar ShieldBar;

    public Animator myAnimator;



    public float MyShoeBar
    {
        get
        {
            return ShoeBar.CurrentHealth;
        }
        set
        {
            ShoeBar.CurrentHealth = value;
        }
    }

    public float MySwordBar
    {
        get
        {
            return SwordBar.CurrentHealth;
        }
        set
        {
            SwordBar.CurrentHealth = value;
        }
    }

    public float MyShieldBar
    {
        get
        {
            return ShieldBar.CurrentHealth;
        }
        set
        {
            ShieldBar.CurrentHealth = value;
        }
    }


    private static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Player>();
            }
            return instance;
        }
    }

    [SerializeField]
    private float speed;
    [SerializeField]
    private float sensitive;
    [SerializeField]
    private float speedJump;
    [SerializeField]
    private float downspeedJump;
    public bool CanAttack=true;

    public float MySpeed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }




    public float RangeShoot;
    public float Damage = 25f;
    public float timeShoot;

    public float DamageFromEnemy  = 5f;
    CharacterController characterController;

    private float moveLR; //get value of left-right 
    private float moveTB; //get value of top-bottom

    private float valueJump;

    private float mouseX;
    private float mouseY;

    private bool isJumped;
    float yRotCounter;

    public Camera camera;
   // private float hitRange;

    public Transform nexus;


    private bool stopPlayerMove = false;

    // Use this for initialization
    public override void Start () {
        base.Start();
       
        characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	public   override void Update () {
        base.Update();
        ApplyGravity();
        GetInput();

        if (CanAttack == true)
        Move(moveLR,moveTB);
       

    }
    public void StopPlayerMove(bool s)
    {
       
        stopPlayerMove = s;
     



    }
    public float getVelocity()
    {
       
        return gameObject.GetComponent<Rigidbody>().velocity.magnitude;
    }
    public static Vector3 RotatedForward(Quaternion rotation)
    {
        return 2f * new Vector3(
            rotation.x * rotation.z + rotation.w * rotation.y,
            rotation.y * rotation.z - rotation.w * rotation.x,
            0.5f - (rotation.x * rotation.x + rotation.y * rotation.y));
    }


    private void Move(float valueLR,float valueTB)
    {
        Vector3 direction=new Vector3(valueLR,valueJump ,valueTB);
        direction = transform.rotation * direction ;


      
            if (moveLR != 0f || moveTB != 0f)
            {
                myAnimator.ResetTrigger("Idle");
                myAnimator.SetTrigger("Run");
            }
            else
            {
                myAnimator.ResetTrigger("Run");
                myAnimator.SetTrigger("Idle");
            }
        
       
        characterController.Move(direction * Time.deltaTime);
        if (!Inventory.Instance.IsOpen)
        transform.Rotate(0,mouseX,0);

        yRotCounter += mouseY * 100.0f *Time.deltaTime;
        yRotCounter = Mathf.Clamp(yRotCounter, -45f, 45f);
        if(!Inventory.Instance.IsOpen)
        camera.transform.localEulerAngles = new Vector3(-yRotCounter,0,0);
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myAnimator.SetTrigger("Jump");
            isJumped = true;
            
        }
        //timeShoot += Time.deltaTime *  4;
        if (Input.GetMouseButton(1))
        {
            //Shoot();
           // timeShoot = 0f;
        }

        if (stopPlayerMove == false)
        {
            moveLR = Input.GetAxis("Horizontal") * speed;
            moveTB = Input.GetAxis("Vertical") * speed;


            mouseX = Input.GetAxis("Mouse X") * sensitive;
            mouseY = Input.GetAxis("Mouse Y") * sensitive;
        }
        else
        {
            moveLR = 0;
            moveTB = 0;
            mouseX = 0;
            mouseY = 0;
        }
            
        
     

       
    }

    private void ApplyGravity()
    {
        if(characterController.isGrounded)
        {
            if (!isJumped)
            {
                //Debug.Log("start1");
                valueJump = Physics.gravity.y;
            }
            else
            {
                valueJump = speedJump ;
                //Debug.Log("start2");
            }
        }
        else
        {
            valueJump += Physics.gravity.y + Time.deltaTime;
            valueJump = Mathf.Clamp(valueJump,downspeedJump,speedJump);
            isJumped = false;
        }
    }

    public override void TakeDamage(float damage, Transform myTarget, bool playerAttack)
    {
        base.TakeDamage(DamageFromEnemy, null,false);
    }

    /* public void Shoot()
     {

         RaycastHit hit;
         if(Physics.Raycast(camera.transform.position,camera.transform.forward,out hit,RangeShoot))
         {
             if(hit.transform.tag=="Enemy")
             {
                 Control_Enemy enemy = hit.transform.GetComponent<Control_Enemy>();
                 enemy.TakeDamage(Damage, this.transform, true);
             }
         }

     }*/


    public override void Death()
    {
        SceneManager.LoadScene(0);
        Destroy(this.gameObject);
       
    }



    
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Material")
        {
            MaterialManager.Instance.AddMaterial(other.GetComponent<Material>());
            Destroy(other.gameObject);
        }
    }


    public void ChangeShowrd()
    {
        MlotToBuild.SetActive(!MlotToBuild.active);
        MlotToWalk.SetActive(!MlotToWalk.active);
        GunToBuild.SetActive(!GunToBuild.active);
        GunToWalk.SetActive(!GunToWalk.active);
    }
}
