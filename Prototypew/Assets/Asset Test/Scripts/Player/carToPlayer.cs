using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carToPlayer : MonoBehaviour {
    public bool isInCar;
    public Animator Anim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        isInCar = GetComponent<PlayerToCar>().isInCar;
        Anim = GetComponent<Animator>();
		if(isInCar && Input.GetKey(KeyCode.F))
        {
            Anim.SetBool("ExitingCar", true);
/*            GetComponent<PlayerToCar>().closestCar.GetComponent<WheelDrive>().active = false;
*/            
        }
	}
}
