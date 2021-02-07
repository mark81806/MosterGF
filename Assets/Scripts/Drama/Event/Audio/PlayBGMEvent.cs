using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DramaEvent
{
    public class PlayBGMEvent : BaseDramaEvent
    {
        public string path;
        public string vol;
        
        private const string BGMPath = "Audios/BGM/Drama/";

        public PlayBGMEvent () : this ( "" , "" )
        {

        }

        public PlayBGMEvent ( string path , string vol )
        {
            this.path = path;
            this.vol = vol;
        }

        public override IEnumerator Play ()
        {
            if ( vol == "" )
            {
                Debug.LogWarning ( "沒有設定音量" );
                vol = "1";
            }
            //GameLoopManager.instance.pm.bgmData.SetVolume ( float.Parse ( vol ) );
            //GameLoopManager.instance.pm.bgmData.SetPath ( BGMPath + path );
           
            yield return null;
        }
    }
}
