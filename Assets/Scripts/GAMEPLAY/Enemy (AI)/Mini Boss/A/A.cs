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

    public bool notRotate = false; 


    // Start is called before the first frame update
    void Start()
    {
        prepare();
    }

    private void prepare()
    {

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
