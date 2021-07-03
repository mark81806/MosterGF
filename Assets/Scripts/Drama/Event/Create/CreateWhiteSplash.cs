using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace DramaEvent 
{
    public class CreateWhiteSplash : BaseDramaEvent
    {
        private const string BGPath = "Drama/Background";
        public override IEnumerator Play()
        {
            Transform background = StoryManager.self.ssm.Background;
            Image BG = background.GetComponentInChildren<Image>();
            string a = BG.sprite.name;
            BG.sprite = GetSprite($"Sprites/{BGPath}/白幕");
            yield return new WaitForSeconds(0.1f);
            BG.sprite = GetSprite($"Sprites/{BGPath}/{a}");
            if (StorySceneManager.skip)
                BG.DOFade(1, 0.00001f);
            else
                BG.DOFade(1, 0.5f);
            yield return null;
        }
        Sprite GetSprite(string path)
        {
            Sprite s = Resources.Load<Sprite>(path);
            return s;
        }
    }
}
