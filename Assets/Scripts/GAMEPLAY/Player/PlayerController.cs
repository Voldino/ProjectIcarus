﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private enum StateMachine { IDLE, ATTACK, MOVE };
    private StateMachine state = StateMachine.IDLE;
    private Bullet.SENDER SENDER = Bullet.SENDER.PLAYER ;
    [SerializeField]
    private float
    verticalInputAcceleration = 1,
    horizontalInputAcceleration = 20,
    maxSpeed = 10,
    maxRotationSpeed = 100,
    velocityDrag = 1,
    rotationDrag = 1,
    zRotationVelocity = -1; 

    [SerializeField]
    private Vector3 velocity;

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        // apply turn input
        float zTurnAcceleration = -1 * Input.GetAxis("Horizontal") * horizontalInputAcceleration;
        zRotationVelocity += zTurnAcceleration /** Time.deltaTime*/;

        if (Input.GetAxisRaw("Vertical") == 1)
        {
            Impulse();
        }

        if (Input.GetKey(KeyCode.Space)) // Using playerGunController (to shoot) 
        {
            GunController gunController = GetComponent<GunController>();
            gunController.Shoot(SENDER);
        }


        //Swap Weapon 
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GetComponent<Ship>().setPattern(0);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (DatabaseManager.instance.database.playerWeaponUpgrade["QuintupleGun"]) GetComponent<Ship>().setPattern(1);
            else print("Second Weapon is unavailable");
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (DatabaseManager.instance.database.playerWeaponUpgrade["HomingMissile"]) 
            {
                   Ship ship = GetComponent<Ship>();
                   ship.setPattern(0);
                   GetComponent<Ship>().setCurrentBullet(1);
            }
        }

        else if (Input.GetKeyDown(KeyCode.I))
        {
            GetComponent<Ship>().setDamage(99999);
        }

        else if (Input.GetKeyDown(KeyCode.M))
        {
            DatabaseManager.instance.database.money += 1000;
        }
 
    }
    private void FixedUpdate()
    {
        // apply velocity drag
        velocity = velocity * (1 - Time.deltaTime * velocityDrag);

        // clamp to maxSpeed
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        // apply rotation drag
        zRotationVelocity = zRotationVelocity * (1 - Time.deltaTime * rotationDrag);

        // clamp to maxRotationSpeed
        zRotationVelocity = Mathf.Clamp(zRotationVelocity, -maxRotationSpeed, maxRotationSpeed);

        // update transform
        transform.position += velocity * Time.deltaTime;
        transform.Rotate(0, 0, zRotationVelocity * Time.deltaTime);
    }

    private void Impulse() {
        // apply forward input
        Vector3 acceleration = Input.GetAxis("Vertical") * verticalInputAcceleration * transform.up;
        velocity += acceleration * Time.deltaTime;
    }





}
