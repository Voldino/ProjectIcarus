using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject Panel;
    public GameObject AtkUp;
    public GameObject HpUp;
    public GameObject SpeedUp;

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



}
