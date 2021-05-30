using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DramaEvent
{
    public class EndGameEvent : BaseDramaEvent
    {

        public override IEnumerator Play()
        {
            GameReset();
            yield return null;
        }
        public void GameReset() 
        {

        }
    }
}

