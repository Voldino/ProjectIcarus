using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShip : MonoBehaviour
{
    enum StateMachine {RESTING, MOVING};
    StateMachine state = StateMachine.RESTING; 

    [SerializeField] private Vector3 A;
    [SerializeField] private Vector3 B;

    private float speed = 2.0f;
    private float width = 10f;

    private GameObject powerUpItem = null; 

    private void Start()
    {
        A = gameObject.transform.localPosition;
        B = new Vector3(A.x + width, A.y, 0);
    }
    private void Update()
    {
        Move(); 
    }

    private void Move()
    {
        if (state == StateMachine.RESTING)
        {
            state = StateMachine.MOVING;
            transform.position = Vector3.MoveTowards(gameObject.transform.position, B, speed * Time.deltaTime);
            state = StateMachine.RESTING;
        }

        if (gameObject.transform.position == B)
        {
            Vector3 tempVec = A;
            A = B;
            B = tempVec; 
        }
    }

    private void SpawnPowerUp()
    {
        if (powerUpItem != null)
        {

        }
    }

    public void setPowerUpItem(GameObject powerUpItem)
    {
        this.powerUpItem = powerUpItem; 
    }
}
