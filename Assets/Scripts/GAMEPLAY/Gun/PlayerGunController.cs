using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunController : MonoBehaviour
{
    [SerializeField] private List<Bullet> bullets;
    private Transform muzzleTransform; 

    private float delayTime;
    private float delayCount = 0;

    private float countTime = 0;
    private float damage = 0;
    private int pattern = 0;

    // Start is called before the first frame update
    void Start()
    {
        muzzleTransform = gameObject.transform.Find("Muzzle").transform;
        delayTime = GetComponent<Ship>().getDaleyTime();
        pattern = GetComponent<Ship>().getPattern(); 
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
            if(bullets.Count > 0 ) GetComponent<PlayerGun>().Shoot(bullets[0], pattern);
            delayCount = 0;
        }

    }

    public void Shoot(Bullet bullet)
    {
        GetComponent<PlayerGun>().Shoot(bullet, pattern);
    }

    public void setPattern(int pattern)
    {
        this.pattern = pattern;
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
