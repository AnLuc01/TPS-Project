using UnityEngine;
using System.Collections;

public class GunSwitch : MonoBehaviour
{
    public bool a1;
    public bool a2;
    public GameObject AK47;
    public Animator anim;
    public bool hasAgun;
    public bool isInCar;
    public GameObject pistola;
    bool isAimingPistol;
    public Camera cam;
    public bool isAiming;
    public int Ammo;
    public int Magazines;
    public Transform centerOfRightHand;
    bool isAimingAK;
    public float mouseWheel;
    public GameObject[] Guns;
    // Use this for initialization

    
    public enum WeaponSlots
    {
        FISTS, PISTOL, AK, RIFLE, UZI, SHOTGUN, BAT,
    }

    public WeaponSlots Weapons = new WeaponSlots();
    void Start()
    {
        Weapons = WeaponSlots.FISTS;
        a1 = false;
        anim.SetBool("Rifle", false);
        a2 = false;
        anim = gameObject.GetComponent<Animator>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

    }



    // Update is called once per frame
    void Update()
    {
        mouseWheel = Input.GetAxis("Mouse ScrollWheel");
        GunSwitching();
        if (Weapons == WeaponSlots.PISTOL)
        {
            anim.SetBool("Pistol", true);
        }
        else
        {
            anim.SetBool("Pistol", false);
        }
        if(Weapons == WeaponSlots.AK)
        {
            anim.SetBool("Rifle", true);
        }

        #region Old Code
        print("b");
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Aim"))
        {
            isAimingPistol = true;

        }
        else
        {
            isAimingPistol = false;
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Ak47"))
        {
            isAimingAK = true;
        }
        else
        {
            isAimingAK = false;
        }
        if (isAimingPistol)
        {
            pistola.transform.localRotation = Quaternion.Euler(-115, 388, -233);
            pistola.transform.position = centerOfRightHand.transform.position;
        }
        isInCar = GetComponent<PlayerScript>().isInCar;

        if (!isInCar)
        {
          /*  if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                hasAgun = true;

                a1 = true;
                a2 = false;
                pistola.SetActive(true);
                anim.SetBool("Pistol", true);
                AK47.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                hasAgun = true;
                a1 = false;
                a2 = true;
                pistola.SetActive(false);
                anim.SetBool("Pistol", false);
                anim.SetBool("Rifle", true);
                AK47.SetActive(true);

            }
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                hasAgun = false;
                a1 = false;
                a2 = false;
                AK47.SetActive(false);
                pistola.SetActive(false);

            }

    */
        }

        Ammo = 10;
            Magazines = pistola.GetComponent<Gun>().caric;
        
        
        if (isAimingPistol || isAimingAK)
        {
            isAiming = true;

        }
        else
        {
            isAiming = false;
        }
#endregion
    }
    void activateCurrentGuns()
    { int i = 0;

        foreach (GameObject Gun in Guns)
        {
            if(Weapons == WeaponSlots.FISTS)
            {
             if(Gun != Guns[0])
                {
                    Gun.SetActive(false);
                }
            }
        }
        do
        {
            if(i == (int)Weapons)
            {
                Guns[i].SetActive(true);
                if (Guns[i].GetComponent<Gun>())
                {
                    
                    Ammo = Guns[i].GetComponent<Gun>().ammo;
                    Magazines = Guns[i].GetComponent<Gun>().caric;
                }
                }
            else
            {
               
                Guns[i].SetActive(false);
            }
            
            i++;
            print(i);
        } while (i < Guns.Length-1);

        

    }
    void GunSwitching() 
        {
        if(mouseWheel>0)
        {

            if ((int)Weapons != 6)
                Weapons += 1;
            activateCurrentGuns();


        }
        else if(mouseWheel<0)
        {
            if(Weapons != 0)
            {
                Weapons -= 1;

            }
            activateCurrentGuns();

        }



    }
}
