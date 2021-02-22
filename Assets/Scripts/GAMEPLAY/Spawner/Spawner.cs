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

    public void spawn(GameObject spawnedGameobject)
    {
        GameObject newGameObject = Instantiate(spawnedGameobject, transform.position, spawnedGameobject.transform.rotation);
        GunController _gun = newGameObject.GetComponent<GunController>();
        Ship _ship = newGameObject.GetComponent<Ship>();
        if (_gun && _ship)
        {
            if (_ship.getPattern() == -1) _gun.setPattern(Random.Range(0, 2)); 
            _gun.setDelayTime(_ship.getDaleyTime());
            _gun.setDamage(_ship.getDamage());
        }
        SpawnerManager.activeShip.Add(_ship); 
    }
}
