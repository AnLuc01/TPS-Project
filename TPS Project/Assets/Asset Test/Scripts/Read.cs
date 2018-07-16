using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;


public class Read : MonoBehaviour
{
  
    public string Health;
    public string Armor;
    // Update is called once per frame
    void Update()
    {
        int lineNumber = 0; //Int to show which line it is
        foreach (string option in File.ReadAllLines("Assets/Asset Test/Saves/Save.txt"))
        {
            //Loops once for each line in the file
            switch (lineNumber)
            {
                case 0://First line.
                    Health = option;
                    break;
                case 1://Second line.
                    Armor = option;
                    break;
         
                default:
                    break;
            }
            lineNumber++;//Adds 1 to the int so that the next loop uses the next value.
        }
    }
}
