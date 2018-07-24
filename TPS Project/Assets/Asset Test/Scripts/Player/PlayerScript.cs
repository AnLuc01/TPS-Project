using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    public Animator Anim;
    public GameObject cam;
    public bool enteringCar;
    public bool isCloseToCar = false;
    public Terrain ter;
    public bool enteredCar;
    public bool isInCar;
    public Image Crosshair;
    public bool exitingCar;
    public Rigidbody rb;

    void getInCar()
    {
      

      
        enteredCar = true;
        enteringCar = false;
        isInCar = true;
    }
    void Aim()
    {


        Anim.SetBool("Aiming", true);
        if (!isInCar)
            transform.rotation = new Quaternion(gameObject.transform.rotation.x, cam.transform.rotation.y, gameObject.transform.rotation.z, gameObject.transform.rotation.w);

    }
    void NoAim()
    {
        Anim.SetBool("Aiming", false);
    }
    void Walk()
    {
        Anim.SetBool("Walking", true);

    }
    void NoWalk()
    {
        Anim.SetBool("Walking", false);

    }
    void walkBack()
    {
        Anim.SetBool("WalkingBack", true);
    }
    void noWalkBack()
    {
        Anim.SetBool("WalkingBack", false);
    }
    void Sprint()
    {
        Anim.SetBool("Sprinting", true);

    }
    void noSprint()
    {
        Anim.SetBool("Sprinting", false);

    }
    void openLeftDoor()
    {
        GetComponent<PlayerToCar>().leftDoor.GetComponent<Animator>().SetTrigger("open");

    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        
        isInCar = GetComponent<PlayerToCar>().isInCar;
        if (Input.GetKey(KeyCode.W))
        {
            Walk();

        }
        else
        {
            NoWalk();
        }
        if (Input.GetKey(KeyCode.S))
        {
            walkBack();
        }
        else if (!Input.GetKey(KeyCode.S))
        {
            noWalkBack();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Sprint();
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
        noSprint();
        }
        if (Input.GetKeyDown(KeyCode.F) )
        {
            if (!enteredCar && isCloseToCar)
            { enteringCar = true; }
           
            if (isInCar)
            {
                exitingCar = true;
                enteringCar = false;
            }

        }
     

        if(isCloseToCar && enteringCar)
        {
            getInCar();
            openLeftDoor();

        }
        else
        {
            Anim.SetBool("EnteringCar", false);
        }
       if(isInCar && exitingCar)
        {
           isInCar = false;
            exitingCar = false;
            enteredCar = false;
                    }
        else
        {
            Anim.SetBool("ExitingCar", false);
        }
        

        if (Input.GetKey(KeyCode.A) &&( Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
        {
            transform.Rotate(Vector3.down);
        }
        if (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
        {
            transform.Rotate(Vector3.up);
        }

        if (!PauseMenuScript.gameIsPaused)

        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                if (GetComponent<GunSwitch>().Weapons !=GunSwitch.WeaponSlots.FISTS)
                {
                    Aim();
                }
            }
            else
            {
                NoAim();
            }
        }
        if(isInCar)
        {
            GetComponent<GunSwitch>().a1 = false;
            GetComponent<GunSwitch>().a2 = false;
            GetComponent<GunSwitch>().pistola.SetActive(false);
            GetComponent<GunSwitch>().AK47.SetActive(false);
            Crosshair.enabled = false;
            GetComponentInChildren<MouseLookT>().enabled = false;

        }
     /*   else if(GetComponent<GunSwitch>().isAimingPistol)
        {
            GetComponentInChildren<MouseLookT>().enabled = false;
        }*/
        else
        {
            GetComponentInChildren<MouseLookT>().enabled = true;
        }
        GameObject leftDoor = GetComponent<PlayerToCar>().leftDoor;
        GameObject CCar = GetComponent<PlayerToCar>().closestCar;
        if (!Anim.GetCurrentAnimatorStateInfo(0).IsName("StayingInCar") || !Anim.GetCurrentAnimatorStateInfo(0).IsName("Entering car") || !Anim.GetCurrentAnimatorStateInfo(0).IsName("ExitingCar"))
        {
            enteredCar = false;
        }

       

        




    }


}

