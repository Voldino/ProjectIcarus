using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAutomatic : MonoBehaviour
{
    [SerializeField] private GameObject doorGameObject;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OpenDoor();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CloseDoor();
        }
    }

    public void OpenDoor()
    {
        animator.SetBool("Open", true);
    }
    public void CloseDoor()
    {
        animator.SetBool("Open", false);
    }
}
