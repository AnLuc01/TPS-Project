using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToCar : MonoBehaviour {
    public GameObject[] Cars;
    public bool A;
    public bool isInCar;
    public Animator Anim;
    public float distance;
    public GameObject leftDoor;
    public bool isClose;
    public GameObject closestCar;
    public GameObject Sedile;
    

    void findClosestCar()
    {
            /*sistemare*/
        foreach (GameObject Car in Cars)
        {
            Vector3 position = transform.position;

            Vector3 diff = Car.transform.position - position; //per ogni oggetto nell'array cars, controlla la distanza tra il player e l'oggetto
            float carDist = diff.sqrMagnitude;

            if (carDist < distance)
            {// definisci quello piu vicino
                closestCar = Car;
                distance = carDist;
                leftDoor = closestCar.transform.Find("CarBody").gameObject.transform.Find("LEFT_DOOR").gameObject;
                Sedile = closestCar.transform.Find("Sedile").gameObject;
            }
        }


    }

    void checkifClose()
    {
        if (distance <= 6.5)
        {
            isClose = true;
            GetComponent<PlayerScript>().isCloseToCar = true;


        }
        else
        {
            isClose = false;
            GetComponent<PlayerScript>().isCloseToCar = false;
        }
    } //controlla se è in una distanza accettabile per entrare

    void checkIfInCar() // controlla se il player sta entrando o uscendo dall'auto, o se vi è all'interno
    {
        if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Entering car") || Anim.GetCurrentAnimatorStateInfo(0).IsName("StayingInCar"))
        {
            isInCar = true;
        }
        else
        {
            isInCar = false;
        }
    }

    void deactivateAllCameras()  //disattiva le telecamere di tutte le altre auto e attiva quella dell'auto piu vicina una volta entrato

    {
        foreach (GameObject Car in Cars)
        {
            Car.GetComponentInChildren<Camera>().enabled = false;
        }
        closestCar.GetComponentInChildren<Camera>().enabled = true;
    }

    // Update is called once per frame
    void Update() {
        /*dichiarazioni varie*/

        {

            Anim = GetComponent<Animator>();
            Cars = GameObject.FindGameObjectsWithTag("Car");
            closestCar = null;
            distance = Mathf.Infinity;
            Vector3 position = transform.position;
        }
        findClosestCar();
        checkifClose();
        checkIfInCar();

        
    

      
   
        
      
        //se il giocatore sta entrando in macchina teletrasportalo vicino allo sportello
            if (Input.GetKey(KeyCode.F) && isClose && !GetComponent<PlayerScript>().Anim.GetCurrentAnimatorStateInfo(0).IsName("StayingInCar"))
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(leftDoor.transform.position.x - 1f, leftDoor.transform.position.y - 0.7f, leftDoor.transform.position.z - 0.75f), 1);
            transform.LookAt(new Vector3(leftDoor.transform.position.x, transform.position.y, transform.position.z));
            Anim.SetBool("EnteringCar", true);
           




        }
        //disattiva il collider del giocatore, così può entrare in auto se è in macchina e disattiva la telecamera del player
        if (isInCar)
        {
            GetComponent<Collider>().enabled = false;
            GetComponentInChildren<Camera>().enabled = false;
            
            

        }
        

        if (GetComponent<PlayerScript>().Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle_Neutral_1")) //se fa quest'animazione, quindi non sta in auto
        {
            GetComponent<Collider>().enabled = true;  //attiva il collider           
            closestCar.GetComponentInChildren<Camera>().enabled = false;
            leftDoor.GetComponent<Animator>().ResetTrigger("open"); //resetta il trigger a falso
            closestCar.GetComponent<WheelDrive>().playerDriving = false; //se non è in auto rendi la bool relativa falsa
            GetComponentInChildren<Camera>().enabled = true; //attiva la telecamera del giocatore, che ha la priorità su quella dell'auto


        } //se il giocatore è fuori dall'auto disattiva la telecamera dell'auto e attiva il collider del player
        if (GetComponent<PlayerScript>().Anim.GetCurrentAnimatorStateInfo(0).IsName("StayingInCar"))
        {
            GetComponent<Collider>().enabled = false; //se sta in auto disattiva il suo collider
            GetComponent<PlayerScript>().enabled = false; //disattiva tutte le azioni che il giocatore può fare fuori dall'auto
            transform.rotation = closestCar.transform.rotation; //la rotazione del giocatore = rotazione auto
            transform.position = Sedile.transform.position;
            leftDoor.GetComponent<Animator>().ResetTrigger("open");

            closestCar.GetComponent<WheelDrive>().playerDriving = true;


        }
        else if (GetComponent<PlayerScript>().Anim.GetCurrentAnimatorStateInfo(0).IsName("Entering car") || GetComponent<PlayerScript>().Anim.GetCurrentAnimatorStateInfo(0).IsName("ExitingCar"))
        {
           GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            deactivateAllCameras();
            leftDoor.GetComponent<Animator>().SetTrigger("open");

        }
        else
        {
            GetComponent<PlayerScript>().enabled = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            GetComponent<Collider>().enabled = true;
            closestCar.GetComponent<WheelDrive>().playerDriving = false;

                       

        }

        if (GetComponent<PlayerScript>().Anim.GetCurrentAnimatorStateInfo(0).IsName("ExitingCar"))
        {
            closestCar.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
        }
        else
        {
            closestCar.GetComponent<Rigidbody>().constraints = 0;  //Se il giocatore sta uscendo dalla macchina fermala;
        }


    }
        
    
}
