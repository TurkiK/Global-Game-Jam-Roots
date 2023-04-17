using UnityEngine;

public class TreasureBox : Interactable
{
    public Dialogue dialogue;
    public Animator animator;

    private void Start()
    {
        promptMessage = "Press (SPACE) to investigate!";
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    protected override void Interact()
    {
        if (DialogueManager.instance.inConversation == false)
        {
            if(animator.GetBool("Open") == false)
                animator.SetBool("Open", true);

            DialogueManager.instance.startIndex = 0;
            DialogueManager.instance.endIndex = 1;
            TriggerDialogue();
            GameManager.instance.NextObjective();
        }
    }
}
