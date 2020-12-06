using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void StoryMode() 
    {
        SceneManager.LoadScene(0);
    } 
    public void MainScene() 
    {
        SceneManager.LoadScene(1);
    }
    public void HuntMode() 
    {
        SceneManager.LoadScene(2);
    }
}
