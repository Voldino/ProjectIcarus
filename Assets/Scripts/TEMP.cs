using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseAttack()
    {
        if (DatabaseManager.instance.database.flightTime >= 180 && DatabaseManager.instance.database.getIncreasedStats("Attack") < 9)
        {
            DatabaseManager.instance.database.increasedStats("Attack",1) ;
            DatabaseManager.instance.database.flightTime -= 180;
        }
        else
        {
            Debug.Log("Need more flight time");
        }
    }

    public void IncreaseHP()
    {
        if (DatabaseManager.instance.database.flightTime >= 180 && DatabaseManager.instance.database.getIncreasedStats("HP") < 9)
        {
            DatabaseManager.instance.database.increasedStats("HP",1) ;
            DatabaseManager.instance.database.flightTime -= 5;
        }
        else
        {
            Debug.Log("Need more flight time");
        }
    }

    public void IncreaseSpeed()
    {
        if (DatabaseManager.instance.database.flightTime >= 180 && DatabaseManager.instance.database.getIncreasedStats("Speed")< 9)
        {
            DatabaseManager.instance.database.increasedStats("Speed",1) ;
            DatabaseManager.instance.database.flightTime -= 180;
        }
        else
        {
            Debug.Log("Need more flight time");
        }
    }

    public void UnlockQuintuple()
    {
        //20 coins for 5
        if (DatabaseManager.instance.database.money >= 20)
        {
            DatabaseManager.instance.database.money -= 20;
            DatabaseManager.instance.database.setPlayerWeaponUpgrade("QuintupleGun", true);
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    public void UnlockHomingMissile()
    {
        // prcos chance of shooting a missile
        if (DatabaseManager.instance.database.playerWeaponUpgrade("QuintupleGun") && DatabaseManager.instance.database.money >= 50)
        {
            DatabaseManager.instance.database.money -= 50;
            DatabaseManager.instance.database.setPlayerWeaponUpgrade("HomingMissile",true) ;
            Debug.Log(DatabaseManager.instance.database.playerWeaponUpgrade("QuintupleGun"));
        }
        else
        {
            Debug.Log("Please unlock quintuple gunfirst!, and check your balance");
        }
    }
}
