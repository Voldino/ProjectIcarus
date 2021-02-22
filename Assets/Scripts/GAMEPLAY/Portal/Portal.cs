using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Vector3 startPoint = new Vector3(-8,0,0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            GameObject.FindObjectOfType<SpawnerManager>().nextPhase(1);
            collision.gameObject.transform.position = startPoint; 
            gameObject.SetActive(false); 
        }
    }
}
