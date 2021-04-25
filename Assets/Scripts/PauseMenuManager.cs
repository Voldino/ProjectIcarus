using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    enum StateMachine {PLAY,PAUSE};
    private StateMachine state = StateMachine.PLAY;

    private GameObject PauseMenu;
    private void Start()
    {
        if (!PauseMenu) PauseMenu = transform.Find("PauseMenu").gameObject;
        PauseMenu.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (state == StateMachine.PLAY) Pause(); 
            else Play(); 
        }    
    }

    public void Pause()
    {
        PauseMenu.SetActive(true); 
        state = StateMachine.PAUSE;
        Time.timeScale = 0.0f; 
    }

    public void Play()
    {
        PauseMenu.SetActive(false);
        state = StateMachine.PLAY;
        Time.timeScale = 1.0f; 
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
