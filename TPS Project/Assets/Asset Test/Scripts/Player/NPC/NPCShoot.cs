using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCShoot : MonoBehaviour {
    public Animator NPCAnim;
    public Transform target;
    public Transform Chest;
    Rigidbody NPCRigid;
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
    }
	
	// Update is called once per frame
	void Update () {
        NPCRigid.constraints = RigidbodyConstraints.FreezeRotationZ| RigidbodyConstraints.FreezeRotationX;
        Aim();
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
        NPCAnim.SetBool("Aiming", true);
        NPCAnim.SetBool("Pistol", true);
        transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z+offSet));
        Debug.DrawRay(transform.position, transform.forward, Color.blue);
    }

}
