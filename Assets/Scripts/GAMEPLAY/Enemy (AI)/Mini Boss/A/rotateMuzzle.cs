using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateMuzzle : MonoBehaviour
{
    float rotateAmount = 3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(rotateAround()); 
    }
    private void Update()
    {
        if (gameObject.transform.rotation.z > 25 || gameObject.transform.rotation.z < 180 ) rotateAmount *= -1; 
        gameObject.transform.Rotate(new Vector3(0, 0, gameObject.transform.rotation.z+rotateAmount) * Time.deltaTime);
    }
    private IEnumerator rotateAround()
    {
        int i = 0;
        while (true)
        {
            if (gameObject.transform.rotation.z > 25 && rotateAmount > 0) rotateAmount = -rotateAmount;
            print(transform.rotation.z);
            gameObject.transform.Rotate(new Vector3(0, 0, gameObject.transform.rotation.z + rotateAmount) * Time.deltaTime);
            yield return new WaitForSeconds(2); 
        }
    }
}
