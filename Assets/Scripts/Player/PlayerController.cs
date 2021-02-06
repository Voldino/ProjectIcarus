using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private enum StateMachine { IDLE, ATTACK, MOVE };
    private StateMachine state = StateMachine.IDLE;

    public float maxSpeed = 10f;
    public float rotSpeed = 180f;

    private void Start()
    {

    }

    void Update()
    {
        //Rotating the ship
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        //Moving the ship
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
        pos += rot * velocity;
        transform.position = pos;
    }


}
