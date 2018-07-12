using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

  public  int Health;
  public int Armor;
    public bool takeDamageB = false;
	// Use this for initialization
	void Start () {
        Health = 100;
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Bodyarmor")
        {
            Armor = 100;
            Destroy(other.gameObject);
            
        }
    }

    // Update is called once per frame
    void Update () {
        if (takeDamageB)
        {
            takeDamage(10);
            takeDamageB = false;

        }
    }

  public void takeDamage(int amount)
    {
        if (Armor > 0)
        {
            Armor -= amount;
        }
        else
        {
            Health -= amount;
        }
        if (Health <= 0)
        {
            Die();
        }
        
    }

void Die()
    {
        Destroy(gameObject);
    }
}
