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
    public double Soul;
    private bool test = true;
    public void Start() 
    {
        GetTime();
        Invoke("Cut", 1f);
    }
    public void GetTime()
    {
        //logouttime = System.DateTime.Parse(PlayerData.self.PlayerLogOutTimeString);
        logouttime = new System.DateTime(2020, 12, 20, 14, 12, 15);
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
            Soul++;
            TimeText.text = Soul.ToString();
        }
        else 
        {
            TimeText.text = "Max";
        }
        Invoke("Cut",1f);
    }
    public void SecToSoul() 
    {
        Soul = sec.TotalSeconds;
    }
}
