using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {
    public Rigidbody rb;
    public int hit;
    public GameObject player;
    public float forza = 0;
	// Use this for initialization
	void Start () {
        hit = 0;
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	
    void HitByRay()
    {
        hit = 1;
      
       
    }
    void Update()
    {

        if (hit == 1)
        {
            forza = 10;
            hit = 0;
        }
        else
        {
            forza = 0;

        }
        rb.AddForce(player.transform.forward * forza);




    }
}
