using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carEngine : MonoBehaviour {
    public WheelCollider FL;
    public WheelCollider FR;
    public int speedInt;
    public int[] gearRatio;
    public int currGear = 1;
    public AudioSource engSound;
    public float minGear;
    public float maxGear;
    public int i;
    public float RPM;
    public float pitchEngine;
    Vector3 lastPosition = Vector3.zero;

    // Use this for initialization
    void Start () {
        engSound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        speedInt = findSpeed();
        
        engineSound();
    }

    int findSpeed()
    {

        double speedDouble;

        speedDouble = (((transform.position - lastPosition).magnitude) / Time.deltaTime) * 3.6;

        lastPosition = transform.position;
        return (int)speedDouble;
    }

    void engineSound()
    {
        currGear = 1;
         i = 0;
 
       do
        {
            if(gearRatio[i]> speedInt)
            {
                currGear = i+1;
                break;
            }
            i++;
           
        } while (i < gearRatio.Length);
        
        if (i == 0)
        {
            minGear = 0;
        }
        else
        {
            minGear = gearRatio[i-1];
        }
        maxGear = gearRatio[i];

        pitchEngine = (speedInt - minGear) / (maxGear - minGear)+0.9f;

        engSound.pitch = pitchEngine;


    }
}
