using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float HP = 1;
    public float Arrmor = 0;
    public float Speed = 1;
    public int pattern = -1;
    public float bulletSpeed = 1.0f;
    public float delayTime = 0f;
    public float damage = 1f;

    [HideInInspector] public Transform muzzle;

    private void Start()
    {

    }
    private void Update()
    {
        if (HP <= 0) DestroyShip();
    }

    private void DestroyShip()
    {
        SpawnerManager.activeShip.Remove(this); 
        Destroy(gameObject);  
    }

    public void attachMuzzle(Transform muzzle)
    {
        this.muzzle = muzzle;
    }

    private void OnCollisionEnter(Collision collision)
    {
         
    }

    public void Hit(float damage)
    {
        HP -= damage;
    }


    public float getDaleyTime()
    {
        return delayTime; 
    }

    public float getDamage()
    {
        return damage;
    }
}
