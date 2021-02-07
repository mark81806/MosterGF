using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DramaEvent
{
    public class DeleteAllActorEvent : BaseDramaEvent
    {
        public override IEnumerator Play ()
        {
            Actor [] actor = StoryManager.self.ssm.Actor.GetComponentsInChildren<Actor> ();
            for ( int i = 0; i < actor.Length; i++ )
            {
                GameObject.Destroy ( actor[i].gameObject );
            }
            yield return null;
        }
    }
}