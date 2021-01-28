using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    [HideInInspector]
    //chapter //chapter unlock request
    public int[] chapter_unlock_request = new int[] { 10,25,50,80,125,200,320,450};
    [HideInInspector]
    //power   //power level unlock request,powerups,power increase rate
    public int[] power_level__unlock_request = new int[] {0  ,150,170,190,210,230,250,270,290,310,
                                                          330,370,410,450,490,530,570,610,650,690,
                                                          730,790,850,910,970,1030,1090,1150,1210,1270,
                                                          1330,1450,1570,1690,1810,1930,2050,2170,2290,2410,3000};
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
