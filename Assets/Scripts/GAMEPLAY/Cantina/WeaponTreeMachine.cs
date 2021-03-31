using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTreeMachine : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Array;


    private bool allowOpen = false;

    private void Update()
    {
        if (allowOpen && Input.GetKeyDown(KeyCode.Space)) {
            Open();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            allowOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            allowOpen = false;
        }
    }

    private void Open() 
    {
        for (int i = 0; i < Array.Length; i++) {
            if (Array[i] != null)
            {
                bool isActive = Array[i].activeSelf;

                Array[i].SetActive(!isActive);
            }
        }
    }
}
