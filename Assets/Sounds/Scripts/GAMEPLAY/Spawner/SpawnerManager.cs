﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SpawnerManager : MonoBehaviour
{
    public int Phase = 0;

    [SerializeField] private List<Ship> ship_list;
    [SerializeField] private List<GameObject> obstacles_list;
    [SerializeField] private List<GameObject> minibosses_list;
    [SerializeField] private List<GameObject> bosses_list;
    [SerializeField] private List<GameObject> powerUps;

    [SerializeField] private List<Spawner> topSideSpawner;
    [SerializeField] private List<Spawner> rightSideSpawner;
    [SerializeField] private List<Spawner> bottomSideSpawner;
    [SerializeField] private List<Spawner> leftSideSpawner;
    [SerializeField] private List<Spawner> aLLSpawner;


    [SerializeField] private float spawnDelay = 15;
    private float spawnCountDown = 15;
    private float spawnPortalIn = 0;
    public int number_of_boss = 0;

    private GameObject Portal;

    public List<GameObject> activeShip = new List<GameObject>();  //When ship destroyed, it will be removed from activeShip by itself in Ship.cs 
    public List<GameObject> activeBullet = new List<GameObject>(); 

    void Start()
    {
        Phase = 1;
        Portal = GameObject.FindObjectOfType<Portal>().gameObject;
        Portal.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        spawnCountDown += 1 * Time.deltaTime;
        spawnPortalIn += 1 * Time.deltaTime ; 
        spawn();
        if (spawnPortalIn >= 15 && number_of_boss <= 0)
        {
            spawnPortalIn = -99999999999f;
            openPortal();
        }
        else if (Input.GetKeyDown(KeyCode.P) )
        {
            spawnPortalIn = -99999999999f;
            openPortal();
        }
    }

 

    public void nextPhase(int increasePhase) //Used for increaseing phase 
    {
        print("Phase " + Phase);
        Phase += increasePhase;
        spawnPortalIn = 0;
        foreach (GameObject gameobj in activeShip)
        {
            if (gameobj) {
                Destroy(gameobj);
            };
        }

        activeShip.Clear();
        activeShip = new List<GameObject>() ;

        foreach (GameObject gameobj in activeBullet)
        {
            if (gameobj)
            {
                Destroy(gameobj);
            }
        }

        activeBullet.Clear(); 

        ObjectPool.PoolInstance.DestroyAllBullet(); 

        if (Phase == 5)
        {
            DatabaseManager.instance.CallSaveData();
            TransitionManager.instance.Sc_Cantina();
        }

        activeShip.Clear();
        number_of_boss = 0;
        spawnCountDown = 0;
           
    }

    public void openPortal() //Portal will be opened (set active) 
    {
        Portal.SetActive(true);
    }

    private void spawn() //Spawn enemies randomly according to phase
    {
        if ((spawnCountDown >= spawnDelay || activeShip.Count == 0 )&& !Portal.activeSelf )
        {
            spawnCountDown = 0f;

            if (Phase == 1)
            {
                foreach (Spawner spawner in aLLSpawner)
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
            else if (Phase == 2)
            {
                int i = 0;
                foreach (Spawner spawner in rightSideSpawner)
                {
                    i++;
                    if (number_of_boss == 0 && i == 3)
                    {
                        int a = Random.Range(0, minibosses_list.Count);
                        spawner.spawn(minibosses_list[a]); // the last one is the final boss, so it isn't included, Noted that Random.Range(x,y) will return x to y-1 when x and y is int)
                        number_of_boss++;
                    }

                    else if (Random.Range(1, 10) == 1)
                    {
                        spawner.spawn(obstacles_list[Random.Range(0, obstacles_list.Count - 1)]);
                    }
                }
            }
            else if (Phase == 3)
            {
                //spawn power up
                    openPortal();
                    int k = Random.Range(0, powerUps.Count);
                    Instantiate(powerUps[k], Vector2.zero, powerUps[k].transform.rotation);
                    spawnCountDown = -1000;
            }
            else if (Phase == 4)
            {
                int i = 0;
                foreach (Spawner spawner in rightSideSpawner)
                {
                    i++;
                    if (number_of_boss == 0 && i == 3)
                    {
                        int a = Random.Range(0, bosses_list.Count);
                        Debug.Log(a);
                        spawner.spawn(bosses_list[a]); // the last one is the final boss, so it isn't included, Noted that Random.Range(x,y) will return x to y-1 when x and y is int)
                        number_of_boss++;
                    }

                    else if (Random.Range(1, 10) == 1)
                    {
                        spawner.spawn(obstacles_list[Random.Range(0, obstacles_list.Count)]);
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