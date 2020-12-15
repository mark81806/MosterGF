using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControl : MonoBehaviour
{
    public static MonsterControl self;
    public void Awake() 
    {
        self = this;
    }
    public bool autocatch = false;
    private void Update() 
    {
        autocatch = AutoCatch.self.autocatch;
        if (autocatch) 
        {
            killmonster();
        }
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
    
}
