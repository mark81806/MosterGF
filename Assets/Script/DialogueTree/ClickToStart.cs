using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToStart : MonoBehaviour
{
    public void StartDialogue()
    {
        //StoryManager.self.StartStory("Data/First");
        //StoryManager.self.StartStory("Data/0緣起");
        StoryManager.self.StartStory("Data/1慌亂的現實");
    }
}