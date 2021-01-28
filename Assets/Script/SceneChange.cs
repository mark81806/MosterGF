using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void Start()
    {
        PlayerData.self.HaveSaveFile = true;
    }
    public void StoryMode() 
    {
        Debug.Log(GameData.self.chapter_unlock_request[PlayerData.self.GameProgress]);
        if (PlayerData.self.SoulAmount < GameData.self.chapter_unlock_request[PlayerData.self.GameProgress])
        {
            Debug.Log("nomoney");
        }
        else
        {
            SaveData();
            SceneManager.LoadScene(0);
        }

    } 
    public void MainScene() 
    {
        SaveData();
        SceneManager.LoadScene(1);
    }
    public void HuntMode() 
    {
        SaveData();
        SceneManager.LoadScene(2);
    }
    private void SaveData()
    {
        PlayerData.self.SaveData();
    }
}
