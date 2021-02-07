using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace DramaEvent
{
    public class RotateActorEvent : BaseDramaEvent
    {
        public string actorName;
        public float angle;
        public float duration;

        public RotateActorEvent () : this ( "" , 0 , 0 )
        {

        }
        public RotateActorEvent ( string actorName , float angle , float duration )
        {
            this.actorName = actorName;
            this.angle = angle;
            this.duration = duration;
        }

        public override IEnumerator Play ()
        {
            Transform actor = null;
            Actor [] tempActor = StoryManager.self.ssm.Actor.GetComponentsInChildren<Actor> ();
            for ( int i = 0; i < tempActor.Length; i++ )
            {
                if ( tempActor [i].actorName == actorName )
                {
                    actor = tempActor [i].transform;
                    break;
                }
            }
            if ( actor == null )
            {
                Debug.LogError ( actorName + "找不到該角色" );
                yield break;
            }
            actor.DORotate ( new Vector3 ( 0 , 0 , angle ) , duration );
            yield return null;
        }
    }
}