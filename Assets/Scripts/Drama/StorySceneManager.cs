using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorySceneManager : MonoBehaviour
{
    public GameObject Manager;                     
    public Text StoryText;                      //故事用文字
    public Text ActorName;                      //角色名稱文字
    public GameObject ActorNameBox;             //角色名稱框
    public GameObject TalkBox;                  //對話框
    public Transform Actor;                     //放置角色的空間
    public Transform Background;                //放置背景的空間
    public Transform AudioSpace;                //放置音樂的空間
    public Transform Picture;                   //放置插圖的空間
    public Transform Buttons;

    public static bool auto;
    public static bool skip;
    public static bool log;
    public static Dictionary<string , Sprite> ActorSprite = new Dictionary<string , Sprite> ();
    public static Dictionary<string , Sprite> BackgroundSprite = new Dictionary<string , Sprite> ();
}
