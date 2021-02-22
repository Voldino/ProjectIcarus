using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private enum StateMachine { IDLE, ATTACK, MOVE };
    private StateMachine state = StateMachine.IDLE;

    public float verticalInputAcceleration = 1;
    public float horizontalInputAcceleration = 20;

    public float maxSpeed = 10;
    public float maxRotationSpeed = 100;

    public float velocityDrag = 1;
    public float rotationDrag = 1;

    private Vector3 velocity;
    private float zRotationVelocity;

    private void Update()
    {
        if (Input.GetAxisRaw("Vertical") == 1) {
            Impulse();
        }

        // apply turn input
        float zTurnAcceleration = -1 * Input.GetAxis("Horizontal") * horizontalInputAcceleration;
        zRotationVelocity += zTurnAcceleration /** Time.deltaTime*/;

        outOfBount();
        if (Input.GetKey(KeyCode.Space)) {
            PlayerGunController playerGunController = GetComponent<PlayerGunController>();
            playerGunController.Shoot(); 
        }
    }

    private void FixedUpdate()
    {
        // apply velocity drag
        velocity = velocity * (1 - Time.deltaTime * velocityDrag);

        // clamp to maxSpeed
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        // apply rotation drag
        zRotationVelocity = zRotationVelocity * (1 - Time.deltaTime * rotationDrag);

        // clamp to maxRotationSpeed
        zRotationVelocity = Mathf.Clamp(zRotationVelocity, -maxRotationSpeed, maxRotationSpeed);

        // update transform
        transform.position += velocity * Time.deltaTime;
        transform.Rotate(0, 0, zRotationVelocity * Time.deltaTime);
    }

    private void Impulse() {
        // apply forward input
        Vector3 acceleration = Input.GetAxis("Vertical") * verticalInputAcceleration * transform.up;
        velocity += acceleration * Time.deltaTime;
    }

    private void outOfBount()
    {
        float yBound = 5.35f, xBound = 9.10f;
        if (transform.position.y > yBound) transform.position = new Vector2(transform.position.x, -transform.position.y + 0.1f); 
        else if (transform.position.y < -yBound) transform.position = new Vector2(transform.position.x, -transform.position.y - 0.1f);
        
        if (transform.position.x > xBound) transform.position = new Vector2(-transform.position.x + 0.1f, transform.position.y);
        else if (transform.position.x < -xBound) transform.position = new Vector2(-transform.position.x - 0.1f, transform.position.y);
    }


    public void Hit(float damage)
    {
        gameObject.GetComponent<Ship>().Hit(damage);
    }

}
