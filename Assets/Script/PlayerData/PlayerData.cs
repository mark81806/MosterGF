using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public void Awake()
    {
        //game progess
        PlayerPrefs.SetInt("GameProgress", 0);
        //food amount
        PlayerPrefs.SetInt("FoodAmount", 0);
        //power data
        PlayerPrefs.SetInt("PowerData", 0);
    }
}
