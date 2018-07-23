using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHitByCar : MonoBehaviour {
    public Rigidbody[] bodys;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        FindRBs();
        
	}

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Animator>().enabled = false;


        if (collision.gameObject.tag == "Car")
        {
            foreach (Rigidbody rb in bodys)
            {
                rb.isKinematic = false;
            }
            if(collision.relativeVelocity.x<0)
            {
                GetComponent<HealthScript>().Health +=(int)collision.relativeVelocity.x;

            }
            else
            {
                GetComponent<HealthScript>().Health -= (int)collision.relativeVelocity.x;
            }
        }
    }

    void ragDoll()
    {

        foreach (Rigidbody rb in bodys)
        {
            rb.isKinematic = false;
        }
    }

    void FindRBs()
    {
        bodys = gameObject.GetComponentsInChildren<Rigidbody>();
        
    }
}
