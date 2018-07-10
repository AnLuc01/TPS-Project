using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
    public float damage = 10f;
    public float range = 1000000f;
    public GameObject cam;
    public Camera camera;
    public Canvas cr;
     AudioClip sparo;
    public AudioSource audio;
    public float fireRate = 7.5f;
    public float nextTimeToFire = 1f;
    public int ammo = 5;
    public int caric = 5;
    public bool isInCar;
    // Use this for initialization
	void Start () {
        ammo = 5;
        cr.enabled = false;
        caric = 5;
    }
   
    // Update is called once per frame
    void Update() {
         
        if(Input.GetKey(KeyCode.Mouse1)&& !isInCar)
        {
            cr.enabled = true;
        }
            else { cr.enabled = false; }
            if (Input.GetKey(KeyCode.Mouse1))
                if (Input.GetKeyDown(KeyCode.Mouse0) && ammo > 0)
                {
                    nextTimeToFire = Time.time + 1f / fireRate;

                    Shoot();
                    cam.transform.rotation = camera.transform.rotation;


                }

            if (Input.GetKeyDown(KeyCode.Mouse0) && Input.GetKey(KeyCode.Mouse1))
            {
                ammo -= 1;
            }
            if (ammo == 0 && caric > 0)
            {

                ammo = 5;
                caric = caric - 1;
            }



            if (ammo < 0) { ammo = 0; }
        

   


    }
    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
           
            audio.Play();
            hit.transform.SendMessage("HitByRay");


        }

        cr.transform.position = camera.transform.position;
    }

}
