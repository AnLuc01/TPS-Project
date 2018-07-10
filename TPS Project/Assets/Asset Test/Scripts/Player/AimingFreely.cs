using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingFreely : MonoBehaviour {

     Animator Anim;
    public Camera camera;
    public Vector3 offSet;
    Transform chest;
	// Use this for initialization
	void Start () {
        Anim = GetComponent<Animator>();
        chest = Anim.GetBoneTransform(HumanBodyBones.Chest);
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	}
   

    // Update is called once per frame
    void LateUpdate() {

        if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Aim"))
            {


            chest.transform.rotation = new Quaternion(camera.transform.rotation.x, transform.rotation.y, gameObject.transform.rotation.z, gameObject.transform.rotation.w);
        }
    }
}
