using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bullet;
    private Transform muzzleTransform;

    private float delayCountdown;

    [HideInInspector] public float delayTime;
    [HideInInspector] public float  damage;
    [HideInInspector] public int pattern = 0;




    private void Start()
    {
        muzzleTransform = gameObject.transform.Find("Muzzle"); 
    }
    private void Update()
    {
        Shoot(); 
        delayCountdown -= Time.deltaTime * 1;
    }

    private void Shoot()
    {
        if (delayCountdown <= 0)
        {
            if (pattern == 0) pattern = 1; 
            gameObject.GetComponent<Gun>().startPattern(muzzleTransform,damage,bullet,5,pattern);
            delayCountdown = delayTime ;
        }
    }
}
