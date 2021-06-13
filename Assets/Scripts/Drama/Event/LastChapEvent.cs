using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DramaEvent 
{
    public class LastChapEvent : BaseDramaEvent
    {
        public override IEnumerator Play()
        {
            int choice = PlayerData.self.Choice;
            if (choice == 1)
            {
                StoryManager.self.EndStory();
                StoryManager.self.StartStory("Data / 11.1壞結局");
                yield return null;
            }
            else
            yield return null;
        }
    }
}
