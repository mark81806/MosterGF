using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DramaEvent
{
    public class DeleteTextEvent : BaseDramaEvent
    {
        public override IEnumerator Play ()
        {
            StoryManager.self.ssm.StoryText.text = "";
            StoryManager.self.ssm.ActorName.text = "";
            yield return null;
        }
    }
}
