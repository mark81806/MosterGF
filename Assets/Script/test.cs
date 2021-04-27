using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour 
{
  public void onclick1() 
    {
        PlayerSaveData saveData = new PlayerSaveData();
        saveData = SaveLoadData.LoadData();
        Debug.Log(saveData.teeeeee);
        saveData.teeeeee += 1;
        SaveLoadData.SaveData(saveData);
    }
}