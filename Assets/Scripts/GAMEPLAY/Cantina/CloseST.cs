using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseST : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool ispressed = false;
    public GameObject obj;

    void Update()
    {
        if (ispressed)
        {
            obj.transform.Translate(-20f, 0, 0);
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ispressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        ispressed = false;
    }
}
