using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace DramaEvent
{
    public class CreatePictureEvent : BaseDramaEvent
    {
        public int workerID;
        public int type;
        public int id;

        private const string path = "Drama/Picture";

        public CreatePictureEvent () : this ( 0 , 0 , 0 )
        {

        }
        public CreatePictureEvent ( int workerID , int type , int id )
        {
            this.workerID = workerID;
            this.type = type;
            this.id = id;
        }

        public override IEnumerator Play ()
        {
            Transform picture = StoryManager.self.ssm.Picture;
            if ( picture.childCount > 1 )
            {
                Transform parent = picture.GetChild ( 0 );
                GameObject.Destroy ( parent.gameObject , 1f );
            }
            Image image = GameObject.Instantiate ( Resources.Load<Image> ( "Prefabs/" + path ) , StoryManager.self.ssm.Picture );
            //Sprite [] spr = Resources.LoadAll<Sprite> ( "Sprites/" + path + + workerID + "/Picture" + type );
            Sprite spr = Resources.Load<Sprite> ( "Sprites/" + path + "/" + workerID + "/" + type + "/" + id );
            if ( spr == null )
            {
                Debug.LogError ( "Sprites/" + path + "/" + workerID + "/" + type + "/" + id + "路徑不正確" );
                yield break;
            }
            /*if ( id >= spr.Length )
            {
                //Debug.LogError ( id + "超過插圖數量" );
                yield break;
            }*/

            image.sprite = spr;
            if ( StorySceneManager.skip )
                image.DOFade ( 1 , 0.00001f );
            else
                image.DOFade ( 1 , 0.5f );
            yield return null;
        }
    }
}