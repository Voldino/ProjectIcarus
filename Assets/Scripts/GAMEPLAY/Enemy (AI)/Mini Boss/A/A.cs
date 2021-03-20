using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A : MonoBehaviour
{
    private float col_damage = 5f;

    private Vector2 goTo;
    private Vector2 moveDirection;
    private Vector2 lookDirection;
    private List<Vector2> directions;


    // Start is called before the first frame update
    void Start()
    {
        prepare();
    }

    private void prepare()
    {
        goTo = new Vector2(0,0);
        moveDirection = (goTo - (Vector2)gameObject.transform.position).normalized;
        transform.up = moveDirection;
    }

    // Update is called once per frame


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Ship>())
        {
            collision.GetComponent<Ship>().Hit(col_damage);
        }
    }


 


}
