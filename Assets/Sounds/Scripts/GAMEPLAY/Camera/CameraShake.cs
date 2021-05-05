using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public void Shake(float duration, float magnitude) {
        StartCoroutine(cameraShake(duration, magnitude));
    }


    private IEnumerator cameraShake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;
        float elased = 0.0f; 
        while (elased < duration)
        {
            float x = Random.Range(-0.5f, 0.5f) * magnitude;
            float y = Random.Range(-0.5f, 0.5f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            yield return null ;

            elased += 1 * Time.deltaTime; 
        }

        transform.localPosition = originalPos; 
    }

}
