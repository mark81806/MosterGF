using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace DramaEvent
{
    public class Actor : MonoBehaviour
    {
        public string actorName;
        public float posX;
        public Image actorImage;
        public bool talkBool;

        private float moveDistance = 30;

        RectTransform rect;
        float defaultWidth;
        float defaultHeight;

        void Init ()
        {
            rect = GetComponent<RectTransform> ();
            defaultHeight = rect.rect.height;
            defaultWidth = rect.rect.width;
        }

        public void UpdateData ( float posX , float width )
        {
            this.posX = posX;
            transform.localPosition = new Vector3 ( posX , 0 , 0 );
            int scaleX = posX < 0 ? -1 : 1;
            transform.localScale = new Vector3 ( scaleX , 1 , 1 );

            if ( rect == null )
                Init ();
            if ( width == 0 )
            {
                rect.sizeDelta = new Vector2 ( defaultWidth , defaultHeight );
                return;
            }
            rect.sizeDelta = new Vector2 ( width , defaultHeight );
        }

        public void Talk ( bool talk )
        {
            talkBool = talk;
            if ( talkBool )
                transform.DOLocalMoveY ( transform.localPosition.y + moveDistance , 0.1f ).OnComplete ( () => transform.DOLocalMoveY ( transform.localPosition.y - moveDistance , 0.1f ) );
            Color32 mask = talkBool ? new Color32 ( 255 , 255 , 255 , 255 ) : new Color32 ( 200 , 200 , 200 , 255 );
            actorImage.DOColor ( mask , 0.3f );
        }
    }
}