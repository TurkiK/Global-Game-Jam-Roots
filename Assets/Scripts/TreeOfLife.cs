using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeOfLife : Interactable
{
    public Dialogue dialogue;


    private void Update()
    {
        if (GameManager.instance.currentObj == 3)
            promptMessage = "Press (SPACE) to investigate!";
    }

    public void TriggerDialogue()
    {
        if (GameManager.instance.currentObj == 3)
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    protected override void Interact()
    {
        if (DialogueManager.instance.inConversation == false)
        {
            DialogueManager.instance.startIndex = 0;
            DialogueManager.instance.endIndex = dialogue.sentences.Length - 1;
            TriggerDialogue();
        }
    }
}
