using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WheelDrive : MonoBehaviour {
    public WheelCollider[] wheels;
    public float axisV;
    public float axisH;
    public GameObject wheelShape;
    public float maxAngle = 30;
    public float maxTorque = 300;
    public GameObject Cam;
    public float Brakes;
    private double Speed;
    public int MaxSpeed;
    public int speedInt;
    public GameObject leftDoor;
    public bool playerDriving = false;
    public Rigidbody rb;
    float torque;
    Vector3 lastPosition = Vector3.zero;
    // Use this for initialization
   

    void Start () {
        
        wheels = GetComponentsInChildren<WheelCollider>();
        Cam = GameObject.FindGameObjectWithTag("MainCamera");
        rb = GetComponent<Rigidbody>();

        int I = 0;

        do
        {
           var wheel = wheels[I];
            // create wheel shapes only when needed

            var ws = GameObject.Instantiate(wheelShape);
            ws.transform.parent = wheel.transform;
            I++;
        } while (I < 4);

    }

    // Update is called once per frame
    void Update()
    {
        leftDoor = GameObject.FindGameObjectWithTag("LeftDoor");
        wheelShapeAssignment();
        
        
        if (playerDriving) {
            Drive();

            axisV = Input.GetAxis("Vertical")*2;
        axisH = Input.GetAxis("Horizontal") * 50;
            
        }
       


    }
    void FixedUpdate()
    {

        
            Speed = (((transform.position - lastPosition).magnitude) / Time.deltaTime) * 3.6;

            lastPosition = transform.position;
            speedInt = (int)Speed;
            if (speedInt > MaxSpeed)
            {
                rb.velocity = rb.velocity.normalized * 155/3.6f;

        }
        
        
    

    }


    void Drive()
    {
        torque = maxTorque * axisV*0.5f;
    
        foreach (WheelCollider wheel in wheels)
        {
            if (wheel.transform.localPosition.z < 0)
            {

                wheel.motorTorque = torque;
                wheel.brakeTorque = Brakes;
            }
                if (wheel.transform.localPosition.z > 0)
                {
                    wheel.steerAngle = axisH;
                }


                if (Input.GetKey(KeyCode.Space))
            {
                Brake();
            }
            else
            {
                noBrake();
            }
        } 
        //assegna la mesh
       
    }

    void wheelShapeAssignment()
    {
        foreach (WheelCollider wheel in wheels)
        {

            if (wheelShape)
            {
                Quaternion q;
                Vector3 p;
                wheel.GetWorldPose(out p, out q);

                // assume that the only child of the wheelcollider is the wheel shape
                Transform shapeTransform = wheel.transform.GetChild(0);
                shapeTransform.position = p;
                shapeTransform.rotation = q;

            }
        }
    }
    void Brake()
    {
        Brakes = 50000;        
    }
    void noBrake()
    {
        Brakes = 0;
    }


}

