using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public BtnCtl a;
    public static SceneChange self;
    private void Awake() 
    {
        self = this;
    }
    public void StoryMode(string storyNum)
    {
        if (PlayerData.self.SoulAmount < GameData.self.chapter_unlock_request[PlayerData.self.GameProgress])
        {
            Debug.Log("nomoney");
        }
        else
        {
            BuffData.buffdata = -1;
            SaveData();
            SceneManager.LoadScene(0);
        }
    }
    public void cleardata() 
    {
        PlayerData.self.GameProgress = 0;
        PlayerData.self.SaveData();
    }
    public void MainScene() 
    {
        Loading.self.BlackOut();
        SaveData();
        SceneManager.LoadScene(1);
    }
    public void HuntMode() 
    {
        //Loading.self.BlackIn();
        SaveData();
        SceneManager.LoadScene(2);
    }
    private void SaveData()
    {
        PlayerData.self.SaveData();
    }
}
