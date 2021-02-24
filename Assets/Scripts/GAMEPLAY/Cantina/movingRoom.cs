using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingRoom : MonoBehaviour
{
    public Transform t1;
    public GameObject s1;
    public Transform t2;
    public GameObject s2;

    public void moveToRoom() 
    {
        s1.transform.position = t1.transform.position;
    }

    public void moveToCantina()
    {
        t2.transform.position = s2.transform.position;
    }

}
