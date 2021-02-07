using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace DramaEvent
{
    public class WaitForInputEvent : BaseDramaEvent
    {
        private float autoTime = 1f;

        public override IEnumerator Play ()
        {
            float waitTime = Time.time + autoTime; 
            IsRunning = true;
            while ( !StorySceneManager.skip )
            {
                if ( Input.GetMouseButtonUp ( 0 ) )
                {
                    break;
                }
                if ( Input.GetKey ( KeyCode.Space ) )
                {
                    break;
                }
                if ( StorySceneManager.auto && Time.time > waitTime )
                {
                    break;
                }
                yield return null;
            }
            yield return new WaitForSeconds ( 0.01f );
            IsRunning = false;
        }
    }
}