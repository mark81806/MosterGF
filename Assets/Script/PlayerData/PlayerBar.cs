using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBar : MonoBehaviour
{
    public Text ChapText;
    public Text SoulText;
    public void Update() 
    {
        ChapText.text = "第" + PlayerData.self.GameProgress.ToString() + "章" ;
        SoulText.text = "靈魂數:" + PlayerData.self.SoulAmount.ToString();
    }
}
