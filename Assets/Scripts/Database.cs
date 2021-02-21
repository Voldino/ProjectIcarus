using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    [HideInInspector] static public List<int> playerWeaponUpgrade;
    [HideInInspector] static public List<int> playerSkillUnlocked ; 
    [HideInInspector] static float flightTime ;
    [HideInInspector] static int exp ;  

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindObjectOfType<PlayerController>()) flightTime += 1 * Time.deltaTime; //If player still alive, increase flightTime. 
    }
}
