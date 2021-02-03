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
        Gun _gun = _ship.GetComponent<Gun>();

        _gun.pattern = Random.Range(1, 3);
        _gun.delayTime = 2.0f;
        _gun.damage = 1; 

        SpawnerManager.activeShip.Add(_ship); 
    }
}
