using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace DramaEvent
{
    public class MoveActorEvent : BaseDramaEvent
    {
        public string actorName;
        public string posX;
        public string posY;
        public float duration;

        public MoveActorEvent () : this ( "" , "" , "" , 0 )
        {
        }

        public MoveActorEvent ( string actorName , string posX , string posY , float duration )
        {
            this.actorName = actorName;
            this.posX = posX;
            this.posY = posY;
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
            if ( posX == "" )
            {
                actor.DOLocalMoveY ( int.Parse ( posY ) , duration ).SetEase ( Ease.Linear );
                yield break;
            }
            if ( posY == "" )
            {
                actor.DOLocalMoveX ( int.Parse ( posX ) , duration ).SetEase ( Ease.Linear );;
                yield break;
            }
            actor.DOLocalMove ( new Vector2 ( int.Parse ( posX ) , int.Parse ( posY ) ) , duration ).SetEase ( Ease.Linear );;
            yield return null;
        }
    }
}