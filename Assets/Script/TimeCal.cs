using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCal : MonoBehaviour
{
    public Text TimeText;
    private System.DateTime logouttime;
    private System.DateTime nowtime;
    private System.TimeSpan sec;
    public double Power;
    private bool test = true;
    public void Start() 
    {
        GetTime();
        Invoke("Cut", 1f);
    }
    public void GetTime()
    {
        //logouttime = System.DateTime.Parse(PlayerData.self.PlayerLogOutTimeString);
        logouttime = new System.DateTime(2021, 2, 3, 14, 12, 15);
        nowtime = System.DateTime.Now;
        TimeCalculate();
    }
    public void TimeCalculate() 
    {
        sec = nowtime.Subtract(logouttime);
        SecToSoul();
    }
    public void Cut() 
    {
        if (test)
        {
            Power++;
            //TimeText.text = PlayerData.self.PowerData.ToString();
        }
        else 
        {
            TimeText.text = "Max";
        }
        Invoke("Cut",1f);
    }
    public void SecToSoul() 
    {
        Power = sec.TotalSeconds;
        //PlayerData.self.PowerData += (int)Power;
    }
}
