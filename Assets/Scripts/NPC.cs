using UnityEngine;

public class NPC : Interactable
{
    public Dialogue dialogue;

    private void Start()
    {
        promptMessage = "Press (SPACE) to talk to " + gameObject.name +"!";
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    protected override void Interact()
    {
        if (DialogueManager.instance.inConversation == false)
        {
            if(GameManager.instance.currentObj == 0 && gameObject.name == "Father")
            {
                DialogueManager.instance.startIndex = 0;
                DialogueManager.instance.endIndex = 3;
                TriggerDialogue();
                GameManager.instance.NextObjective();
            }
            else if(GameManager.instance.currentObj == 1 && gameObject.name == "Elder")
            {
                DialogueManager.instance.startIndex = 0;
                DialogueManager.instance.endIndex = 7;
                TriggerDialogue();
                GameManager.instance.NextObjective();
            }
            else if(GameManager.instance.currentObj == 2 && gameObject.name == "NPC2")
            {
                DialogueManager.instance.startIndex = 0;
                DialogueManager.instance.endIndex = 5;
                TriggerDialogue();
            }
            else
            {
                DialogueManager.instance.startIndex = dialogue.sentences.Length - 1;
                DialogueManager.instance.endIndex = dialogue.sentences.Length - 1;
                TriggerDialogue();
            }
        }
    }
}
