using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void spawn(Ship ship)
    {
        Ship _ship = Instantiate(ship, transform.position, ship.gameObject.transform.rotation);
        SpawnerManager.activeShip.Add(_ship); 
    }
}
