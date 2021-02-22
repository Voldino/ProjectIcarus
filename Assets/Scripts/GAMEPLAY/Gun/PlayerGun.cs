using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    private Transform muzzleTransform; 

    void Start()
    {
        muzzleTransform = gameObject.transform.Find("Muzzle").transform; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(Bullet bullet, int pattern )
    {
        if (pattern == 0) playerPattern0(bullet);
        else if (pattern == 1) playerPattern1(bullet);
    }

    private void playerPattern0(Bullet bullet)
    {
        Bullet newBullet = Instantiate(bullet, muzzleTransform.position, muzzleTransform.rotation) as Bullet;
         newBullet.setSender(Bullet.SENDER.PLAYER); 
    }

    private void playerPattern1(Bullet bullet)
    {
        int number_of_bullet = 5; 

        float startAngle = 90.0f;
        float endAngle = 270.0f;


        Quaternion shootingQuaterrnion = muzzleTransform.transform.rotation;
        float step = (endAngle - startAngle) / number_of_bullet;

        for (int i = 0; i < number_of_bullet / 2; i++)
        {
            muzzleTransform.transform.Rotate(new Vector3(0, 0, -step));
        }

        for (int i = 0; i < number_of_bullet; i++)
        {
            Bullet newBullet = Instantiate(bullet, muzzleTransform.position, muzzleTransform.transform.rotation);
            newBullet.setSender(Bullet.SENDER.PLAYER);

            muzzleTransform.transform.Rotate(new Vector3(0, 0, step));
        }

        muzzleTransform.rotation = new Quaternion(0, 0, 0, 0);
    }
}
