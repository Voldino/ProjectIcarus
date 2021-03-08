using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform muzzleTransform;
    [SerializeField] private List<string> tags;

    private float delayTime ;
    private float countTime = 0;
    private float damage = 0;
    private int pattern = 0;

    void Start()
    {
        muzzleTransform = transform.Find("Muzzle").transform;
        delayTime = GetComponent<Ship>().getDaleyTime();
    }

    // Update is called once per frame
    void Update()
    {
        countTime += 1 * Time.deltaTime;

        if (gameObject.CompareTag("Enemy"))
        {
            if (countTime >= delayTime + Random.Range(-0.5f, 0.5f)) Shoot();
        }
    }

    public void Shoot()
    {
        if (tags.Count > 0 && countTime >= delayTime)
        {
            print(countTime);
            GetComponent<Gun>().Shoot(tags[GetComponent<Ship>().getCurrentBullet()], muzzleTransform, GetComponent<Ship>().getPattern());
            countTime = 0;
        }
    }

    public void Shoot(Bullet.SENDER SENDER)
    {
        if (tags.Count > 0 && countTime >= delayTime)
        {
            print(countTime);
            GetComponent<Gun>().Shoot(tags[GetComponent<Ship>().getCurrentBullet()], muzzleTransform, GetComponent<Ship>().getPattern());
            GetComponent<Gun>().setSender(SENDER);
            countTime = 0;
        }
    }

    public void Shoot(string tag)
    {
        GetComponent<Gun>().Shoot(tag, muzzleTransform,pattern); 
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
