using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DramaEvent
{
    public class CreateActorEvent : BaseDramaEvent
    {
        public string actorName;
        public string realName;
        public string posID;
        public string faceID;
        public string clothesName;
        public float SizeX;

        public string tempPos;
        public string tempName;
        private const string PrefabPath = "Prefabs/Drama/Actor";
        private const string ActorPath = "0122修改/";//system.io.path.combine;

        public CreateActorEvent () : this ( new string [] { } , "" , "" )
        {
            
        }
        public CreateActorEvent ( string [] line , string tempPos , string tempName )
        {
            actorName = line [1];
            realName =  line[6];
            posID = line [3];
            faceID = line [4];
            int s = 0;
            if ( int.TryParse ( line [6] , out s ) )
            {
                SizeX = s;
            }
            clothesName = line[5];
            this.tempName = tempName;
            this.tempPos = tempPos;
        }

        public override IEnumerator Play ()
        {
            Transform actorTransform = StoryManager.self.ssm.Actor.Find ( actorName );
            Actor [] tempActor = StoryManager.self.ssm.Actor.GetComponentsInChildren<Actor> ();
            if ( posID == "" )
            {
                for ( int i = 0; i < tempActor.Length; i++ )
                {
                    bool talkBool = tempActor [i].name == actorName;
                    if ( tempPos != posID || tempName != actorName )
                        tempActor [i].Talk ( talkBool );
                }
            }
            else
            {
                for ( int i = 0; i < tempActor.Length; i++ )
                {
                    if ( tempActor [i].posX == PID () && tempActor [i].actorName != actorName )
                    {
                        Debug.Log(tempActor[i].actorName+ actorName);
                        GameObject.Destroy ( tempActor [i].gameObject );
                        break;
                    }
                }

                if ( actorTransform == null )
                {
                    Debug.Log("e");
                    actorTransform = GameObject.Instantiate ( Resources.Load<Transform> ( PrefabPath ) , StoryManager.self.ssm.Actor );
                }
                actorTransform.name = actorName;
                Actor actor = actorTransform.GetComponent<Actor> ();
                actor.actorName = actorName;
                actor.realName = realName;

                if ( tempPos != posID || tempName != actorName )
                {
                    actor.UpdateData ( PID () , SizeX );
                    for ( int i = 0; i < tempActor.Length; i++ )
                    {
                        if ( tempActor [i] == null )
                            continue;
                        bool talkBool = tempActor [i].gameObject.name == actorName;
                        tempActor [i].Talk ( talkBool );
                    }
                }
                if (actor.actorName =="???") 
                {
                    yield return UpdateSprite(actor); 
                }
                yield return UpdateSprite ( actor );
            }
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
        string [] Clothes = new string[7] { "無" , "剪影", "私服" , "制服" , "泳裝" , "半妖化","妖化" };
        string CID ()
        {
            for ( int i = 0; i < Clothes.Length; i++ )
            {
                if (Clothes[i] == clothesName)
                {
                    return i.ToString();
                    /*switch (i) 
                    {
                        case 0 : return "無" ;
                        case 1: return "剪影";
                        case 2: return "A";
                        case 3: return "B";
                        case 4: return "C";
                        case 5: return "D";
                        case 6: return "E";
                        default: return "";
                    }*/
                }
            }
            return "";
        }
        string [] PosX = new string [] { "左" , "中" , "右" };
        float [] positionX = new float [] { -250f , 0f , 250f };
        float PID ()
        {
            for ( int i = 0; i < PosX.Length; i++ )
            {
                if ( posID == PosX [i] )
                    return positionX [i];
            }
            int p;
            if ( int.TryParse ( posID , out p ) )
                return p;
            Debug.LogError ( posID + "位置錯誤" );
            return 0;
        }

        IEnumerator UpdateSprite ( Actor actor )
        {
            string path;
            if (actor.actorName == "???")
            {
                path = ActorPath + actor.realName +"-"+ CID();
            }
            else { path = ActorPath + actor.actorName + CID(); }
            Debug.Log(path);
            Sprite actorSpr = GetSprite ( path );
            actor.actorImage.sprite = actorSpr;
            yield return null;
        }
        Sprite GetSprite ( string path )
        {
            Sprite spr;
            if ( StorySceneManager.ActorSprite.TryGetValue ( path , out spr ) == false )
            {
                Sprite s = Resources.Load<Sprite> ( path );
                if ( s == null )
                {
                    Debug.LogError ( path + "路徑不正確" );
                    return SpritePath.None;
                }
                StorySceneManager.ActorSprite.Add ( path , s );
                spr = s;
            }
            return spr;
        }
    }
}