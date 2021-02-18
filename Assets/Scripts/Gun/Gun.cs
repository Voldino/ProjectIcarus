using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(GameObject bullet,Transform muzzleTransform,int pattern)
    {
        if (pattern == 0) pattern0(bullet, muzzleTransform,1);
        else if (pattern == 1) pattern1(bullet, muzzleTransform,5); 
    }

    private void pattern0(GameObject bullet, Transform muzzleTransform,int number_of_bullet)
    {
        for (int i = 0; i < number_of_bullet; i++) Instantiate(bullet, muzzleTransform.position, muzzleTransform.transform.rotation);
    }

    private void pattern1(GameObject bullet, Transform muzzleTransform, int number_of_bullet)
    {
        float startAngle = 90.0f ;
        float endAngle = 270.0f  ;


        Quaternion shootingQuaterrnion = muzzleTransform.transform.rotation; 
        float step = (endAngle - startAngle) / number_of_bullet;

        for (int i = 0; i < number_of_bullet / 2; i++)
        {
            muzzleTransform.transform.Rotate(new Vector3(0, 0, -step));
        }

        for (int i = 0; i < number_of_bullet; i++)
        {
            Instantiate(bullet, muzzleTransform.position, muzzleTransform.transform.rotation);

            muzzleTransform.transform.Rotate(new Vector3(0, 0, step));
        }

        muzzleTransform.rotation = new Quaternion(0, 0, 0, 0);
    }
}
