using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    private enum StateMachine {IDLE,ATTACKING,MOVING};
    private StateMachine state = StateMachine.IDLE;

    [SerializeField] private LayerMask mask; 
    [SerializeField] private GameObject playerGameObejct;

    private Vector3 destination;
 

    // Start is called before the first frame update
    void Start()
    {
        playerGameObejct = GameObject.FindObjectOfType<PlayerController>().gameObject;
        destination = new Vector3(Random.Range(0, 4), Random.Range(0, 4), 0);
        GetComponent<Ship>().attachMuzzle(gameObject.transform.Find("Muzzle"));
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
        float rotateSpeed = 200f; 
        Vector2 direction = (Vector2) transform.position - (Vector2)playerGameObejct.transform.position ;
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        GetComponent<Rigidbody2D>().angularVelocity = rotateAmount * rotateSpeed;

    }

    private void towardPlayer()
    {
        destination = playerGameObejct.transform.position - destination; 
        state = StateMachine.MOVING;

        Transform playerTransform = GameObject.FindObjectOfType<PlayerController>().gameObject.transform;

        Ray2D ray = new Ray2D(transform.position, (playerTransform.position - transform.position));
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, (playerTransform.position - transform.position),Mathf.Infinity,mask) ;
        if (hit2D)
        {
            if (hit2D.collider.GetComponent<PlayerController>())
            {
                Debug.DrawLine(transform.position, playerTransform.position, Color.green);

                float distance = hit2D.distance;

                if (distance > 0)
                { 
                    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, destination, gameObject.GetComponent<Ship>().getSpeed() * Time.deltaTime);
                }
            }
            else Debug.DrawLine(transform.position, playerTransform.position, Color.red);
        }
        state = StateMachine.IDLE;       
    }

    public void Hit(float damage)
    {
        gameObject.GetComponent<Ship>().Hit(damage);
    }






}
