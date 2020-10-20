using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    //chapter //chapter unlock request
    public int[] chapter_unlock_request = new int[] { };
    //power   //power level unlock request,powerups,power increase rate
    public int[] power_level__unlock_request = new int[] { };
    public float power_increase_rate_online = 1.0f;
    public float power_increase_rate_offline = 0.2f;
    //food    //food class//food spawn amount
    public int[] food_class = new int[] { };
    //ad
    public static GameData self;
    public void Awake()
    {
        self = this;
    }

}
