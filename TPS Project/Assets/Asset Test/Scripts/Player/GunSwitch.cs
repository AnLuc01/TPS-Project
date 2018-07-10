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
	// Use this for initialization
	void Start () {
        pistola.SetActive(false);
        a1 = false;
        anim.SetBool("Rifle", false);
        AK47.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
