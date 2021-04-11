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
        if (Database.instance.flightTime >= 180 && Database.instance.increasedStats["Attack"] < 9)
        {
            Database.instance.increasedStats["Attack"] += 3;
            Database.instance.flightTime -= 180;
            Debug.Log(Database.instance.increasedStats["Attack"]);
        }
        else
        {
            Debug.Log("Need more flight time");
        }
    }

    public void IncreaseHP()
    {
        if (Database.instance.flightTime >= 180 && Database.instance.increasedStats["Attack"] < 9)
        {
            Database.instance.increasedStats["HP"] += 3;
            Database.instance.flightTime -= 5;
            Debug.Log(Database.instance.increasedStats["HP"]);
        }
        else
        {
            Debug.Log("Need more flight time");
        }
    }

    public void IncreaseSpeed()
    {
        if (Database.instance.flightTime >= 180 && Database.instance.increasedStats["Attack"] < 9)
        {
            Database.instance.increasedStats["Speed"] += 3;
            Database.instance.flightTime -= 180;
            Debug.Log(Database.instance.increasedStats["Speed"]);
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
        if (Database.instance.money >= 20)
        {
            Database.instance.money -= 20; 
            Database.instance.playerWeaponUpgrade["QuintupleGun"] = true;
            print(Database.instance.playerWeaponUpgrade["QuintupleGun"]);
            Debug.Log(Database.instance.playerWeaponUpgrade["QuintupleGun"]);
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    public void UnlockHomingMissile()
    {
        // prcos chance of shooting a missile
        if (Database.instance.playerWeaponUpgrade["QuintupleGun"] == true && Database.instance.money >= 50)
        {
            Database.instance.money -= 50;
            Database.instance.playerWeaponUpgrade["HomingMissile"] = true;
            Debug.Log(Database.instance.playerWeaponUpgrade["QuintupleGun"]);
        }
        else
        {
            Debug.Log("Please unlock quintuple gunfirst!, and check your balance");
        }
    }
}
