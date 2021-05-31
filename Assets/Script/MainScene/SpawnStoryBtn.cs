using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnStoryBtn : MonoBehaviour
{
    public Vector3 pos = new Vector3(-1050f,4f,0f);
    public BtnCtl a;
    private const string StoryBtnPath = "Prefabs/0";
    public void Start() 
    {
        SpawnStoryBtns();
    }
    private void SpawnStoryBtns()
    {
        for (int i = 0; i <= 10; i++) { 
            Button btn = Instantiate(Resources.Load<Button>(StoryBtnPath), transform) ;
            btn.name = i.ToString();
            btn.transform.localPosition = pos+ new Vector3(220*i, 0, 0);
            btn.onClick.AddListener(delegate () { a.CliclkSceneChange(btn.name); } );
            btn.GetComponentInChildren<Text>().text = i.ToString();
        }
    }
}
