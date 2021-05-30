using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DramaEvent
{
    public class CreateOptionEvent : BaseDramaEvent 
    {
        private  Vector3[] BtnPos = new[] { new Vector3(-178.89f, -543f, 90f), new Vector3(178.89f, -543f, 90f) };
        private const string OptionPath = "Drama/Button";
        public string optiontext;
        public CreateOptionEvent(string options)
        {
            this.optiontext = options;
        }
        public override IEnumerator Play()
        {
            Transform buttons = StoryManager.self.ssm.Buttons;
            string[] a = optiontext.Split(new string[] { "。" }, System.StringSplitOptions.RemoveEmptyEntries); //是否要刪掉
            Button optionBtn_1 = GameObject.Instantiate(Resources.Load<Button>($"Prefabs/{OptionPath}"),buttons);
            Button optionBtn_2 = GameObject.Instantiate(Resources.Load<Button>($"Prefabs/{OptionPath}"),buttons);
            BtnSetting(optionBtn_1, a[0],0);
            BtnSetting(optionBtn_2, a[1],1);

            optionBtn_1.onClick.AddListener(delegate() { astro(1); }); 
            optionBtn_2.onClick.AddListener(delegate() { astro(2); }); 
            yield return null;
        }
        private void BtnSetting(Button btn,string btnText,int btnPos) 
        {
            Text btn_text = btn.GetComponentInChildren<Text>();
            btn_text.text = btnText;
            btn.transform.localPosition = BtnPos[btnPos];
        }
        void astro(int choice)
        {
            PlayerData.self.Choice = choice;
            if (PlayerData.self.GameProgress == 11) 
            {
                if (choice == 1) 
                {
                    StoryManager.self.EndStory();
                    StoryManager.self.StartStory("Data / 11.1壞結局");
                }
            }
            StoryManager.self.EndStory();
        }
    }
}