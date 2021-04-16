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
        if (DatabaseManager.instance.database.flightTime >= 180 && DatabaseManager.instance.database.increasedStats["Attack"] < 9)
        {
            DatabaseManager.instance.database.increasedStats["Attack"] += 3;
            DatabaseManager.instance.database.flightTime -= 180;
            Debug.Log(DatabaseManager.instance.database.increasedStats["Attack"]);
        }
        else
        {
            Debug.Log("Need more flight time");
        }
    }

    public void IncreaseHP()
    {
        if (DatabaseManager.instance.database.flightTime >= 180 && DatabaseManager.instance.database.increasedStats["Attack"] < 9)
        {
            DatabaseManager.instance.database.increasedStats["HP"] += 3;
            DatabaseManager.instance.database.flightTime -= 5;
            Debug.Log(DatabaseManager.instance.database.increasedStats["HP"]);
        }
        else
        {
            Debug.Log("Need more flight time");
        }
    }

    public void IncreaseSpeed()
    {
        if (DatabaseManager.instance.database.flightTime >= 180 && DatabaseManager.instance.database.increasedStats["Attack"] < 9)
        {
            DatabaseManager.instance.database.increasedStats["Speed"] += 3;
            DatabaseManager.instance.database.flightTime -= 180;
            Debug.Log(DatabaseManager.instance.database.increasedStats["Speed"]);
        }
        else
        {
            Debug.Log("Need more flight time");
        }
    }

    //public void UnlockNormal()
    //{
    //    //10 coins for 3
    //    playerWeaponUpgrade["NormalGun"] = true;
    //    Debug.Log(playerWeaponUpgrade["NormalGun"]);
    //}

    public void UnlockQuintuple()
    {
        //20 coins for 5
        if (DatabaseManager.instance.database.money >= 20)
        {
            DatabaseManager.instance.database.money -= 20;
            DatabaseManager.instance.database.playerWeaponUpgrade["QuintupleGun"] = true;
            print(DatabaseManager.instance.database.playerWeaponUpgrade["QuintupleGun"]);
            Debug.Log(DatabaseManager.instance.database.playerWeaponUpgrade["QuintupleGun"]);
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    public void UnlockHomingMissile()
    {
        // prcos chance of shooting a missile
        if (DatabaseManager.instance.database.playerWeaponUpgrade["QuintupleGun"] == true && DatabaseManager.instance.database.money >= 50)
        {
            DatabaseManager.instance.database.money -= 50;
            DatabaseManager.instance.database.playerWeaponUpgrade["HomingMissile"] = true;
            Debug.Log(DatabaseManager.instance.database.playerWeaponUpgrade["QuintupleGun"]);
        }
        else
        {
            Debug.Log("Please unlock quintuple gunfirst!, and check your balance");
        }
    }
}
