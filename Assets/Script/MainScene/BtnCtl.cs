using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnCtl : MonoBehaviour
{
    public GameObject SettingBar;
    public GameObject BookBar;
    public GameObject UpgradeBar;
    private bool SettingBarBool = false;
    private bool UpgradeBarBool = false;
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
    public void OpenUpgradeBar()
    {
        if (UpgradeBarBool)
        {
            UpgradeBar.SetActive(false);
            UpgradeBarBool = false;
        }
        else
        {
            UpgradeBar.SetActive(true);
            UpgradeBarBool = true;
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
