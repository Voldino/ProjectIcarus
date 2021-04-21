using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Database", menuName = "ScriptableObjects/Database")]
public class Database : ScriptableObject
{

    public bool FirstTime = true ;
    //using tags  
    public bool NormalGun = false,
        QuintupleGun = false ,
        HomingMissile = false ;

    public float Attack = 0,
        Speed = 0, 
        HP = 0 ;
    //public Dictionary <string , bool> playerWeaponUpgrade ; //NormalGun , QuintupleGun , HomingMissile
    //public Dictionary<string, float> increasedStats; //Attack , Speed , HP 
    //

    public float flightTime;
    public int money;
    
    public float getIncreasedStats(string tag)
    {
        if (tag == "Attack") return Attack;
        else if (tag == "Speed") return Speed;
        else if (tag == "HP") return HP;
        return -1.0f;
    }

    public void increasedStats(string tag,float f)
    {
        if (tag == "Attack") Attack += f;
        else if (tag == "Speed") Speed += f;
        else if (tag == "HP") HP += f; 
    }

    public bool playerWeaponUpgrade(string tag)
    {
        if (tag == "NormalGun") return NormalGun;
        else if (tag == "QuintupleGun") return QuintupleGun;
        else if (tag == "HomingMissile") return HomingMissile;

        return false; 

    }

    public void setPlayerWeaponUpgrade(string tag,bool b)
    {
        if (tag == "NormalGun") NormalGun = b ;
        else if (tag == "QuintupleGun") QuintupleGun = b ;
        else if (tag == "HomingMissile") HomingMissile = b ;
    }




}
