using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum SENDER {PLAYER,ENEMY}
    private float Damage = 1 ; 
    private float bulletSpeed = 1 ;
    public SENDER sender; 



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (sender == SENDER.ENEMY)
        {
            if (other.GetComponent<Player>())
            {
                Player player = other.GetComponent<Player>();
                player.Hit(this.Damage); 
                Destroy(gameObject); 
            }    
        }

        if (sender == SENDER.PLAYER) 
        {
            if (other.CompareTag("Enemy"))
            {
                if (other.GetComponent<Ship>())
                {
                    Ship ship = other.GetComponent<Ship>();
                    ship.Hit(this.Damage);
                    Destroy(gameObject);
                }else if (other.GetComponent<Asteroid>())
                {
                    Asteroid asteroid = other.GetComponent<Asteroid>();
                    asteroid.Hit(this.Damage);
                    Destroy(gameObject); 
                }
            }
        }

    }


    public void setDamage(float Damage)
    {
        this.Damage = Damage;
    }

    public void setSender(SENDER _sender)
    {
        sender = _sender; 
    }

    public void setBulletSpeed(float bulletSpeed)
    {
        this.bulletSpeed = bulletSpeed;  
    }

    public float getDamage()
    {
        return Damage;
    }

    public float getBulletSpeed()
    {
        return bulletSpeed;
    }


}
