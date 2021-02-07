using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace DramaEvent
{
    public class FlashEvent : BaseDramaEvent
    {
        private const string path = "Prefabs/Drama/Flash";

        public override IEnumerator Play ()
        {
            Image flash = GameObject.Instantiate ( Resources.Load<Image> ( path ) , StoryManager.self.transform );
            flash.DOFade ( 0 , 0.3f );
            GameObject.Destroy ( flash , 0.5f );
            yield return null;
        }
    }
}
