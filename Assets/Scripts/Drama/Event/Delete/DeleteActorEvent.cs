using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DramaEvent
{
    public class DeleteActorEvent : BaseDramaEvent
    {
        public string actorName;

        public DeleteActorEvent () : this ( "" )
        {

        }
        public DeleteActorEvent ( string actorName )
        {
            this.actorName = actorName;
        }
        public override IEnumerator Play ()
        {
            Actor [] actor = StoryManager.self.ssm.Actor.GetComponentsInChildren<Actor> ();
            for ( int i = 0; i < actor.Length; i++ )
            {
                if ( actor [i].actorName == actorName )
                {
                    GameObject.Destroy ( actor[i].gameObject );
                    break;
                }
            }
            StoryManager.self.ssm.ActorNameBox.SetActive ( false );
            yield return null;
        }
    }
}