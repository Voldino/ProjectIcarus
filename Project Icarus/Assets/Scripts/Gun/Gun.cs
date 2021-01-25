using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet; 
    private Transform muzzleTransform;
    private float damage;

    private float waitTime;  
    private void Start()
    {
        muzzleTransform = gameObject.transform.Find("Muzzle"); 
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space   ))Shoot();

        if (waitTime >= 0) waitTime -= Time.deltaTime * 1;
    }

    private void Shoot()
    {
        if (waitTime <= 0)
        {
            gameObject.GetComponent<Pattern1>().startP1(transform,bullet); 
        }
    }
}
