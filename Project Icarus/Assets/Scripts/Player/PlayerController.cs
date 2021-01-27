using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private enum StateMachine { IDLE, ATTACK, MOVE };
    private StateMachine state = StateMachine.IDLE;

    public float movementSpeed;
    public float rotateSpeed;

    private float verticalInput;
    private float horizontalInput;

    private Vector2 moveVelocity;

    private void Start()
    {

    }

    void Update()
    {
        handleMovement();
        rotate();
    }

    void handleMovement()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput * movementSpeed;
        gameObject.transform.Translate(moveVelocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            gameObject.transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + 5) * rotateSpeed);

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z - 5) * rotateSpeed);
        }

        /*horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");*/
    }

    void rotate()
    {
        /*Vector3 mousePosition = Input.mousePosition;

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;*/


        float rotation = horizontalInput * rotateSpeed;
        transform.Rotate(Vector3.forward * rotation);
    }

    
}
