using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlcokAnimation : MonoBehaviour
{
    public Sprite unlocked_sprite;
    [SerializeField] private string tag; 
    private bool unlocked; 

    

    // Update is called once per frame
    void Update()
    {
        if (unlocked_sprite != GetComponent<SpriteRenderer>().sprite)
        {
            if (tag == "HomingMissile")
            {
                if (DatabaseManager.instance.database.HomingMissile)
                {
                    GetComponent<SpriteRenderer>().sprite = unlocked_sprite;
                }
            }
            else if (tag == "Quintuple")
            {
                if (DatabaseManager.instance.database.QuintupleGun)
                {
                    GetComponent<SpriteRenderer>().sprite = unlocked_sprite; 
                }
            }
        }
        
    }
}
