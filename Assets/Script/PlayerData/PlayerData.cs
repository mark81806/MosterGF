using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData self;
    public bool[] chapters; 
    public bool Allclearbool = true;
    public int Choice;
    public int GameProgress;
    public int SoulAmount;
    //public string PlayerLogOutTimeString;
    public void Awake()
    {
        self = this;
        if (PlayerPrefs.GetString("PlayerSave") =="")
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
        PlayerSaveData saveData = new PlayerSaveData();
        saveData = SaveLoadData.LoadData();

        chapters = saveData.chapters;
       // Allclearbool = saveData.AllClearBool;
        Choice = saveData.Choice;
        GameProgress = saveData.GameProgress;
        SoulAmount = saveData.SoulAmount;
}

    public void SaveData()
    {
        PlayerSaveData saveData = new PlayerSaveData();
        saveData = SaveLoadData.LoadData();

        saveData.AllClearBool= Allclearbool;
        saveData.Choice= Choice;
        saveData.GameProgress = GameProgress ;
        saveData.SoulAmount= SoulAmount;

        SaveLoadData.SaveData(saveData);
    }

    public void Init()
    {
        PlayerPrefs.SetString("PlayerSave", "");
    }
    public void ClearData() 
    {
        PlayerPrefs.DeleteAll();
    }
    public void GetTime()
    {
        System.DateTime playertimelogout = System.DateTime.Now;
        string LogOutTimeString = playertimelogout.ToString("yyyy-MM-dd HH:mm:ss");
        PlayerPrefs.SetString("TimeData",LogOutTimeString);
    }
}
