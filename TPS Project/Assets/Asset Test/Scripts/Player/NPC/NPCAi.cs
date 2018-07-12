using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAi : MonoBehaviour
{

    public Transform Target;
    public Animator NPCAnim;
    public bool Agitated;
    public float Distance;
    public bool Avoiding;
    public Vector3 newDir;
    public GameObject RayS;
    // Use this for initialization
    void Start()
    {
        NPCAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { if (Target != null)
        {

            Distance = Vector3.Distance(transform.position, Target.transform.position);
            if (Distance > 3.5)
            {
                if (Agitated)
                {
                    Sprint();
                }
                else
                {
                    Walk();
                }

            }
            else
            {
                Idle();
            }
            Sensors();

        }
    }

  public void runToTarget(Transform Target)
    {
        lookAt(Target);
        Sprint();
    }

  public void lookAt(Transform Target)
    {
        transform.LookAt(new Vector3(Target.position.x, transform.position.y, Target.position.z));
    }

    public void Walk()
    {
        NPCAnim.SetBool("Sprinting", false);

        NPCAnim.SetBool("Walking", true);
    }

    public void Sprint()
    {
        NPCAnim.SetBool("Walking", true);
        NPCAnim.SetBool("Sprinting", true);
    }

    public void Idle()
    {
        NPCAnim.SetBool("Sprinting", false);
        NPCAnim.SetBool("Walking", false);
    }

    void Sensors()
    {

     
            Vector3 Right = this.transform.forward;
            Vector3 Left = this.transform.forward;
            Right = Quaternion.AngleAxis(45, Vector3.up) * Right;
            Left = Quaternion.AngleAxis(-45, Vector3.up) * Left;
            Vector3 rayStartPos = RayS.transform.position;
            RaycastHit hit;
            Avoiding = false;
            Quaternion qTo = new Quaternion(0, 0, 0, 0);
        bool frontC = false ;
        bool leftC = false;
        bool rightC = false;
        bool rightAC = false;
        bool leftAC = false;
        bool leftNAC = false;
        bool rightNAC = false;
        





      

        //front
        if (Physics.Raycast(rayStartPos, transform.forward, out hit, 5f) && hit.collider.name != Target.name)
        {
            Debug.DrawRay(rayStartPos, transform.forward, Color.red);
            frontC = true;
        }

        //left vert
        if (Physics.Raycast(rayStartPos, -transform.right, out hit, 5f) && hit.collider.name != Target.name)
        {
            Debug.DrawRay(rayStartPos, -transform.right, Color.red);
            leftC = true;
        }

        //right vert
        if (Physics.Raycast(rayStartPos, transform.right, out hit, 5f) && hit.collider.name != Target.name)
        {
            Debug.DrawRay(rayStartPos, transform.right, Color.red);
            rightC = true;
        }




        //left angle
        if (Physics.Raycast(rayStartPos, Left, out hit, 5) && hit.collider.name != Target.name)
        {
            Debug.DrawRay(rayStartPos, Left, Color.red);
            leftAC = true;
        }

        //right neg ang 
        if (Physics.Raycast(rayStartPos, -Left, out hit, 5) && hit.collider.name != name && hit.collider.name != Target.name)
        {
            rightNAC = true;
            
            Debug.DrawRay(rayStartPos, -Left, Color.red);
        }
        //left neg ang 
        if (Physics.Raycast(rayStartPos, -Right, out hit, 5) && hit.collider.name != name && hit.collider.name != Target.name)
        {
            leftNAC = true;
            Debug.DrawRay(rayStartPos, -Right, Color.red);
        }


        //right Angle
        if (Physics.Raycast(rayStartPos, Right, out hit, 5) && hit.collider.name != Target.name)
        {
            rightAC = true;
            Debug.DrawRay(rayStartPos, Right, Color.red);

        }

        if (frontC || leftC || rightC || leftAC || rightAC || leftNAC || rightNAC) 
        {
            Avoiding = true;
        }
        else
        {
            Avoiding = false;
        }

        if(Avoiding)
        {
            qTo = Quaternion.Euler(0.0f, transform.rotation.y + 90, 0f);

        }
        else
        {
            qTo = Quaternion.LookRotation(Target.position - transform.position);
        }
        transform.rotation = Quaternion.RotateTowards(transform.rotation, qTo, 50 * Time.deltaTime);






    }
}
