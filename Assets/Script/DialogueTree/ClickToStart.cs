using UnityEngine;
using System.Collections;
//using UnityEngine.UI;
using NodeCanvas.DialogueTrees;

public class ClickToStart : MonoBehaviour
{

    public DialogueTreeController dialogueController;
    private string DialoguePath = "Dialogues";

    public void Click()
    {
        //dialogueController.graph = Resources.Load(DialoguePath + "test1-1");
        dialogueController.StartDialogue();
    }
}