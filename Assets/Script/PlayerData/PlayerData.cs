using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData self;
    bool HaveSaveFile = false;
    public int GameProgress;
    public int SoulAmount;
    public int PowerData;
    public void Awake()
    {
        self = this;
        if (!HaveSaveFile)
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
    }

    public void SaveData()
    {
        //game progess
        PlayerPrefs.SetInt("GameProgress", GameProgress);
        //food amount
        PlayerPrefs.SetInt("SoulAmount", SoulAmount);
        //power data
        PlayerPrefs.SetInt("PowerData", PowerData);
    }

    public void Init()
    {
        //game progess
        PlayerPrefs.SetInt("GameProgress", 0);
        //food amount
        PlayerPrefs.SetInt("SoulAmount", 0);
        //power data
        PlayerPrefs.SetInt("PowerData", 0);
    }
}
