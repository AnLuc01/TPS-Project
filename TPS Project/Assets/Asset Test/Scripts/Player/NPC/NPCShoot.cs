using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCShoot : MonoBehaviour {
    public Animator NPCAnim;
    public Transform target;
    public Transform Chest;
    public int Health;
    Rigidbody NPCRigid;
    public Transform LegLeft;
    public Transform Hand;
    public float offSet;
    public Quaternion ChestRot;
	// Use this for initialization
	void Start () {
        StartCoroutine(NumberGen());
        NPCRigid = GetComponent<Rigidbody>();
        NPCAnim = GetComponent<Animator>();
        Chest = NPCAnim.GetBoneTransform(HumanBodyBones.Chest);
        Hand = NPCAnim.GetBoneTransform(HumanBodyBones.LeftHand);
        LegLeft = NPCAnim.GetBoneTransform(HumanBodyBones.LeftLowerLeg);
    }
	
	// Update is called once per frame
	void Update () {
        Health = GetComponent<HealthScript>().Health;

        if (Health > 0)
        {
            NPCRigid.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;

            Aim();

        }
        }
    IEnumerator NumberGen()
        {
            while (true)
            {
                offSet = Random.Range(-0.5f, 0.5f);
                yield return new WaitForSeconds(2);
            }
        
    }


    void Aim()
    {
        
            setAllOtherBoolsFalse();
        
    
    NPCAnim.SetBool("Aiming", true);
        NPCAnim.SetBool("Pistol", true);
        if (target)
        {
            transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z + offSet));
            Debug.DrawRay(transform.position, transform.forward, Color.blue);
            Chest.transform.rotation = Quaternion.Euler(-target.position.y * 5, LegLeft.transform.eulerAngles.y, ChestRot.z);
        }
        else
        {
            transform.LookAt(null);
        }
    }

    void noAim()
    {
        NPCAnim.SetBool("Aiming", false);

    }

    void setAllOtherBoolsFalse()
    {
        foreach (AnimatorControllerParameter par in NPCAnim.parameters)
        {
            if (par.name != "Aim" || par.name != "Pistol") 
            NPCAnim.SetBool(par.name, false);
        }
    }

}
