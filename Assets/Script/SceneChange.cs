using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public static SceneChange self;
    private void Awake() 
    {
        self = this;
    }
    public void StoryMode() 
    {
        Debug.Log(PlayerData.self.GameProgress);
        Debug.Log(GameData.self.chapter_unlock_request[7]);
        if (PlayerData.self.SoulAmount < GameData.self.chapter_unlock_request[PlayerData.self.GameProgress])
        {
            Debug.Log("nomoney");
        }
        else
        {
            //Loading.self.BlackOut();
            SceneManager.LoadScene(0);
        }

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
