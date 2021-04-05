using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingRoom : MonoBehaviour
{
    public Transform t1;
    public GameObject s1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        s1.transform.position = t1.transform.transform.position;
    }

}
