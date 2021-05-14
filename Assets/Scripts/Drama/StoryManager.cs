using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    public bool TeachBool;
    public StorySceneManager storySceneManager;
    public static StoryManager self;
    public EventSystem eventSystem;
    public GraphicRaycaster graphicsRaycaster;

    private void Awake ()
    {
        self = this;
        //gameObject.SetActive ( false );
    }

    [HideInInspector]
    public StorySceneManager ssm;

    private void Start ()
    {
        //StartStory ( "Data/Story/Teach" );
    }

    public void StartStory ( string path )                                              
    {
        gameObject.SetActive ( true );
        ssm = GameObject.Instantiate<StorySceneManager> ( storySceneManager , transform );
        StartCoroutine ( new DramaEvent.StoryPlayer ( path ).Play () );                
    }

    public void EndStory ()                                             
    {
        StorySceneManager.ActorSprite.Clear ();
        StorySceneManager.BackgroundSprite.Clear ();
        Invoke ( "CloseStory" , 0.5f );
        SceneChange.self.MainScene();
    }

    public void CloseStory ()                                                    
    {
        GameObject.Destroy ( ssm.gameObject );
        gameObject.SetActive ( false );
    }
}
