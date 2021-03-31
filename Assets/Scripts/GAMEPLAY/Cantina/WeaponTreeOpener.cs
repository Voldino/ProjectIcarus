using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTreeOpener : MonoBehaviour
{
    public GameObject Panel2;
    public GameObject Normal;
    public GameObject Quintuple;
    public GameObject Missile;
    public GameObject NormalIcon;
    public GameObject QuintupleIcon;
    public GameObject MissileIcon;

    public void OpenPanel2()
    {
        if (Panel2 != null)
        {
            bool isActive = Panel2.activeSelf;

            Panel2.SetActive(!isActive);
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

    public void OpenIcon4()
    {
        if (NormalIcon != null)
        {
            bool isActive = NormalIcon.activeSelf;

            NormalIcon.SetActive(!isActive);
        }
    }

    public void OpenIcon5()
    {
        if (QuintupleIcon != null)
        {
            bool isActive = QuintupleIcon.activeSelf;

            QuintupleIcon.SetActive(!isActive);
        }
    }

    public void OpenIcon6()
    { 
        if (MissileIcon != null)
        {
            bool isActive = MissileIcon.activeSelf;

            MissileIcon.SetActive(!isActive);
        }
    }
}
