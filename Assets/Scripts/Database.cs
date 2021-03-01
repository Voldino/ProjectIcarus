using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    [HideInInspector] static public List<int> playerWeaponUpgrade;
    [HideInInspector] static public List<int> playerSkillUnlocked ; 
    [HideInInspector] static float flightTime ;
    [HideInInspector] static int exp ;

    public static Database instance = null;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            playerWeaponUpgrade = new List<int>() ;
            playerWeaponUpgrade.Add(1);

            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        print(playerWeaponUpgrade.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindObjectOfType<PlayerController>()) flightTime += 1 * Time.deltaTime; //If player still alive, increase flightTime. 
    }
}
