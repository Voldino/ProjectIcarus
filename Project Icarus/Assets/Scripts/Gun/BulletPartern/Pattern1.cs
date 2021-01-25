using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern1 : MonoBehaviour
{
 

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startP1(Transform muzzleTransform,GameObject bullet)
    {
        int numberOfBullet = 10; ;
        float startAngle = 180f;
        float endAngle = 180f;

        float DirX = 0;
        float DirY = 0;
        float angle = startAngle;
        float step = (endAngle - startAngle) / numberOfBullet;

        for (int i = 0; i < numberOfBullet+1; i++) 
        {
            DirX = muzzleTransform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            DirY = muzzleTransform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 Dir = new Vector3(DirX, DirY,0);
            Vector2 bulDir = (Dir - muzzleTransform.position).normalized;

            GameObject bul = Instantiate(bullet, muzzleTransform.transform.position, bullet.transform.rotation);
            bul.GetComponent<Bullet>().newDirection(bulDir);

            angle += step; 
        }

    }
}
