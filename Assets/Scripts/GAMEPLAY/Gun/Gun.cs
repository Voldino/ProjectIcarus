using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public void Shoot(Bullet bullet,Transform muzzleTransform,int pattern)
    {
        if (pattern == 0) pattern0(bullet, muzzleTransform);
        else if (pattern == 1) pattern1(bullet, muzzleTransform); 
    }

    private void pattern0(Bullet bullet, Transform muzzleTransform)
    {
        
            Bullet newBullet = Instantiate(bullet, muzzleTransform.position, muzzleTransform.transform.rotation) ;
            newBullet.setSender(Bullet.SENDER.ENEMY);
            newBullet.setDamage(GetComponent<Ship>().getDamage());
            newBullet.setBulletSpeed(GetComponent<Ship>().getBulletSpeed());

    }

    private void pattern1(Bullet bullet, Transform muzzleTransform)
    {
        float startAngle = 90.0f ;
        float endAngle = 270.0f  ;
        int number_of_bullet = 5;

        Quaternion shootingQuaterrnion = muzzleTransform.transform.rotation; 
        float step = (endAngle - startAngle) / number_of_bullet;

        for (int i = 0; i < number_of_bullet / 2; i++)
        {
            muzzleTransform.transform.Rotate(new Vector3(0, 0, -step));
        }

        for (int i = 0; i < number_of_bullet; i++)
        {
            Bullet newBullet = Instantiate(bullet, muzzleTransform.position, muzzleTransform.transform.rotation);
            newBullet.setSender(Bullet.SENDER.ENEMY);
            newBullet.setDamage(GetComponent<Ship>().getDamage());
            newBullet.setBulletSpeed(GetComponent<Ship>().getBulletSpeed());


            muzzleTransform.transform.Rotate(new Vector3(0, 0, step));
        }

        muzzleTransform.rotation = new Quaternion(0, 0, 0, 0);
    }
}
