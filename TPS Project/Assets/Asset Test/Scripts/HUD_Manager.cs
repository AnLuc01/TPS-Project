using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Manager : MonoBehaviour {
    public Image Health;
    public Image Armor;
    public GameObject Player;
    float HealthAmount;
    float ArmorAmount;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HealthAmount = Player.GetComponent<HealthScript>().Health;
        ArmorAmount = Player.GetComponent<HealthScript>().Armor;
        Health.fillAmount = HealthAmount/100;
        Armor.fillAmount = ArmorAmount/100;
    }
}
