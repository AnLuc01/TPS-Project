using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour {
    public float speedf;
    public Text MPH;

    public float seccut; //secondi che dura la cutscene

    // Use this for initialization
    void Start() {

    }
        // Update is called once per frame
        void Update() {

            Rigidbody rb = GetComponent<Rigidbody>();
            speedf = rb.velocity.magnitude;
            speedf = (speedf / 0.28f) / 1.6F;
            speedf = (Mathf.Round(speedf));


;
           

             

            }
        }


    

