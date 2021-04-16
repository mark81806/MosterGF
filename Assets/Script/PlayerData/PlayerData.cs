using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData self;
    public int Choice;
    public int GameProgress;
    public int SoulAmount;
    public int PowerData;
    public string PlayerLogOutTimeString;
    public void Awake()
    {
        self = this;
        if (PlayerPrefs.GetInt("GameProgress") ==0)
        {
            Init();
        }
        ReadData();        
    }
    public void OnApplicationQuit()
    {
        SaveData();
    }
    private void ReadData()
    {
        GameProgress = PlayerPrefs.GetInt("GameProgress");
        SoulAmount = PlayerPrefs.GetInt("SoulAmount");
        PowerData = PlayerPrefs.GetInt("PowerData");
        PlayerLogOutTimeString = PlayerPrefs.GetString("TimeData");
    }

    public void SaveData()
    {
        //game progess
        PlayerPrefs.SetInt("GameProgress", GameProgress);
        //food amount
        PlayerPrefs.SetInt("SoulAmount", SoulAmount);
        //power data
        PlayerPrefs.SetInt("PowerData", PowerData);
        //time data
        GetTime();
    }

    public void Init()
    {
        //game progess
        PlayerPrefs.SetInt("GameProgress", 0);
        //soul amount
        PlayerPrefs.SetInt("SoulAmount", 0);
        PlayerPrefs.SetInt("SoulLimit",1000);
        //power data
        PlayerPrefs.SetInt("PowerData", 1000);
        //playertimedata
        PlayerPrefs.SetString("TimeData","");
    }
    public void GetTime()
    {
        System.DateTime playertimelogout = System.DateTime.Now;
        string LogOutTimeString = playertimelogout.ToString("yyyy-MM-dd HH:mm:ss");
        PlayerPrefs.SetString("TimeData",LogOutTimeString);
    }
}
