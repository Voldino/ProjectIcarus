using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private enum StateMachine { IDLE, ATTACK, MOVE };
    private StateMachine state = StateMachine.IDLE;

    public int movementSpeed = 0;
    public int rotationSpeed = 0;

    private float _verticalInput = 0;
    private float _horizontalInput = 0;

    private Rigidbody2D rb;

    //private Vector2 moveVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetPlayerInput();

    }

    private void FixedUpdate()
    {

        RotatePlayer();
        MovePlayer();
    }

    private void GetPlayerInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void RotatePlayer()
    {
        float rotation = -_horizontalInput * rotationSpeed;
        transform.Rotate(Vector3.forward * rotation);
    }

    private void MovePlayer()
    {
        rb.velocity = transform.up * Mathf.Clamp01(_verticalInput) * movementSpeed;
    }


    /*void handleMovement()
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

       horizontalInput = Input.GetAxis("Horizontal");
       verticalInput = Input.GetAxis("Vertical");
    }

    void rotate()
    {
        Vector3 mousePosition = Input.mousePosition;

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;


        float rotation = horizontalInput * rotateSpeed;
        transform.Rotate(Vector3.forward * rotation);
    }*/
}
