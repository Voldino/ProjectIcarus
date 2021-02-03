using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern : MonoBehaviour
{
 

    // Update is called once per frame
    public void startPattern(Transform muzzleTransform, float damage,GameObject bullet, int numberOfBullet,int _pattern)
    {
        switch (_pattern)
        {
            case 1: StartCoroutine(startP1(muzzleTransform,damage,bullet,numberOfBullet)); break;
            case 2: StartCoroutine(startP2(muzzleTransform,damage,bullet,numberOfBullet)); break;
        }
    }

    public IEnumerator startP1(Transform muzzleTransform,float damage,GameObject bullet,int numberOfBullet)
    {
        Transform playerTransform = GameObject.Find("Player").gameObject.transform;
        Vector2 _playerDir = new Vector2(playerTransform.position.x - muzzleTransform.position.x,
                                        playerTransform.position.y - muzzleTransform.position.y
                                        );

        float startAngle = 180f;
        float endAngle = 180f;

        float DirX = 0;
        float DirY = 0;
        float angle = startAngle;
        float step = (endAngle - startAngle) / numberOfBullet;

        for (int i = 0; i < numberOfBullet; i++) 
        {
            DirX = muzzleTransform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f) + _playerDir.x + Mathf.Sin((angle * Mathf.PI) / 180f); ;
            DirY = muzzleTransform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f) + _playerDir.y + Mathf.Sin((angle * Mathf.PI) / 180f); ;

            Vector3 Dir = new Vector3(DirX, DirY,0);
            Vector2 bulDir = (Dir - muzzleTransform.position).normalized;

            GameObject bul = Instantiate(bullet, muzzleTransform.transform.position, bullet.transform.rotation);
            bul.GetComponent<Bullet>().newDirection(bulDir,muzzleTransform);
            bul.GetComponent<Bullet>().setDamage(damage); 

            angle += step;
            yield return new WaitForSeconds(0.1f);
        }

    }

    public IEnumerator startP2(Transform muzzleTransform,float damage, GameObject bullet,int numberOfBullet)
    {
        Transform playerTransform = GameObject.Find("Player").gameObject.transform;
        Vector2 _playerDir = new Vector2(playerTransform.position.x - muzzleTransform.position.x,
                                        playerTransform.position.y - muzzleTransform.position.y
                                        );

        float startAngle = 90f;
        float endAngle = 180f;

        float DirX = 0;
        float DirY = 0;
        float angle = startAngle;
        float step = (endAngle - startAngle) / numberOfBullet;
        
        for (int i = 0; i < numberOfBullet    ; i++)
        {
            DirX = muzzleTransform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f) + _playerDir.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            DirY = muzzleTransform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f) + _playerDir.y + Mathf.Sin((angle * Mathf.PI) / 180f);

            Vector3 Dir = new Vector3(DirX, DirY, 0);
            Vector2 bulDir = (Dir - muzzleTransform.position).normalized;

            GameObject bul = Instantiate(bullet, muzzleTransform.transform.position, bullet.transform.rotation);
            bul.GetComponent<Bullet>().newDirection(bulDir,muzzleTransform);
            bul.GetComponent<Bullet>().setDamage(damage);

            angle += step;
            yield return new WaitForSeconds(0f);

        }


         
    }
}
