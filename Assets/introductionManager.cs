using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introductionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(countDown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator countDown()
    {
        yield return new WaitForSeconds(8.45f);
        SceneManager.LoadScene(1);
    }
}
