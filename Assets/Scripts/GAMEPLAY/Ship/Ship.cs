using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private float HP = 1;
    [SerializeField] private float Arrmor = 0;
    [SerializeField] private float Speed = 1;
    [SerializeField] private int pattern = -1;
    [SerializeField] private float bulletSpeed = 1.0f;
    [SerializeField] private float delayTime = 0f;
    [SerializeField] private float damage = 1f;

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
        if (GetComponent<Player>()) GetComponent<Player>().GameOver(); 
        if (gameObject.GetComponent<Enemy_Controller>()) SpawnerManager.activeShip.Remove(this.gameObject);

        FindObjectOfType<CameraShake>().Shake(0.25f, 0.25f);

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

    public void setPattern(int pattern) { this.pattern = pattern;  }

    public void setDaleyTime(float delayTime) { this.delayTime = delayTime; }

    public void setDamage(float damage) { this.damage = damage ; }

    public void setSpeed(float Speed) { this.Speed = Speed; }

    public void setBulletSpeed(float bulletSpeed) { this.bulletSpeed = bulletSpeed;  }

    public void setHP(float HP) { this.HP = HP; }

    public int getPattern() {return pattern;}

    public float getDaleyTime() { return delayTime; }

    public float getDamage() { return damage; }

    public float getSpeed() { return Speed; }

    public float getBulletSpeed() { return bulletSpeed; }

    public float getHP() { return HP;  }
}
