using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    //using tags  
    [HideInInspector] static public Dictionary <string , bool> playerWeaponUpgrade; //NormalGun , QuintupleGun , HomingMissile
    [HideInInspector] static public Dictionary <string , float> increasedStats; //Attack , Speed , HP 
    //

    [HideInInspector] static float flightTime;
    [HideInInspector] static int exp;

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
        increasedStats["Attack"] += 1;
        Debug.Log(increasedStats["Attack"]);
    }

    public void IncreaseHP()
    {
        if (increasedStats["Attack"] > 0)
        {
            increasedStats["HP"] += 1;
            Debug.Log(increasedStats["HP"]);
        }
        else
        {
            Debug.Log("Please upgrade attack first!");
        }
    }

    public void IncreaseSpeed()
    {
        if (increasedStats["HP"] > 0)
        {
            increasedStats["Speed"] += 1;
            Debug.Log(increasedStats["Speed"]);
        }
        else
        {
            Debug.Log("Please upgrade hp first!");
        }

    }
}
