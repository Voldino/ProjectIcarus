using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum SENDER {PLAYER,ENEMY}
    private float damage = 1 ; 
    private float speed = 1 ;
    public SENDER sender; 



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (sender == SENDER.ENEMY)
        {
            if (other.GetComponent<PlayerController>())
            {
                PlayerController playerController = other.GetComponent<PlayerController>();
                playerController.Hit(this.damage); 
                Destroy(gameObject); 
            }    
        }

        if (sender == SENDER.PLAYER) 
        {
            if (other.GetComponent<Enemy_Controller>())
            {
                Enemy_Controller enemyController = other.GetComponent<Enemy_Controller>();
                enemyController.Hit(this.damage);
                Destroy(gameObject);
            }
            else if (other.GetComponent<Asteroid>())
            {
                other.GetComponent<Asteroid>().Hit(damage);
                Destroy(gameObject);
            }
        }

    }


    public void setDamage(float Damage)
    {
        this.damage = Damage;
    }

    public void setSender(SENDER _sender)
    {
        sender = _sender; 
    }

    public void setSpeed(float Speed)
    {
        this.speed = Speed;  
    }

    public float getDamage()
    {
        return damage;
    }

    public float getSpeed()
    {
        return speed;
    }


}
