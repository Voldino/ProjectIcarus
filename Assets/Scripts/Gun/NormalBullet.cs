using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [SerializeField] private float speed = 3f; 

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.velocity = transform.up * speed ;
    }
}
