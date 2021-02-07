using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DramaEvent
{
    public class FadeBGMEvent : BaseDramaEvent
    {
        public float vol;
        public float duration;

        public FadeBGMEvent () : this ( 0 , 0 )
        {

        }
        public FadeBGMEvent ( float vol , float duration )
        {
            this.vol = vol;
            this.duration = duration;
        }

        public override IEnumerator Play ()
        {
            //BGMManager.self.Fade ( vol , duration );
            yield return null;
        }
    }
}