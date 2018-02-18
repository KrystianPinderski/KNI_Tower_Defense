using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : Character {


    [SerializeField]
    private float speed;
    [SerializeField]
    private float sensitive;
    [SerializeField]
    private float speedJump;
    [SerializeField]
    private float downspeedJump;


    




    public float RangeShoot;
    public float Damage = 50f;
    public float timeShoot;

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
    void Start () {
        
        characterController = GetComponent<CharacterController>();
       
        
	}
	
	// Update is called once per frame
	public   override void Update () {
       
        base.Update();
        ApplyGravity();
        GetInput();
       
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

        characterController.Move(direction * Time.deltaTime);
        transform.Rotate(0,mouseX,0);

        yRotCounter += mouseY * 100.0f *Time.deltaTime;
        yRotCounter = Mathf.Clamp(yRotCounter, -45f, 45f);
        camera.transform.localEulerAngles = new Vector3(-yRotCounter,0,0);
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
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
        base.TakeDamage(damage,null,false);
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
}
