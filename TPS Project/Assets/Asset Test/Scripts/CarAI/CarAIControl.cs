using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAIControl : MonoBehaviour {

    public Transform path;
    public List<Transform> Nodes;
    public int currentNode;
    public float maxSteerAngle = 45f;
    public WheelCollider FL;
    public WheelCollider FR;
    public WheelCollider RL;
    public WheelCollider RR;
    public bool NPCIsDriving = false;
    public bool playerDriving;
    public float dist;
    public GameObject Player;
    public GameObject target;
    public float distanceWithNode;
    private float targetSteerAngle = 0;
    public bool DrivingPath = false;
    public float turnSpeed = 5f;
    public string collName;
    

    [Header("Sensors")]
    public float sensorLenght = 3f;
    public Vector3 frontSensorPos = new Vector3(0, 0, 1.59f);
    public float sideSensor = 0.2f;
    public float frontSensorAngle = 30;
    public bool isAvoiding = false;
    public float avoidMultiplier;
    public Vector3 sensorStartPos;
    public bool frontDetect = false;

    // Use this for initialization

    

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

    }
    // Update is called once per frame
    private void Update()
    {


        if(target)
        dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist > 130f )
        {
            currentNode = 1;
        }   
        path = GameObject.FindGameObjectWithTag("Path").transform;

        Nodes = path.GetComponent<ShowPath>().Nodes;
       
    

    }
    void FixedUpdate () {
        if (DrivingPath)
        {
            distanceWithNode = Vector3.Distance(transform.position, Nodes[currentNode].position);
        }
        
        playerDriving = GetComponent<WheelDrive>().playerDriving;
        if (NPCIsDriving)
        {
            Sensors();
            if ((target) || DrivingPath)
            { 
                Drive();
                ApplySteer();
                checkIfCloseToNode();
                lerpToSteerAngle();

            }
            
            if (!target)
            {

               DrivingPath = true;
            }

            if(!NPCIsDriving && !DrivingPath)
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            }
            else
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }
            }
        if(playerDriving)
        {
            NPCIsDriving = false;
        }

        if (!NPCIsDriving && !playerDriving)
        {
            RL.motorTorque = 0;
            FL.motorTorque = 0;
        }
        }

    void ApplySteer()
    {
        if (isAvoiding)
        {
            return;
        }
        Vector3 relativeVector;
        if (target)
        {
             relativeVector = transform.InverseTransformPoint(target.transform.position);
        }
        else if (path)
        {
             relativeVector = transform.InverseTransformPoint(Nodes[currentNode].position);
        }
        else
        {
            relativeVector = transform.position;
        }
        float newSteer = relativeVector.x / relativeVector.magnitude;
        newSteer = newSteer * 45f;
        targetSteerAngle = newSteer;
        
    }
    
    void Sensors()
    {
         avoidMultiplier = 0f;
        RaycastHit hit;
         sensorStartPos = transform.position;
        sensorStartPos += transform.forward * frontSensorPos.z;

        isAvoiding = false;
        //front
        if(Physics.Raycast(sensorStartPos,transform.forward, out hit, sensorLenght))
        {
            if (!hit.collider.CompareTag("Terrain") && hit.collider.gameObject.name != gameObject.name)
            {
                Debug.DrawLine(sensorStartPos, hit.point);
                isAvoiding = true;
                frontDetect = true;
                avoidMultiplier = 1;
                 collName = (hit.collider.gameObject.name);


            }

        }
        else
        {
            frontDetect = false;
        }
 

        //left
        sensorStartPos.x -= sideSensor;
        if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLenght) && !frontDetect)
        {
            if (!hit.collider.CompareTag("Terrain") && hit.collider.gameObject.name != gameObject.name)
            {
                isAvoiding = true;
                Debug.DrawLine(sensorStartPos, hit.point);
                avoidMultiplier += 1f;
                collName = (hit.collider.gameObject.name);
            }
        }

        //front left angle

        if (Physics.Raycast(sensorStartPos, Quaternion.AngleAxis(-frontSensorAngle, transform.up) * transform.forward, out hit, sensorLenght) && !frontDetect)
        {

            if (!hit.collider.CompareTag("Terrain") && hit.collider.gameObject.name != gameObject.name)
            {
                isAvoiding = true;
                Debug.DrawLine(sensorStartPos, hit.point);
                avoidMultiplier += 0.5f;
                collName = (hit.collider.gameObject.name);

            }
        }
        //right
        sensorStartPos.x += sideSensor*2f;
        if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLenght) && !frontDetect)
        {
            if (!hit.collider.CompareTag("Terrain") && hit.collider.gameObject.name != gameObject.name)
            {
                isAvoiding = true;
                Debug.DrawLine(sensorStartPos, hit.point);
                avoidMultiplier -= 1f;
                collName = (hit.collider.gameObject.name);
            }
        }




        //front right angle
        if (Physics.Raycast(sensorStartPos, Quaternion.AngleAxis(frontSensorAngle, transform.up) * transform.forward, out hit, sensorLenght) && !frontDetect)
        {

            if (!hit.collider.CompareTag("Terrain") && hit.collider.gameObject.name != gameObject.name)
            {
                isAvoiding = true;
                Debug.DrawLine(sensorStartPos, hit.point);
                avoidMultiplier -= 1.5f;
                collName = (hit.collider.gameObject.name);

            }
        }

        
        if (isAvoiding)
          {
            targetSteerAngle = maxSteerAngle * avoidMultiplier;
            collName = null;
              
          }
      }


      void checkIfCloseToNode()
      {

         if(distanceWithNode<20f) {
             
            if(currentNode == Nodes.Count - 1)
            {
                currentNode = 0;
            }
              currentNode++;
          }
      }

      void Drive()
      {
          RR.motorTorque = 750f;
          RL.motorTorque = 750f;
      }

      void loseTarget()
      {
          target = null;
      }
      void lerpToSteerAngle()
    {
        FL.steerAngle = Mathf.Lerp(FL.steerAngle, targetSteerAngle, Time.deltaTime * turnSpeed);
        FR.steerAngle = Mathf.Lerp(FL.steerAngle, targetSteerAngle, Time.deltaTime * turnSpeed);

    }
}
