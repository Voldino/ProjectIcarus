using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunController : MonoBehaviour
{
    [SerializeField] private List<Bullet> bullets;
    private Transform muzzleTransform; 

    private float delayTime;
    private float delayCount = 0;

    private float damage = 0;

    // Start is called before the first frame update
    void Start()
    {
        muzzleTransform = gameObject.transform.Find("Muzzle").transform;
        delayTime = GetComponent<Ship>().getDaleyTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (delayCount < delayTime) delayCount += 1 * Time.deltaTime;
    }

    public void Shoot()
    {
        if (bullets.Count > 0 && delayCount >= delayTime)
        {
            if(bullets.Count > 0 ) GetComponent<PlayerGun>().Shoot(bullets[0], gameObject.GetComponent<Ship>().getPattern() );
            delayCount = 0;
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
