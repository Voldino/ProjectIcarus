using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public int Phase = 0;

    [SerializeField] private List<Ship> ship_list ;
    [SerializeField] private List<Spawner> topSideSpawner ;
    [SerializeField] private List<Spawner> rightSideSpawner;
    [SerializeField] private List<Spawner> bottomSideSpawner;
    [SerializeField] private List<Spawner> leftSideSpawner;
    [SerializeField] private List<Spawner> aLLSpawner;

    private GameObject Portal; 

    public static List<Ship> activeShip = new List<Ship>();  //When ship destroyed, it will be removed from activeShip by itself in Ship.cs 

    void Start()
    {
        Phase = 0;
        Portal = GameObject.FindObjectOfType<Portal>().gameObject; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            openPortal();
        }
        

    }

    public void nextPhase(int increasePhase)
    {
        Phase += increasePhase;
        foreach (Ship enemy_ship in activeShip) Destroy(enemy_ship.gameObject); 
        spawn();    
    }

    public void openPortal()
    {
        Portal.SetActive(true);
    }

    private void spawn()
    {
        if (Phase == 2)
        {
            foreach (Spawner spawner in rightSideSpawner)
            {
                if (Random.Range(1, 4) == 1)
                {
                    spawner.spawn(ship_list[Random.Range(0, ship_list.Count)]);
                }
            }
        }
        else if (Phase == 4)
        {
            foreach (Spawner spawner in topSideSpawner)
            {
                if (Random.Range(1, 4) == 1)
                {
                    spawner.spawn(ship_list[Random.Range(0, ship_list.Count)]);
                }
            }
        }
        else if (Phase == 3)
        {
            //spawn teasure
        }
        else
        {
            foreach (Spawner spawner in aLLSpawner)
            {
                if (Random.Range(1, 4) == 1)
                {
                    spawner.spawn(ship_list[Random.Range(0, ship_list.Count)]);
                }
            }
        }
    }


}
