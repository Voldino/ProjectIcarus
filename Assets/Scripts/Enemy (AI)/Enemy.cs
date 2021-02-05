using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float HP = 1;
    private float attack = 1;
    private float speed = 3; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit(float damage)
    {
        HP -= damage;
    }

    public float getSpeed()
    {
        return speed; 
    }

    public float getAttack()
    {
        return attack; 
    }

    public float getHP()
    {
        return HP; 
    }
}
