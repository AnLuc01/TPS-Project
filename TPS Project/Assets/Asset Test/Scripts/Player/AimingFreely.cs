using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingFreely : MonoBehaviour {

     Animator Anim;
    public Camera camera;
    public Quaternion offSet;
    Transform chest;
    public Transform hand;
	// Use this for initialization
	void Start () {
        Anim = GetComponent<Animator>();
        chest = Anim.GetBoneTransform(HumanBodyBones.Chest);
        hand = Anim.GetBoneTransform(HumanBodyBones.LeftHand);
    }


    // Update is called once per frame
    void LateUpdate() {

        if (!PauseMenuScript.gameIsPaused)
        {

            if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Aim"))
            {


                chest.transform.rotation = new Quaternion(camera.transform.rotation.x, transform.rotation.y, gameObject.transform.rotation.z, gameObject.transform.rotation.w);
                hand.transform.rotation = offSet;
                Anim.GetBoneTransform(HumanBodyBones.RightHand).transform.rotation = offSet;
            }
        }
        
    }
}
