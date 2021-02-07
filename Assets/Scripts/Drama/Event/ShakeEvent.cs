using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace DramaEvent
{
    public class ShakeEvent : BaseDramaEvent
    {
        public override IEnumerator Play ()
        {
            Transform background = StoryManager.self.ssm.Background;
            background.DOShakePosition ( 0.5f , new Vector3 ( 100 , 0 , 0 ) , 15 , 90 , false , false );
            background.DOLocalMoveX ( 0 , 0.001f ).SetDelay ( 0.5f );
            yield return null;
        }
    }
}