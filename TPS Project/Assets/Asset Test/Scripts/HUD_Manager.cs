using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System.Text;
using UnityEditor;
using System.IO;


public class HUD_Manager : MonoBehaviour {
#region //UI Declaration 
    public Image Health;
    public Image Armor;
    public Text RankText;
    public Text ReputationText;
    public Text AmmoText;
    public Text MagazinesText;
    public Text MoneyText;
    #endregion

#region // Other variables
    public GameObject Player;
    float HealthAmount;
    float ArmorAmount;
    int Ammo;
    int Magazines;
    public string Rank;
    public int Reputation;
    public int Money;
    #endregion

   

    // Use this for initialization
    void Start () {
  
        Player = GameObject.FindGameObjectWithTag("Player");
        Reputation = Player.GetComponent<Stats>().Rep;
        Money = Player.GetComponent<Stats>().Money;

        Rank = Player.GetComponent<Stats>().Rank;


    }

    // Update is called once per frame
    void Update () {

        HealthAmount = Player.GetComponent<HealthScript>().Health;
        ArmorAmount = Player.GetComponent<HealthScript>().Armor;
        Ammo = Player.GetComponent<GunSwitch>().Ammo;
        Magazines = Player.GetComponent<GunSwitch>().Magazines;
        
      
        Health.fillAmount = HealthAmount/100;
        Armor.fillAmount = ArmorAmount/100;
        RankText.text = Rank;
        AmmoText.text = Ammo.ToString() + "/";
        MagazinesText.text = Magazines.ToString();
        ReputationText.text = Reputation.ToString();
        MoneyText.text = Money.ToString()+"$";

    }
}
