using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DramaEvent
{
    public class DeletePictureEvent : BaseDramaEvent
    {
        public override IEnumerator Play ()
        {
            Transform [] parents = StoryManager.self.ssm.Picture.GetComponentsInChildren<Transform> ();
            for ( int i = 1; i < parents.Length; i++ )
            {
                GameObject.Destroy ( parents[i].gameObject );
            }

            yield return null;
        }
    }
}