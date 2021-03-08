using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTreeOpener : MonoBehaviour
{
    public GameObject Panel2;
    public GameObject Normal;
    public GameObject Quintuple;
    public GameObject Missile;

    public void OpenPanel2()
    {
        if (Panel2 != null)
        {
            bool isActive = Panel2.activeSelf;

            Panel2.SetActive(!isActive);
        }
    }

    public void OpenButton4()
    {
        if (Normal != null)
        {
            bool isActive = Normal.activeSelf;

            Normal.SetActive(!isActive);
        }
    }

    public void OpenButton5()
    {
        if (Quintuple != null)
        {
            bool isActive = Quintuple.activeSelf;

            Quintuple.SetActive(!isActive);
        }
    }

    public void OpenButton6()
    {
        if (Missile != null)
        {
            bool isActive = Missile.activeSelf;

            Missile.SetActive(!isActive);
        }
    }
}
