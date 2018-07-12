using UnityEngine;
using System.Collections;

public class GunSwitch : MonoBehaviour {
    public bool a1;
    public bool a2;
    public GameObject AK47;
    public Animator anim;
    public bool hasAgun;
    public bool isInCar;
    public GameObject pistola;
    public bool isAimingPistol;
    public string currentGun;
    public int Ammo;
    public int Magazines;
    public Transform centerOfRightHand;
	// Use this for initialization
	void Start () {
        pistola.SetActive(false);
        a1 = false;
        anim.SetBool("Rifle", false);
        AK47.SetActive(false);
        a2 = false;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Aim"))
        {
            isAimingPistol = true;

        }
        else
        {
            isAimingPistol = false;
        }
        if(isAimingPistol)
        {
            pistola.transform.localRotation =  Quaternion.Euler(-115,388,-233);
            pistola.transform.position = centerOfRightHand.transform.position;
        }
        isInCar = GetComponent<PlayerScript>().isInCar;
     
        if (!isInCar)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
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
           

        }

        if (a1)
        {
            Ammo = pistola.GetComponent<Gun>().ammo;
            Magazines = pistola.GetComponent<Gun>().caric;
        }
    }
}
