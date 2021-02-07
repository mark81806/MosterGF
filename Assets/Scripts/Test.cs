using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
     private void OnGUI()
    {
        if (GUILayout.Button("Start"))
        {
            Debug.Log("run");
            StoryManager.self.StartStory("Data/First");
        }
    }
}
