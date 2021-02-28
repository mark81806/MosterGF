using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace DramaEvent
{
    public class CreateBackgroundEvent : BaseDramaEvent
    {
        public string path;

        private const string BGPath = "Drama/Background";

        public CreateBackgroundEvent () : this ( "" )
        {

        }

        public CreateBackgroundEvent ( string path )
        {
            this.path = path;
        }

        public override IEnumerator Play ()
        {
            Transform background = StoryManager.self.ssm.Background;
            Transform [] parent = background.GetComponentsInChildren<Transform> ();
            for ( int i = 1; i < parent.Length; i++ )
            {
                GameObject.Destroy ( parent[i].gameObject , 1f );
            }
            Image BG = GameObject.Instantiate ( Resources.Load<Image> ( $"Prefabs/{BGPath}" ) , background );
            Sprite BGSpr = GetSprite ( $"Sprites/{BGPath}/{path}" );
            Debug.Log($"Sprites/{BGPath}/{path}");
            BG.sprite = BGSpr;
            if ( StorySceneManager.skip )
                BG.DOFade ( 1 , 0.00001f );
            else
                BG.DOFade ( 1 , 0.5f );
            yield return null;
        }

        Sprite GetSprite ( string path )
        {
            Sprite spr;
            if ( StorySceneManager.BackgroundSprite.TryGetValue ( path , out spr ) == false )
            {
                Sprite s = Resources.Load<Sprite> ( path );
                if ( s == null )
                {
                    Debug.LogError ( path + "路徑不正確" );
                    return SpritePath.None;
                }
                StorySceneManager.BackgroundSprite.Add ( path , s );
                spr = s;
            }
            return spr;
        }
    }
}
