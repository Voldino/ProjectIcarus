using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helix : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float speed;
    private float highest;
    private float lowest; 

    public bool up ;

    private void Start()
    {
        if (up == true)
        {
            highest = transform.position.y+ 1.5f;
            lowest = transform.position.y - 3;
        }
        else
        {
            highest = transform.position.y + 3;
            lowest = transform.position.y - 1.5f;
        }

        print(highest + " vs " + lowest);
        rb2D = GetComponent<Rigidbody2D>();
        speed = GetComponent<Bullet>().getBulletSpeed();
    }

    void Awake()
    {
        if (up == true)
        {
            print("It's t");
            highest = transform.position.y + 1.5f;
            lowest = transform.position.y - 3;
        }
        else
        {
            print("No it isn't");
            highest = transform.position.y + 3;
            lowest = transform.position.y - 1.5f;
        }

        print(highest + " vs " + lowest);
        rb2D = GetComponent<Rigidbody2D>();
        speed = GetComponent<Bullet>().getBulletSpeed();
    }


        // Update is called once per frame
        void Update()
        {
            if (up)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 1.15f  *Time.deltaTime , transform.position.z); 
            }else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 1.15f * Time.deltaTime, transform.position.z); 
            }

            if (transform.position.y >= highest) up = false;
            else if (transform.position.y <= lowest) up = true; 

            rb2D.velocity = transform.up * speed;

        }
}
