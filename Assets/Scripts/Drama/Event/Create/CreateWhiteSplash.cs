using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DramaEvent 
{
    public class CreateWhiteSplash : BaseDramaEvent 
    {
        private const string WhiteSplashPath = "Drama/Background";
        private const string path = "黑幕";
        public override IEnumerator Play()
        {
            Image BG;
           // GameObject.Instantiate<Image>(BG, new Vector3(1, 0, 0), Quaternion.identity);
            Sprite sss = Resources.Load<Sprite>($"Sprites/{WhiteSplashPath}/{path}");
            BG.sprite = sss;
            BG.color = new Color(255, 255, 255, 255);
            yield return null; //yield 遇到yield就回傳 傳完再回來。
        }
    }

}
