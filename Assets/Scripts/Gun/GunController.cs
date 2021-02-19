using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform muzzleTransform;
    [SerializeField] private List<GameObject> bullets;

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
        if (countTime >= delayTime + Random.Range(-0.5f,0.5f))
        {
            countTime = 0; 
            Shoot(); 
        }
    }

    public void Shoot()
    {
        if (bullets.Count > 0) GetComponent<Gun>().Shoot(bullets[0], muzzleTransform,GetComponent<Ship>().pattern); 
    }

    public void Shoot(GameObject bullet)
    {
        GetComponent<Gun>().Shoot(bullet, muzzleTransform,1); 
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
