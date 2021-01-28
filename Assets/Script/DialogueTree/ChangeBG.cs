using UnityEngine;
using ParadoxNotion.Design;
using NodeCanvas.Framework;
using NodeCanvas.DialogueTrees;

namespace NodeCanvas.Tasks.Actions 
{

    [Category("Test")]
    public class ChangeBG : ActionTask<Transform>
    {
        [RequiredField]
        public BBParameter<GameObject> background;

        protected override void OnExecute()
        {
            //getcomponent
            Sprite.Instantiate(background.value);
            EndAction();
        }
    }

}