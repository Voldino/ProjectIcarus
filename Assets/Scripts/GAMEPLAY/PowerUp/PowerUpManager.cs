﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    enum StateMachine {MOVING,RESTING};
    private StateMachine state = StateMachine.RESTING;

    private int chance = 10 ; // 1 in chance
    private float waitTime = 1;
    private float timeCounter = 0f;

    [SerializeField] private List<GameObject> powerUp_list;  

    private void Update()
    {
        timeCounter += 1 * Time.deltaTime;
        if (timeCounter >= waitTime)
        {
            timeCounter = 0;  
            if (Random.Range(0, chance) == 0)
            {
                Spawn(); 
            }
        }
    }

    private void Spawn()
    {
        GameObject powerUp = powerUp_list[Random.Range(0, powerUp_list.Count)];
        GameObject powerUpShip = Instantiate(powerUp, gameObject.transform.position, powerUp.transform.rotation)  ;
        powerUpShip.GetComponent<PowerUpShip>().setPowerUpItem(powerUp); 
    }
}
