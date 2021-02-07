using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DramaEvent
{
    public class StopBGMEvent : BaseDramaEvent
    {
        public override IEnumerator Play ()
        {
            //BGMManager.self.Stop ();
            yield return null;
        }
    }
}
