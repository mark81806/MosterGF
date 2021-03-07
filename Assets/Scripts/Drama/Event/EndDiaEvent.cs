﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DramaEvent
{
    public class EndDiaEvent : BaseDramaEvent
    {

        public override IEnumerator Play()
        {
            SceneChange.self.MainScene();
            yield return null;
        }
    }
}
