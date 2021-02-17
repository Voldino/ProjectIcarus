using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zig_zag : MonoBehaviour
{
    private enum StateMachine { IDLE, ATTACKING, MOVING };
    private StateMachine state = StateMachine.IDLE;
    private Vector2 levelCenter;
    Vector2 moveDirection;
    private Vector2 lookDirection ; 
    private List<Vector2> directions; 

    // Start is called before the first frame update
    void Start()
    {
        prepare();
    }

    private void prepare()
    {
        Vector2 playerPOS = (GameObject.FindObjectOfType<PlayerController>().gameObject.transform.position).normalized;
        levelCenter = new Vector2(0, 0)
;       moveDirection = (levelCenter - (Vector2) gameObject.transform.position).normalized; 
        transform.up = moveDirection ;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3) moveDirection.normalized * GetComponent<Ship>().Speed * Time.deltaTime;
    }

}
