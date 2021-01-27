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

        transform.Translate( moveDirection   * Time.deltaTime*5f); 
    }

    public void newDirection(Vector2 _moveDirection, Transform muzzleTransform)
    {

        Transform playerTransform = GameObject.Find("Player").gameObject.transform;
        Vector2 _playerDir = new Vector2(playerTransform.position.x - muzzleTransform.position.x,
                                        playerTransform.position.y - muzzleTransform.position.y  
                                         );
        moveDirection = _moveDirection    ; 
    }
 
}
