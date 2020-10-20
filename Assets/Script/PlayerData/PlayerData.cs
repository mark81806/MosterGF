using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    bool HaveSaveFile = false;
    int GameProgress;
    int FoodAmount;
    int PowerData;
    public void Awake()
    {
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
        FoodAmount = PlayerPrefs.GetInt("FoodAmount");
        PowerData = PlayerPrefs.GetInt("PowerData");
    }

    public void SaveData()
    {
        //game progess
        PlayerPrefs.SetInt("GameProgress", GameProgress);
        //food amount
        PlayerPrefs.SetInt("FoodAmount", FoodAmount);
        //power data
        PlayerPrefs.SetInt("PowerData", PowerData);
    }

    public void Init()
    {
        //game progess
        PlayerPrefs.SetInt("GameProgress", 0);
        //food amount
        PlayerPrefs.SetInt("FoodAmount", 0);
        //power data
        PlayerPrefs.SetInt("PowerData", 0);
    }
}
