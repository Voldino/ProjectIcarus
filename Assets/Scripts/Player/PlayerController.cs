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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Shoot");
        }
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

}
