using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DramaEvent
{
    public class CreateSpriteEvent : BaseDramaEvent
    {
        public string path;
        public string name;
        public string space;
        public Vector2 pos;
        public Vector2 size;

        private string prefabPath = "Prefabs/Drama/Sprite";

        public CreateSpriteEvent () : this ( "" , "" , "" , Vector2.zero , Vector2.zero )
        {

        }
        public CreateSpriteEvent ( string path , string name , string space , Vector2 pos , Vector2 size )
        {
            this.path = path;
            this.name = name;
            this.space = space;
            this.pos = pos;
            this.size = size;
        }

        public override IEnumerator Play ()
        {
            GameObject parent = GameObject.Find ( space );
            if ( parent == null )
            {
                Debug.LogError ( space + "路徑不正確" );
                yield break;
            }

            Image image = GameObject.Instantiate ( Resources.Load<Image> ( prefabPath ) , parent.transform );
            Sprite spr = Resources.Load<Sprite> ( path + name );
            if ( spr == null )
            {
                Debug.LogError ( path + name + "路徑不正確" );
                image.sprite = SpritePath.None;
                yield break;
            }
            image.name = name;
            image.sprite = spr;
            image.transform.localPosition = pos;
            image.GetComponent<RectTransform> ().sizeDelta = size;
            yield return null;
        }
    }
}