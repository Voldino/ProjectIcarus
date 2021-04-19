using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScreen : MonoBehaviour
{
    public void playGame() 
    {
        TransitionManager.instance.Sc_GamePlay();
        SoundManager.Instance.Play("NormalStages");
    }

}
