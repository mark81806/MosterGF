using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToStart : MonoBehaviour
{
    public static ClickToStart self;
    private void Awake() 
    {
        self = this;
    }
    public void StartDialogue()
    {
        //StoryManager.self.StartStory("Data/0緣起");
        StoryManager.self.StartStory("Data/1慌亂的現實");
        //StoryManager.self.StartStory("Data/First");
        //StoryManager.self.StartStory("Data/test");
    }
    public void Start()
    {
        int gameprogress = BuffData.buffdata;
        Debug.Log(gameprogress);
        switch (gameprogress)
        {
            case 0:
                StoryManager.self.StartStory("Data/0緣起");
                PlayerData.self.GameProgress += 1;
                PlayerData.self.SaveData();
                SaveBool(gameprogress);
                break;
            case 1:
                StoryManager.self.StartStory("Data/1慌亂的現實");
                PlayerData.self.GameProgress += 1;
                PlayerData.self.SaveData();
                SaveBool(gameprogress);
                break;
            case 2:
                StoryManager.self.StartStory("Data/2青澀的回憶");
                PlayerData.self.GameProgress += 1;
                PlayerData.self.SaveData();
                SaveBool(gameprogress);
                break;
            case 3:
                StoryManager.self.StartStory("Data/3合縱與聯盟");
                PlayerData.self.GameProgress += 1;
                PlayerData.self.SaveData();
                SaveBool(gameprogress);
                break;
            case 4:
                switch (CheckChoice()) 
                {
                    case 0:
                        StoryManager.self.StartStory("Data/4紙箱與牽繩(上)");
                        PlayerData.self.SaveData();
                        SaveBool(gameprogress);
                        break;
                    case 1:
                        StoryManager.self.StartStory("Data/4-1晴光分章");
                        PlayerData.self.GameProgress += 1;
                        PlayerData.self.Choice = 0;
                        SaveBool(gameprogress * 10 + CheckChoice());
                        break;
                    case 2:
                        StoryManager.self.StartStory("Data/4-2夜雨分章");
                        PlayerData.self.GameProgress += 1;
                        PlayerData.self.Choice = 0;
                        SaveBool(gameprogress * 10 + CheckChoice());
                        break;
                }
                break;
            case 5:
                switch (CheckChoice())
                {
                    case 0:
                        StoryManager.self.StartStory("Data/5紙箱與牽繩(下)");
                        PlayerData.self.SaveData();
                        SaveBool(gameprogress);
                        break;
                    case 1:
                        StoryManager.self.StartStory("Data/5-1晴光分章");
                        PlayerData.self.GameProgress += 1;
                        PlayerData.self.Choice = 0;
                        SaveBool(gameprogress * 10 + CheckChoice());
                        break;
                    case 2:
                        StoryManager.self.StartStory("Data/5-2夜雨分章");
                        PlayerData.self.GameProgress += 1;
                        PlayerData.self.Choice = 0;
                        SaveBool(gameprogress * 10 + CheckChoice());
                        break;
                }
                break;
            case 6:
                StoryManager.self.StartStory("Data/6學園生活");
                PlayerData.self.GameProgress += 1;
                PlayerData.self.SaveData();
                SaveBool(gameprogress);
                break;
            case 7:
                StoryManager.self.StartStory("Data/7善意惡意");
                PlayerData.self.GameProgress += 1;
                PlayerData.self.SaveData();
                SaveBool(gameprogress);
                break;
            default:
                Debug.Log("Something in clicktostart went wrong");
                break;
        }
    }
    private int CheckChoice() 
    {
        return PlayerData.self.Choice;
    }
    private void SaveBool(int i ) 
    {
        PlayerSaveData saveData = new PlayerSaveData();
        saveData = SaveLoadData.LoadData();
        saveData.chapters[i] = true;
        SaveLoadData.SaveData(saveData);
    }
}