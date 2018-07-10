using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

  public  int Health;
	// Use this for initialization
	void Start () {
        Health = 100;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

  public void takeDamage(int amount)
    {
        Health -= amount;
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
