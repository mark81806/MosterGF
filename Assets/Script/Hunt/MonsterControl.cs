using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControl : MonoBehaviour
{
    public static MonsterControl self;
    public void awake() 
    {
        self = this;
    }
    public bool AutoCatch = false;
    private void Update() 
    {
        if (AutoCatch) 
        { killmonster(); }
    }
    public void onclick()
    {
        killmonster();
    }
    public void killmonster() 
    {
            PlayerData.self.SoulAmount += 100;
            Destroy(gameObject);
    }
    public void autocatchon()
    {
        if (!AutoCatch)
        {
            AutoCatch = true;
            Invoke("autocatchoff", 5f);
            Debug.Log("aaaa");
        }
    }
    public void autocatchoff()
    {
        AutoCatch = false;
        Debug.Log("bbbb");
    }
}
