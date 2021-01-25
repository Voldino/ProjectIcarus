using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    private string stateMachine = "Rest"; 
    
    [SerializeField] private GameObject playerGameObejct;
 
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    private void lookAtPlayer()
    {
        Vector2 direction = new Vector2(playerGameObejct.transform.position.x - transform.position.x,playerGameObejct.transform.position.y - transform.position.y);
        transform.up = direction; 

    }

 
}
