using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCreation : MonoBehaviour {

    public GameObject Path;
    public GameObject Empty;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        createWaypoint();
	}

    void createWaypoint()
    {
        Instantiate(gameObject, Path.transform);
    }
}
