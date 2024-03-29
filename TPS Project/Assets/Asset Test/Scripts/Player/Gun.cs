﻿using UnityEngine;
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
    public int MagSize;
    public bool isAutom;
    public bool isInCar;
    // Use this for initialization
	void Start () {
        ammo = MagSize;
        Crosshair.enabled = false;
        caric = 5;
    }
   
    // Update is called once per frame
    void Update() {
        Debug.DrawLine(transform.position, cam.transform.forward, Color.red);

        if (!PauseMenuScript.gameIsPaused)
        {
            if (Input.GetKey(KeyCode.Mouse1) && !isInCar)
            {
                Crosshair.enabled = true;
            }
            else { Crosshair.enabled = false; }
            if (Input.GetKey(KeyCode.Mouse1))
                if (isAutom)
                {
                    Crosshair.enabled = true;
                    if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextTimeToFire && ammo > 0)
                    {
                        nextTimeToFire = Time.time + 1f / fireRate;

                        ShootAutom();
                        cam.transform.rotation = camera.transform.rotation;


                    }
                }
                else {
                    if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nextTimeToFire && ammo > 0)
                    {


                        nextTimeToFire = Time.time+0.5f / fireRate;

                        ShootSemi();
                        cam.transform.rotation = camera.transform.rotation;

                    }
                }

           
         


        }

    }
    void ShootSemi()
    {
        RaycastHit hit;
        audio.Play();
        ammo -= 1;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            if (hit.collider != null)
                hit.transform.SendMessage("HitByRay");
            HealthScript target = hit.transform.GetComponent<HealthScript>();
            if (hit.collider.gameObject.GetComponent<Rigidbody>() != null)
            {
                hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 50);
            }
            if (target != null)
            {
                target.takeDamage(10);
                if (hit.collider.GetType() == typeof(BoxCollider))
                {
                    target.takeDamage(target.Health);
                }
            }

        }
    }
        void ShootAutom()
    {
       
        RaycastHit hit;
            audio.Play();
            if (Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.Mouse1))
            {
                ammo -= 1;
            }
            if (ammo == 0 && caric > 0)
            {

            nextTimeToFire += 1F;
                ammo = 30;
                caric = caric - 1;
            }
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {

            hit.transform.SendMessage("HitByRay");
            HealthScript target = hit.transform.GetComponent<HealthScript>();
            if (target != null)
            {
                target.takeDamage(5);
            }
            if (hit.collider.gameObject.GetComponent<Rigidbody>() != null)
            {
                hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 50);
            }

        }

    }

    

}
