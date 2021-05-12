using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowMoney : MonoBehaviour
{
    Text t;
    private void Start()
    {
        t = GetComponent<Text>(); 
    }

    private void Update()
    {
        t.text = "Money\t\t\t\t\t : " + DatabaseManager.instance.database.money + "\n" + "FlightTime\t\t : " + (int)DatabaseManager.instance.database.flightTime + "\n" + "Attack\t\t\t\t\t : " + DatabaseManager.instance.database.Attack + "\n" + "HP\t\t\t\t\t\t\t\t : " + DatabaseManager.instance.database.HP + "\n" + "Speed\t\t\t\t\t : " + DatabaseManager.instance.database.Speed + "\n";
        
    }
}
