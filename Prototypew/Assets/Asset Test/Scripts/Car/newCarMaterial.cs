using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newCarMaterial : MonoBehaviour {
    public Renderer carRenderer;
    public GameObject LeftDoor;
    public GameObject RightDoor;
    public bool RandomColor;
    // Use this for initialization
	void Start()
        {
        /* essendo gli sportelli oggetti separati dal corpo hanno materiali separati, così li rendiamo uguali al corpo dell'auto*/
        findDoors();
        
    }

    // Update is called once per frame
    void Update () {


        carRenderer = GetComponent<Renderer>();
        if (RandomColor)
        {
            randomColor();
            RandomColor = false;
        }
        RightDoor.GetComponent<Renderer>().material.color = carRenderer.material.color;
        RightDoor.GetComponent<Renderer>().material = carRenderer.material;
        LeftDoor.GetComponent<Renderer>().material.color = carRenderer.material.color;
        LeftDoor.GetComponent<Renderer>().material = carRenderer.material;

    }
void randomColor()
    {
        carRenderer.material = new Material(Shader.Find("Standard"));
        carRenderer.material.color = Random.ColorHSV();
        
    }

void findDoors()
    {
        LeftDoor = transform.Find("LEFT_DOOR").gameObject;
        RightDoor = transform.Find("RIGHT_DOOR").gameObject;
    }
}
