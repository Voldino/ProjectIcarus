using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulwlet : MonoBehaviour
{
    [HideInInspector] Vector2 moveDirection;
    [HideInInspector] public float speed = 1f;
    [HideInInspector] private float damage; 
    // Start is called before the first frame update
    void Start()
    {
    }

    public void setDamage(float damage)
    {
        this.damage = damage; 
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate( moveDirection   * Time.deltaTime * speed); 
    }

    public void newDirection(Vector2 _moveDirection)
    {
        moveDirection = _moveDirection ; 
    }

 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {

        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.GetComponent<Ship>().Hit(damage);
        }

        Destroy(gameObject);

    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }





}
