using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    //using tags  
    [HideInInspector] public Dictionary <string , bool> playerWeaponUpgrade; //NormalGun , QuintupleGun , HomingMissile
    [HideInInspector]  public Dictionary <string , float> increasedStats; //Attack , Speed , HP 
    //

    [HideInInspector]  public float flightTime;
    [HideInInspector]  public int money;

    public static Database instance = null;

    #region singleton 

    void Awake()
    { 
        if (instance == null)
        {
            instance = this;

            increasedStats = new Dictionary<string, float>();
            playerWeaponUpgrade = new Dictionary<string, bool>();

            string[] statName = { "Attack", "Speed", "HP" };
            string[] playerWeaponName = { "NormalGun", "QuintupleGun", "HomingMissile"};

            for (int i = 0; i < statName.Length; i++)
            {
                increasedStats.Add(statName[i], 0.0f)    ;
            }

            for (int i = 0; i < playerWeaponName.Length; i++)
            {
                playerWeaponUpgrade.Add(playerWeaponName[i], false); 
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
        else if (Input.GetKeyDown(KeyCode.M))
        {
            money += 50; 
        }
    }


}
