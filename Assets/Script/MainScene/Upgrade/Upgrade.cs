using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    private int perClick = 10;
    public Text powerText;
    private int power;
    // Update is called once per frame
    void Update()
    {
        /*
         power = PlayerData.self.PowerData;
         powerText.text = power.ToString();
        */
    }
    public void onClick()
    {
        /* power -= perClick;
         PlayerData.self.PowerData= power;
         Debug.Log(power);*/
    }
}