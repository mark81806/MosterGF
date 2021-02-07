using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace DramaEvent
{
    public class FadeActorEvent : BaseDramaEvent
    {
        public string actorName;
        public float fade;
        public float duration;

        public FadeActorEvent () : this ( "" , 0 , 0 )
        {

        }
        public FadeActorEvent ( string actorName , float fade , float duration )
        {
            this.actorName = actorName;
            this.fade = fade;
            this.duration = duration;
        }

        public override IEnumerator Play ()
        {
            Image actor = null;
            Actor [] tempActor = StoryManager.self.ssm.Actor.GetComponentsInChildren<Actor> ();
            for ( int i = 0; i < tempActor.Length; i++ )
            {
                if ( tempActor [i].actorName == actorName )
                {
                    actor = tempActor [i].GetComponent<Image>();
                    break;
                }
            }
            if ( actor == null )
            {
                Debug.LogError ( actorName + "找不到該角色" );
                yield break;
            }
            actor.DOFade ( fade , duration );
            yield return null;
        }
    }
}