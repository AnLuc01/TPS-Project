using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

   public  int Health;
   public int Armor;
    Animator anim;
    public bool isEnemy = false;
    public bool takeDamageB = false;
	// Use this for initialization
	void Start () {
        Health = GetComponent<Stats>().Health;
        Armor = GetComponent<Stats>().Armor;
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Bodyarmor" && gameObject.tag == "Player")
        {
            Armor = 100;
            Destroy(other.gameObject);
            
        }
    }

    // Update is called once per frame
    void Update () {
        if (Health <= 0)
        {
            Die();
        }
        if (takeDamageB)
        {
            takeDamage(10);
            takeDamageB = false;


        }
    }

  public void takeDamage(int amount)
    {
        if (GetComponent<NPCAi>())
        {
            NPCAi NPCScript = GetComponent<NPCAi>();
            NPCScript.Agitated = true;
            if (isEnemy)
            {
                Fight();
            }
            else
            {
                NPCScript.Sprint();
            }
        }
        if (Armor > 0)
        {
            Armor -= amount;
        }
        else
        {
            Health -= amount;
        }
     
        
    }

void Die()
    {
        anim.SetBool("Die", true);
        CapsuleCollider Coll = GetComponent<CapsuleCollider>();
        Coll.height = anim.GetFloat("ColliderHeight");
        Coll.radius = anim.GetFloat("ColliderRange");
    }
void Fight()
    {

    }
}
