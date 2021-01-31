using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public enum stateMachine {SPAWNING,WAITING};
    private stateMachine state = stateMachine.SPAWNING;  
    private List<Enemy> currentEnemies;
    private List<Enemy> template_enemy; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemies.Count <= 0 && state != stateMachine.SPAWNING)
        {
            state = stateMachine.SPAWNING;
            Next();  
        }
    }
    
    private void Next()
    {
        
    }
}
