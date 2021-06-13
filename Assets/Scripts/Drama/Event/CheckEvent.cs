using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DramaEvent
{
    public class CheckEvent : BaseDramaEvent
    {
        public string [] events;

        public bool clearActor = false;

        public CheckEvent () : this ( new string [] { } )
        {

        }

        public CheckEvent ( string [] events )
        {
            this.events = events;
        }

        public override IEnumerator Play ()
        {
            string eventName = events [2].Replace ( "{" , "" ).Replace ( "}" , "" );

            #region 角色
            if (eventName == "FadeActor")
            {
                yield return new FadeActorEvent(events[6], float.Parse(events[7]), float.Parse(events[8])).Play();
            }
            else if (eventName == "MoveActor")
            {
                yield return new MoveActorEvent(events[6], events[7], events[8], float.Parse(events[9])).Play();
            }
            else if (eventName == "RotateActor")
            {
                yield return new RotateActorEvent(events[6], float.Parse(events[7]), float.Parse(events[8])).Play();
            }
            else if (eventName == "UpdateActor")
            {
                yield return new UpdateActorEvent(events[1], events[4], events[5]).Play();
            }
            #endregion

            #region 音樂
            else if (eventName == "FadeBGM")
            {
                yield return new FadeBGMEvent(float.Parse(events[6]), float.Parse(events[7])).Play();
            }
            else if (eventName == "PlayBGM")
            {
                yield return new PlayBGMEvent(events[6], events[7]).Play();
            }
            else if (eventName == "StopBGM")
            {
                yield return new StopBGMEvent().Play();
            }
            #endregion

            #region 創立
            else if (eventName == "CreateBackground")
            {
                yield return new CreateBackgroundEvent(events[6]).Play();
            }
            else if (eventName == "CreatePicture")
            {
                yield return new CreatePictureEvent(int.Parse(events[6]), int.Parse(events[7]), int.Parse(events[8])).Play();
            }
            else if (eventName == "CreateOption")
            {
                yield return new CreateOptionEvent(events[6]).Play();
            }
            else if (eventName == "LastChap") 
            {
                yield return new LastChapEvent().Play();
            }
            else if (eventName == "CreateWhiteSplash")
            {
                yield return new CreateWhiteSplash().Play();
            }
            #endregion

            #region 刪除

            else if (eventName == "DeleteActor")
            {
                yield return new DeleteActorEvent(events[6]).Play();
                clearActor = true;
            }
            else if (eventName == "DeleteAllActor")
            {
                yield return new DeleteAllActorEvent().Play();
            }
            else if (eventName == "DeletePicture")
            {
                yield return new DeletePictureEvent().Play();
            }
            else if (eventName == "DeleteSprite")
            {
                yield return new DeleteSpriteEvent(events[6], events[7]).Play();
            }
            else if (eventName == "DeleteText")
            {
                yield return new DeleteTextEvent().Play();
            }
            else if (eventName == "EndDialouge")
            {
                yield return new EndDiaEvent().Play();
            }
            #endregion

            #region 其他
            else if (eventName == "Flash")
            {
                yield return new FlashEvent().Play();
            }
            else if (eventName == "Shake")
            {
                yield return new ShakeEvent().Play();
            }
            else if (eventName == "Wait")
            {
                if (StorySceneManager.skip)
                    yield break;
                yield return new WaitForSeconds(float.Parse(events[6]));
            }
            #endregion

            else
            {
                Debug.LogError(eventName + "不是事件名稱");
            }

            yield return null;
        }
    }
}