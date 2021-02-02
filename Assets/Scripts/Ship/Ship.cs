using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public int HP = 1;
    public float Arrmor = 0;
    public float Speed = 1;
    public Transform muzzle;

    private void Start()
    {
        muzzle = transform.Find("Muzzle").transform;
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

    private void OnCollisionEnter(Collision collision)
    {
        //if collider is bullet 
    }
}
