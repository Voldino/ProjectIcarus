using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeOpener : MonoBehaviour
{
    public GameObject Panel;
    public GameObject AtkUp;
    public GameObject HpUp;
    public GameObject SpeedUp;
    public GameObject AtkIcon;
    public GameObject HpIcon;
    public GameObject SpeedIcon;

    public void OpenPanel()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;

            Panel.SetActive(!isActive);
        }
    }

    public void OpenButton1()
    {
        if (AtkUp != null)
        {
            bool isActive = AtkUp.activeSelf;

            AtkUp.SetActive(!isActive);
        }
    }

    public void OpenButton2()
    {
        if (HpUp != null)
        {
            bool isActive = HpUp.activeSelf;

            HpUp.SetActive(!isActive);
        }
    }

    public void OpenButton3()
    {
        if (SpeedUp != null)
        {
            bool isActive = SpeedUp.activeSelf;

            SpeedUp.SetActive(!isActive);
        }
    }

    public void OpenIcon1()
    {
        if (AtkIcon != null)
        {
            bool isActive = AtkIcon.activeSelf;

            AtkIcon.SetActive(!isActive);
        }
    }

    public void OpenIcon2()
    {
        if (HpIcon != null)
        {
            bool isActive = HpIcon.activeSelf;

            HpIcon.SetActive(!isActive);
        }
    }

    public void OpenIcon3()
    {
        if (SpeedIcon != null)
        {
            bool isActive = SpeedIcon.activeSelf;

            SpeedIcon.SetActive(!isActive);
        }
    }


}
