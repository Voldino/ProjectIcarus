using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private List<Ship> ship_list ;
    [SerializeField] private List<Spawner> spawner_list;

    public static List<Ship> activeShip = new List<Ship>();  //When ship destroyed, it will be removed from activeShip by itself in Ship.cs 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(activeShip.Count);
        if (Input.GetKeyDown(KeyCode.R))
        {
            foreach (Spawner spawner in spawner_list)
            {
                if (Random.Range(1, 4) == 1)
                {
                    spawner.spawn(ship_list[Random.Range(0, ship_list.Count)]);
                }
            }
        }

    }


}
