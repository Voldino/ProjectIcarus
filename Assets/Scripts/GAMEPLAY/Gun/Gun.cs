using UnityEngine;

public class Gun : MonoBehaviour
{
    private Bullet.SENDER SENDER = Bullet.SENDER.ENEMY;

    public void Shoot(string tag,Transform muzzleTransform,int pattern)
    {
        SoundManager.Instance.Play("Shoot");
        if (pattern == 0) pattern0(tag, muzzleTransform);
        else if (pattern == 1) pattern1(tag, muzzleTransform); 
    }

    private void pattern0(string tag, Transform muzzleTransform)
    {
        
            Bullet newBullet = createBullet(tag, muzzleTransform.position, muzzleTransform.transform.rotation) ;
            newBullet.setSender(SENDER);
            newBullet.setDamage(GetComponent<Ship>().getDamage());
            newBullet.setBulletSpeed(GetComponent<Ship>().getBulletSpeed());

    }

    private void pattern1(string tag, Transform muzzleTransform)
    {
        float startAngle = 90.0f ;
        float endAngle = 270.0f  ;
        int number_of_bullet = 5;

        Quaternion originalMuzzleQuaternion = muzzleTransform.rotation;  
        Quaternion shootingQuaterrnion = muzzleTransform.transform.rotation; 
        float step = (endAngle - startAngle) / number_of_bullet;

        for (int i = 0; i < number_of_bullet / 2; i++)
        {
            muzzleTransform.transform.Rotate(new Vector3(0, 0, -step));
        }

        for (int i = 0; i < number_of_bullet; i++)
        {
            Bullet newBullet = createBullet(tag, muzzleTransform.position, muzzleTransform.transform.rotation);
            newBullet.setSender(SENDER);
            newBullet.setDamage(GetComponent<Ship>().getDamage());
            newBullet.setBulletSpeed(GetComponent<Ship>().getBulletSpeed());

        
            muzzleTransform.transform.Rotate(new Vector3(0, 0, step));
        }

        muzzleTransform.rotation = originalMuzzleQuaternion;
    }

    private Bullet createBullet(string tag ,Vector3 position, Quaternion rotation)
    {
        Bullet newBullet = ObjectPool.PoolInstance.SpawnFromPool(tag, position, rotation); 

        return newBullet;
    }

    public void setSender(Bullet.SENDER SENDER)
    {
        this.SENDER = SENDER; 
    }
}
