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
    public void Start() 
    {
        StartDialogue2(PlayerData.self.GameProgress);
    }

    public void StartDialogue()
    {
        //StoryManager.self.StartStory("Data/0緣起");
        StoryManager.self.StartStory("Data/1慌亂的現實");
        //StoryManager.self.StartStory("Data/First");
        //StoryManager.self.StartStory("Data/test");
    }
    public void StartDialogue2(int gameprogress)
    {
        switch (gameprogress)
        {
            case 0:
                StoryManager.self.StartStory("Data/0緣起");
                PlayerData.self.GameProgress += 1;
                PlayerData.self.SaveData();
                break;
            case 1:
                StoryManager.self.StartStory("Data/1慌亂的現實");
                PlayerData.self.GameProgress += 1;
                PlayerData.self.SaveData();
                break;
            case 2:
                StoryManager.self.StartStory("Data/2青澀的回憶");
                PlayerData.self.GameProgress += 1;
                PlayerData.self.SaveData();
                break;
            case 3:
                StoryManager.self.StartStory("Data/3合縱與聯盟");
                PlayerData.self.GameProgress += 1;
                PlayerData.self.SaveData();
                break;
            case 4:
                switch (CheckChoice()) 
                {
                    case 0:
                        StoryManager.self.StartStory("Data/4紙箱與牽繩(上)");
                        PlayerData.self.SaveData();
                        break;
                    case 1:
                        StoryManager.self.StartStory("Data/4-1晴光分章");
                        PlayerData.self.GameProgress += 1;
                        PlayerData.self.Choice = 0;
                        break;
                    case 2:
                        StoryManager.self.StartStory("Data/4-2夜雨分章");
                        PlayerData.self.GameProgress += 1;
                        PlayerData.self.Choice = 0;
                        break;
                }
                break;
            case 5:
                switch (CheckChoice())
                {
                    case 0:
                        StoryManager.self.StartStory("Data/5紙箱與牽繩(下)");
                        PlayerData.self.SaveData();
                        break;
                    case 1:
                        StoryManager.self.StartStory("Data/5-1晴光分章");
                        PlayerData.self.GameProgress += 1;
                        PlayerData.self.Choice = 0;
                        break;
                    case 2:
                        StoryManager.self.StartStory("Data/5-2夜雨分章");
                        PlayerData.self.GameProgress += 1;
                        PlayerData.self.Choice = 0;
                        break;
                }
                break;
            case 6:
                StoryManager.self.StartStory("Data/6學園生活");
                PlayerData.self.GameProgress += 1;
                PlayerData.self.SaveData();
                break;
            case 7:
                StoryManager.self.StartStory("Data/7善意惡意");
                PlayerData.self.GameProgress += 1;
                PlayerData.self.SaveData();
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
}