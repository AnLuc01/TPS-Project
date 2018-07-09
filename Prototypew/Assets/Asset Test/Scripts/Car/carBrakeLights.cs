using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carBrakeLights : MonoBehaviour {
    public Light RightBrakeLight;
    public Light LeftBrakeLight;
    public Light RightH;
    public Light LeftH;
    public bool HeadOn;
    public Light LR;
    public Light RR;
    public bool isActive = false;
    public Light leftF;
    public Light rightF;
	// Use this for initialization
	void Start () {
        HeadOn = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        isActive = GetComponent<WheelDrive>().playerDriving;

        if (isActive)
        {

            if (Input.GetKey(KeyCode.Space) || Input.GetAxis("Vertical") == 0)
            {

                RightBrakeLight.enabled = true;
                LeftBrakeLight.enabled = true;


            }

            else if (Input.GetAxis("Vertical") < 0)
            {
                if (GetComponent<Rigidbody>().velocity.z < 0)
                {
                    RightBrakeLight.enabled = false;
                    LeftBrakeLight.enabled = false;
                }
            }
            else
            {
                RightBrakeLight.enabled = false;
                LeftBrakeLight.enabled = false;

            }

            if (Input.GetAxis("Vertical") < 0)
            {
                LR.enabled = true;
                RR.enabled = true;

            }
            else
            {
                LR.enabled = false;
                RR.enabled = false;
            }

            if (Input.GetKeyDown(KeyCode.H))
                HeadOn = !HeadOn;
            if (HeadOn)
            {
                LeftH.enabled = true;
                RightH.enabled = true;
                leftF.enabled = true;
                rightF.enabled = true;

            }
            else
            {
                leftF.enabled = false;
                rightF.enabled = false;
                LeftH.enabled = false;
                RightH.enabled = false;
            }
        }
        else
        {
            leftF.enabled = false;
            rightF.enabled = false;
            LeftH.enabled = false;
            RightH.enabled = false;
            LR.enabled = false;
            RR.enabled = false;
        }
    }
}
