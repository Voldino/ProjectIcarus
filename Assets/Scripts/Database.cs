using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    //using tags  
    [HideInInspector] static public Dictionary <string , bool> playerWeaponUpgrade; //NormalGun , QuintupleGun , HomingMissile
    [HideInInspector] static public Dictionary <string , float> increasedStats; //Attack , Speed , HP 
    //

    [HideInInspector] static public float flightTime;
    [HideInInspector] static public int money;

    public static Database instance = null;

    #region singleton 

    void Awake()
    { 
        if (instance == null)
        {
            increasedStats = new Dictionary<string, float>();
            playerWeaponUpgrade = new Dictionary<string, bool>();

            string[] statName = { "Attack", "Speed", "HP" };
            string[] playerWeaponName = { "NormalGun", "QuintupleGun", "HomingMissile"};

            instance = this;
            for (int i = 0; i < statName.Length; i++)
            {
                increasedStats.Add(statName[i], 0.0f)    ;
            }

            for (int i = 0; i < playerWeaponName.Length; i++)
            {
                playerWeaponUpgrade.Add(playerWeaponName[i], true); 
            }

            DontDestroyOnLoad(gameObject)   ;
        }
        else if (instance != this) Destroy(gameObject)  ;
        
    }

    #endregion

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindObjectOfType<PlayerController>()) flightTime += 1 * Time.deltaTime; //If player still alive, increase flightTime. 
    }

    public void IncreaseAttack()
    {
        if (flightTime >= 180 && increasedStats["Attack"] < 9)
        {
            increasedStats["Attack"] += 3;
            flightTime -= 180;
            Debug.Log(increasedStats["Attack"]);
        }
        else 
        {
            Debug.Log("Need more flight time");
        }
    }

    public void IncreaseHP()
    {
        if (flightTime >= 180 && increasedStats["Attack"] < 9)
        {
            increasedStats["HP"] += 3;
            flightTime -= 5;
            Debug.Log(increasedStats["HP"]);
        }
        else
        {
            Debug.Log("Need more flight time");
        }
    }

    public void IncreaseSpeed()
    {
        if (flightTime >= 180 && increasedStats["Attack"] < 9)
        {
            increasedStats["Speed"] += 3;
            flightTime -= 180;
            Debug.Log(increasedStats["Speed"]);
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
        if (money > 20)
        {
            playerWeaponUpgrade["QuintupleGun"] = true;
            Debug.Log(playerWeaponUpgrade["QuintupleGun"]);
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    public void UnlockHomingMissile()
    {
        // prcos chance of shooting a missile
        if (playerWeaponUpgrade["QuintupleGun"] == true && money > 50)
        {
            playerWeaponUpgrade["HomingMissile"] = true;
            Debug.Log(playerWeaponUpgrade["QuintupleGun"]);
        }
        else
        {
            Debug.Log("Please unlock quintuple gunfirst!, and check your balance");
        }
    }
}
