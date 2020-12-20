using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public void now()
    {
        System.DateTime date;
        date = System.DateTime.Now; //now time 
    }
    public void GetTime()
    {
        System.DateTime playertimelogin;
        playertimelogin = System.DateTime.Now;
        string playertimeloginstring = playertimelogin.ToString("yyyy-MM-dd HH:mm:ss");
        System.DateTime test1 = System.DateTime.Parse(playertimeloginstring);
        Debug.Log(playertimelogin.ToString());
        Debug.Log(test1.ToString());


    }
}
