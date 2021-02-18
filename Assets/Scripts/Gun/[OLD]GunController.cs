/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunContawdroller : MonoBehaviour
{
    public GameObject bullet;
    private Transform muzzleTransform;

    private float delayTime; 
    private float delayCountdown;

    [HideInInspector] public float  damage;
    [HideInInspector] public int pattern = 0;
    [HideInInspector] public int number_of_bullets = 1;




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
            if (pattern == 1) number_of_bullets = 1;
            else if (pattern == 2) number_of_bullets = 5;
            gameObject.GetComponent<Gun>().startPattern(muzzleTransform,damage,bullet,number_of_bullets, pattern);
            delayCountdown = delayTime ;
        }
    }

    public void setDelayTime(float delayTime)
    {
        this.delayTime = delayTime; 
    }

    public void setDamage(float damage)
    {
        this.damage = damage; 
    }
}
*/