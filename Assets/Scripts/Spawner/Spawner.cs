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
        GunController _gun = _ship.GetComponent<GunController>();
        if (_gun)
        {
            if (_ship.pattern == -1) _gun.setPattern(Random.Range(0, 2)); 
            _gun.setDelayTime(_ship.getDaleyTime());
            _gun.setDamage(_ship.getDamage());
        }
        SpawnerManager.activeShip.Add(_ship); 
    }
}
