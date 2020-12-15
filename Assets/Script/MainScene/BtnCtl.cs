using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnCtl : MonoBehaviour
{
    public GameObject SettingBar;
    public GameObject BookBar;
    private bool SettingBarBool = false;
    private bool BookBarBool = false;
    public void OpenSettingBar()    
    {
        if (SettingBarBool)
        { 
            SettingBar.SetActive(false);
            SettingBarBool = false;
        }
        else { 
            SettingBar.SetActive(true);
            SettingBarBool = true;
        }
    }
    public void OpenBookBar()
    {
        if (BookBarBool)
        {
            BookBar.SetActive(false);
            BookBarBool = false;
        }
        else
        {
            BookBar.SetActive(true);
            BookBarBool = true;
        }
    }
    public void MusicCtl() 
    { }
}
