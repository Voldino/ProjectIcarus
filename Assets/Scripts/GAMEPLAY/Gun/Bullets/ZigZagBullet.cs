using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagBullet : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [SerializeField] private float speed = 2f;

    private Vector3 _startPosition ;
    private float rotateAmount =   Mathf.PI /  2     ;
    private float gap =   Mathf.PI + Mathf.PI / 2;
    void Start()
    {

     }

    private void OnEnable()
    {
        rb2D = GetComponent<Rigidbody2D>();
        speed = GetComponent<Bullet>().getBulletSpeed();
        speed = 2f;


         rotateAmount = Mathf.PI + Mathf.PI / 2;
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.angularVelocity = ( Mathf.Sin(rotateAmount) * 90f );
        rb2D.velocity = gameObject.transform.up * speed;
        rotateAmount += gap/2    * Time.deltaTime ;
  
    }

}
