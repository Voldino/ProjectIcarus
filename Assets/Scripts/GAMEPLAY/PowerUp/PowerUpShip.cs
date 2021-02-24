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
    private float width = 20f;

    public PowerUp powerUpItem = null;

    private int chance = 10;

    private float countDown = 0;

    private void Start()
    {
        A = gameObject.transform.localPosition;
        B = new Vector3(A.x + width, A.y, 0);
    }
    private void Update()
    {
        countDown += 1 * Time.deltaTime; 
        Move();
        if (countDown > 1)
        {
            DropPowerUp();
            countDown = 0; 
        }
        
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
            if (powerUpItem == null)
            {
                Destroy(gameObject); 
            }
            else
            {
                Vector3 tempVec = A;
                A = B;
                B = tempVec;
            }
        }
    }

    private void DropPowerUp()
    {
        if (Random.Range(0, chance) == 0)
        {
            if (powerUpItem != null)
            {
                PowerUp newPowerUp = Instantiate(powerUpItem, transform.position, powerUpItem.transform.rotation);
                powerUpItem = null;
            }
        }
    }

    public void setPowerUpItem(PowerUp powerUpItem)
    {
        this.powerUpItem = powerUpItem;

    }
}
