using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Database", menuName = "ScriptableObjects/Database")]
public class Database : ScriptableObject
{
    //using tags  
    [HideInInspector] public Dictionary <string , bool> playerWeaponUpgrade; //NormalGun , QuintupleGun , HomingMissile
    [HideInInspector]  public Dictionary <string , float> increasedStats; //Attack , Speed , HP 
    //

    public float flightTime;
    public int money;
 
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
        Debug.Log("MONEY : " + money) ;
    }


}
