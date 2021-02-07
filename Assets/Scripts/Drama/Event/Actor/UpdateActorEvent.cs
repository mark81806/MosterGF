using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DramaEvent
{
    public class UpdateActorEvent : BaseDramaEvent
    {
        public string actorName;
        public string faceID;
        public string clothesName;

        private const string ActorPath = "Sprites/Drama/Actor/";

        public UpdateActorEvent () : this ( "" , ""  , "" )
        {

        }
        public UpdateActorEvent ( string actorName , string faceID , string clothesName )
        {
            this.actorName = actorName;
            this.faceID = faceID;
            this.clothesName = clothesName;
        }

        public override IEnumerator Play ()
        {
            Image actor = null;
            Actor [] tempActor = StoryManager.self.ssm.Actor.GetComponentsInChildren<Actor> ();
            for ( int i = 0; i < tempActor.Length; i++ )
            {
                if ( tempActor [i].actorName == actorName )
                {
                    actor = tempActor [i].GetComponent<Image> ();
                    break;
                }
            }
            if ( actor == null )
            {
                Debug.LogError ( actorName + "找不到該角色" );
                yield break;
            }
            string path = ActorPath + EID () + CID () + faceID;
            Sprite spr = Resources.Load<Sprite> ( path );
            if ( spr == null )
            {
                Debug.LogError ( path + "路徑不正確" );
                yield break;
            }
            actor.sprite = spr;
            yield return null;
        }
        string [] Employee = new string [5] { "顏無菁" , "夜蓮心" , "笭伊姍" , "端木壹" , "司馬小仙" };
        string EID ()
        {
            for ( int i = 0; i < Employee.Length; i++ )
            {
                if ( Employee [i] == actorName )
                    return i.ToString () + "/";
            }
            return "EX/";
        }

        string [] Clothes = new string [6] { "制服" , "cos" , "內衣" , "半制服" , "私服" , "裸" };
        string CID ()
        {
            for ( int i = 0; i < Clothes.Length; i++ )
            {
                if ( Clothes [i] == clothesName )
                    return i.ToString () + "/Actor";
            }
            if ( clothesName == "西裝" )
                return "1/Actor";
            return "";
        }
    }
}