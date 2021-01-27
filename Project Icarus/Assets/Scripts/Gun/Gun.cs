using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public int _pattern = 0 ;
    private Transform muzzleTransform;
    private float damage;
    
    private float delay;  
    private void Start()
    {
        muzzleTransform = gameObject.transform.Find("Muzzle"); 
    }
    private void Update()
    {
        Shoot();
        delay -= Time.deltaTime * 1;
    }

    private void Shoot()
    {
        if (delay <= 0)
        {
            if (_pattern == 0) _pattern = 1; 
            gameObject.GetComponent<Pattern>().startPattern(muzzleTransform,bullet,5,_pattern);
            delay = 1f;
        }
    }
}
