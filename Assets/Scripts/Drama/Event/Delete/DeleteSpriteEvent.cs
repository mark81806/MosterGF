using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DramaEvent
{
    public class DeleteSpriteEvent : BaseDramaEvent
    {
        public string path;
        public string name;

        public DeleteSpriteEvent () : this ( "" , "" )
        {

        }

        public DeleteSpriteEvent ( string path , string name )
        {
            this.path = path;
            this.name = name;
        }

        public override IEnumerator Play ()
        {
            GameObject obj = GameObject.Find ( path + name );
            if ( obj == null )
            {
                Debug.LogError ( path + name + "路徑不正確" );
                yield break;
            }
            GameObject.Destroy ( obj );
            yield return null;
        }
    }
}