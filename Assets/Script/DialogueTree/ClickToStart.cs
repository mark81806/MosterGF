﻿using UnityEngine;
using System.Collections;
//using UnityEngine.UI;
using NodeCanvas.DialogueTrees;
using ParadoxNotion;

public class ClickToStart : MonoBehaviour
{

    public DialogueTreeController dialogueController;
    private const string DialoguePath = "Dialogues/D123";

    public void Start() 
    {
        dialogueController.graph = (NodeCanvas.Framework.Graph)Resources.Load(DialoguePath);
    }
    public void Click()
    {
        dialogueController.StartDialogue();
    }
}