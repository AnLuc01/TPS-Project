using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class Stats : MonoBehaviour {
    public string Rank;
    public int Rep;
    public int Health;
    public int Armor;
    public int Money;
    void readSave()
    {
        int lineNumber = 0; //Int to show which line it is
        foreach (string Line in File.ReadAllLines("Assets/Asset Test/Saves/Save.txt"))
        {
            //Loops once for each line in the file
            switch (lineNumber)
            {
                case 0://First line.
                    Health = int.Parse(Line);
                    break;
                case 1://Second line.
                    Armor = int.Parse(Line);
                    break;
                case 2:
                    Rank = Line;
                    break;
                case 3:
                    Rep = int.Parse(Line);
                    break;
                case 4:
                    Money = int.Parse(Line);
                    break;
                default:
                    break;
            }
            lineNumber++;//Adds 1 to the int so that the next loop uses the next value.
        }
    }
    // Use this for initialization
    void Awake () {
        readSave();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
