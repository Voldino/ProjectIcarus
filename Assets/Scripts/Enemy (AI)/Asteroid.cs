using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private enum StateMachine { IDLE, ATTACKING, MOVING };
    private StateMachine state = StateMachine.IDLE;
    private Vector2 goTo;
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
        float scale = Random.Range(0.07f, 0.1f); 
        gameObject.transform.localScale = new Vector3(scale,scale, 1);
        goTo = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
;       moveDirection = (goTo - (Vector2) gameObject.transform.position).normalized; 
        transform.up = moveDirection ;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3) moveDirection.normalized * GetComponent<Ship>().getSpeed() * Time.deltaTime;
    }

}
