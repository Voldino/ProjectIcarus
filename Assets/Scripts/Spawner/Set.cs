using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set : MonoBehaviour
{
    public List<Transform> waypoints_transform;

    private void Start()
    {
        GameObject waypoints = GameObject.Find("waypoitns").gameObject; 
        for (int i = 1; i <= waypoints.transform.childCount; i++)
        {

        }
    }

}
