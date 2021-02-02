using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    private enum StateMachine {IDLE,ATTACKING,MOVING};
    private StateMachine state = StateMachine.IDLE;

    [SerializeField] private LayerMask mask; 
    [SerializeField] private GameObject playerGameObejct;
 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        movement(); 
    }

    private void movement()
    {
        lookAtPlayer();
        towardPlayer(); 
    }

    private void lookAtPlayer()
    {
        Vector2 direction = new Vector2(playerGameObejct.transform.position.x - transform.position.x,playerGameObejct.transform.position.y - transform.position.y);
        transform.up = direction; 
    }

    private void towardPlayer()
    {
        state = StateMachine.MOVING;

        Transform playerTransform = GameObject.FindObjectOfType<PlayerController>().gameObject.transform;

        Ray2D ray = new Ray2D(transform.position, (playerTransform.position - transform.position));
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, (playerTransform.position - transform.position)) ;
        if (hit2D)
        {
            Debug.DrawLine(transform.position, playerTransform.position, Color.green);

            float distance = hit2D.distance;
            //print("" + distance);

            if (distance > 5) gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, playerTransform.position, 3.0f * Time.deltaTime);
        }
        else Debug.DrawLine(transform.position, playerTransform.position, Color.red); 

        state = StateMachine.IDLE;  
         
    }




}
