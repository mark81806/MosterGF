using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Text.RegularExpressions;

namespace DramaEvent
{
    public class StoryPlayer : BaseDramaEvent
    {
        public StoryPlayer(string Path )
        {
            this.Path = Path;
        }
        private string Path;
        private float KeySpeed = 0.05f;                                         //字出現的速度
        private float MaxKeySpeed;                                              //下一次文字出現的時間
        private bool pass;                                                      //是否要略過打字機效果

        string tempPos;
        string tempName;

        public override IEnumerator Play ()
        {
            CheckEvent check = new CheckEvent ();
            TextAsset textAsset = Resources.Load<TextAsset> ( Path );
            if ( textAsset == null )
            {
                StoryManager.self.EndStory ();
                yield break;
            }
            string drama = textAsset.text;
            string [] StoryText = drama.Split ( '\n' );
            for ( int i = 1; i < StoryText.Length-1; i++ )
            {
                string [] line = StoryText [i].Split ( ',' );
                if ( line [9] == "X" )
                    continue;
                if (line[2].Contains("{") && line[2].Contains("}"))
                {
                    check.events = line;
                    yield return check.Play();
                    if (check.clearActor)
                    {
                        tempName = "";
                        tempPos = "";
                    }
                }
                else
                {
                    StoryManager.self.ssm.ActorName.text = line[1];
                    if (line[5] != "")
                        yield return new CreateActorEvent(line, tempPos, tempName).Play();
                    tempName = line[1];
                    tempPos = line[3];
                    StoryManager.self.ssm.ActorNameBox.SetActive(line[0] != "旁白");
                    yield return WriterText(line[2].Replace("*", ","), line[1]);
                }
            }
            //StoryManager.self.EndStory ();
            yield return new FadeBGMEvent ( 0 , 1 ).Play ();
        }
        IEnumerator WriterText ( string tempText , string name )
        {
            Text text = StoryManager.self.ssm.StoryText;
            text.text = "";
            foreach ( char word in tempText )
            {
                while ( !pass && !StorySceneManager.skip )
                {
                    while ( StorySceneManager.log )
                    {
                        yield return null;
                    }
                    if ( TouchButton ( ref pass ) )
                    {
                        break;
                    }
                    if ( Input.GetKey ( KeyCode.Space ) )
                    {
                        break;
                    }
                    if ( Time.time > MaxKeySpeed )                      //該出現下一個字的時候	
                        break;
                    yield return null;
                }
                MaxKeySpeed = Time.time + KeySpeed;                     //更新冷卻時間
                if ( word == 'W' )
                {
                    yield return new WaitForSeconds ( 0.5f );
                    continue;
                }
                text.text += word;
            }
            yield return new WaitForSeconds ( 0.01f );
            pass = false;                                               //取消掠過打字機效果
            yield return new WaitForInputEvent ().Play ();              //等待玩家點擊   
        }

        bool TouchButton ( ref bool pass )
        {
            if ( Input.GetMouseButtonUp ( 0 ) )
            {
                PointerEventData eventData = new PointerEventData ( StoryManager.self.eventSystem );
                eventData.position = Input.mousePosition;

                GraphicRaycaster raycaster = StoryManager.self.graphicsRaycaster;
                List<RaycastResult> result = new List<RaycastResult> ();
                raycaster.Raycast ( eventData , result );
                if ( result.Count == 0 )
                {
                    pass = true;
                    return pass;
                }
                Button button = null;
                button = result [0].gameObject.GetComponent<Button> ();
                pass = button == null;
            }
            return pass;
        }

        string [] ColorWord (ref string textTemp )
        {
            int start = textTemp.IndexOf ( '<' ) + 1;                  //找到<的數字後+1(不然會抓到[)
            int end = textTemp.IndexOf ( '>' );                        //找到>的數字
            int lenght = end - start;                               //<>內的文字數
            string words = textTemp.Substring ( start , lenght );   //取得<>內的文字
            string [] SWords = new string [words.Length];           //根據文字長度來開陣列

            string colorStr = "<color=#fed700>";
            for ( int i = 0; i < words.Length; i++ )
            {
                if ( words [i] == 'G' )
                {
                    colorStr = "<color=#7fff17>";
                }
                else if ( words [i] == 'B' )
                {
                    colorStr = "<color=#00fcf3>";
                }
                else if ( words [i] == 'O' )
                {
                    colorStr = "<color=#ff8400>";
                }
                else if ( words [i] == 'P' )
                {
                    colorStr = "<color=#ff77d1>";
                }
                else
                {
                    SWords [i] = colorStr + textTemp.Substring ( start + i , 1 ) + "</color>";
                }
            }
            Regex r = new Regex ( "<" );
            textTemp = r.Replace ( textTemp , "" , 1 );
            r = new Regex ( ">" );
            textTemp = r.Replace ( textTemp , "" , 1 );
            return SWords;                                      //回傳
        }
    }
}
