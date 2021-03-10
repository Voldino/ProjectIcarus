using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SpawnerManager : MonoBehaviour
{
    public int Phase = 0;

    [SerializeField] private List<Ship> ship_list;
    [SerializeField] private List<GameObject> obstacles_list;
    [SerializeField] private List<GameObject> bosses_list; 

    [SerializeField] private List<Spawner> topSideSpawner;
    [SerializeField] private List<Spawner> rightSideSpawner;
    [SerializeField] private List<Spawner> bottomSideSpawner;
    [SerializeField] private List<Spawner> leftSideSpawner;
    [SerializeField] private List<Spawner> aLLSpawner;

    [SerializeField] private float spawnDelay = 1;
    private float spawnCountDown = 0f;
    private int number_of_boss = 0;

    private GameObject Portal;

    public static List<GameObject> activeShip = new List<GameObject>();  //When ship destroyed, it will be removed from activeShip by itself in Ship.cs 
    public static List<GameObject> activeBullet = new List<GameObject>(); 

    void Start()
    {
        Phase = 0;
        Portal = GameObject.FindObjectOfType<Portal>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCountDown += 1 * Time.deltaTime;
        spawn();

        if (Input.GetKeyDown(KeyCode.P))
        {
            openPortal();
        }

        DeactiveShip();
    }

    private void DeactiveShip()
    {
 

    }

    public void nextPhase(int increasePhase) //Used for increaseing phase 
    {
        print("Phase " + Phase);
        Phase += increasePhase;
        foreach (GameObject gameobj in activeShip)
        {
            if (gameobj) Destroy(gameobj);
        }

        foreach (GameObject gameobj in activeBullet)
        {
            if (gameobj) Destroy(gameobj); 
        }

        ObjectPool.PoolInstance.DestroyAllBullet(); 

        if (Phase == 5)
        {
            SceneManager.LoadScene(0);  
        }

        activeShip.Clear(); 

           
    }

    public void openPortal() //Portal will be opened (set active) 
    {
        Portal.SetActive(true);
    }

    private void spawn() //Spawn enemies randomly according to phase
    {
        if (spawnCountDown >= spawnDelay || activeShip.Count == 0)
        {
            spawnCountDown = 0f; 
            if (Phase == 2)
            {
                foreach (Spawner spawner in rightSideSpawner)
                {
                    if (Random.Range(1, 4) == 1)
                    {
                        spawner.spawn(ship_list[Random.Range(0, ship_list.Count)].gameObject);
                    }

                    else if (Random.Range(1, 10) == 1)
                    {
                        spawner.spawn(obstacles_list[Random.Range(0,obstacles_list.Count)]);
                    }
                }
            }
            else if (Phase == 4)
            {
                foreach (Spawner spawner in topSideSpawner)
                {
                    if (Random.Range(1, 4) == 1)
                    {
                        if (Random.Range(1, 4) == 1)
                        {
                            spawner.spawn(ship_list[Random.Range(0, ship_list.Count)].gameObject);
                        }
                    }
                }
            }
            else if (Phase == 3)
            {
                int i = 0;
                foreach (Spawner spawner in rightSideSpawner)
                {
                    i++;
                    if (number_of_boss == 0 && i == 3)
                    {
                        spawner.spawn(bosses_list[Random.Range(0, bosses_list.Count+1)]);
                        number_of_boss++;
                    }

                    else if (Random.Range(1, 10) == 1)
                    {
                        spawner.spawn(obstacles_list[Random.Range(0, obstacles_list.Count+1)]);
                    }
                }
            }
            else
            {
                foreach (Spawner spawner in aLLSpawner)
                {
                    if (Random.Range(1, 4) == 1)
                    {
                        spawner.spawn(ship_list[Random.Range(0, ship_list.Count)].gameObject);
                    }

                    else if (Random.Range(1, 10) == 1)
                    {
                        spawner.spawn(obstacles_list[Random.Range(0, obstacles_list.Count)]);
                    }
                }
            }
        }
    }


}
