using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 moveDirection;  
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * Time.deltaTime*5f); 
    }

    public void newDirection(Vector2 _moveDirection)
    {
        moveDirection = _moveDirection; 
    }
 
}
