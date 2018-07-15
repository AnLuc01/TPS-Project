using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gun : MonoBehaviour {
    public float damage = 10f;
    public float range = 1000000f;
    public GameObject cam;
    public Camera camera;
    public Image Crosshair;
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
        Crosshair.enabled = false;
        caric = 5;
    }
   
    // Update is called once per frame
    void Update() {
        Debug.DrawLine(transform.position, cam.transform.forward, Color.red);

        if (Input.GetKey(KeyCode.Mouse1)&& !isInCar)
        {
            Crosshair.enabled = true;
        }
            else { Crosshair.enabled = false; }
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
        audio.Play();


        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            if(hit.collider != null)
            hit.transform.SendMessage("HitByRay");
            HealthScript target = hit.transform.GetComponent<HealthScript>();
            if(hit.collider.gameObject.GetComponent<Rigidbody>() != null)
            {
                hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward* 50);
            }
            if(target != null)
            {
                target.takeDamage(10);
            }

        }

    }

}
