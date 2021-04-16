using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowMoney : MonoBehaviour
{
    Text t;
    private void Start()
    {
        t = GetComponent<Text>(); 
    }

    private void Update()
    {
        t.text = "Money : " + DatabaseManager.instance.database.money; 
    }
}
