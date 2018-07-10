﻿using UnityEngine;
using System.Collections;

public class AutoGun : MonoBehaviour {
    public float damage = 10f;
    public float range = 1000000f;
    public GameObject cam;
    public Camera camera;
    public Canvas cr;
    public AudioClip sparo;
    public AudioSource audio;
    public float fireRate = 7.5f;
    public float nextTimeToFire = 1f;
    public float ammo = 5;
    public int caric = 5;
    // Use this for initialization
    void Start()
    {
        ammo = 30;
        cr.enabled = false;
        caric = 5;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Mouse1))
        {

            cr.enabled = true;
        }

        else { cr.enabled = false; }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextTimeToFire && ammo > 0)
            {
                nextTimeToFire = Time.time + 1f / fireRate;

                Shoot();
                cam.transform.rotation = camera.transform.rotation;


            }

            if (Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.Mouse1))
            {
                ammo -= 0.1f;
            }
            if (ammo == 0 && caric > 0)
            {


                ammo = 30;
                caric = caric - 1;
            }



            if (ammo < 0) { ammo = 0; }
        }
    }
   void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
          
            audio.Play();
            hit.transform.SendMessage("HitByRay");



        }

        cr.transform.position = cam.transform.position;
    }


}