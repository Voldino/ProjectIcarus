using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TransitionManager : MonoBehaviour
{
    private Animator panel_Animator; 

    #region singleton 
    public static TransitionManager instance = null ;
    private void Start()
    {
        if (instance == null)
        {
            panel_Animator = transform.Find("Canvas/BLACK_PANEL").GetComponent<Animator>() ; 
            instance = this;
            DontDestroyOnLoad(gameObject);
            print("A");
        }
        else Destroy(gameObject);
    }
    #endregion

    private IEnumerator LoadThisSc(int index)
    {
        panel_Animator.SetTrigger("PUSH");
        yield return new WaitForSeconds(1.1f);
        panel_Animator.SetTrigger("PULL");

        SceneManager.LoadScene(index);

    }

    public void Sc_MainMenu()
    {
        StartCoroutine(LoadThisSc(1));
    }

    public void Sc_Cantina()
    {
        StartCoroutine(LoadThisSc(2));
    }

    public void Sc_GamePlay()
    {
        StartCoroutine(LoadThisSc(3));
    }
}
