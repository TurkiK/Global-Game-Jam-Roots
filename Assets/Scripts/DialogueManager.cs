using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance { get; private set; }

    public bool inConversation = false;

    public int startIndex = 0, endIndex = 0;
    public Animator animator;

    public TMP_Text dialogueText;
    public TMP_Text nameText;

    private Queue<string> sentences;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        inConversation = true;
        animator.SetBool("isOpen", true);

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        FindObjectOfType<Movement>().canMove = false;
        FindObjectOfType<ThirdPersonCam>().canLook = false;

        nameText.text = dialogue.name;
        sentences.Clear();

        /*foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }*/

        for(int i = startIndex; i <= endIndex; i++)
        {
            sentences.Enqueue(dialogue.sentences[i]);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.025f);
        }
    }

    public void EndDialogue()
    {
        inConversation = false;

        animator.SetBool("isOpen", false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        FindObjectOfType<Movement>().canMove = true;
        FindObjectOfType<ThirdPersonCam>().canLook = true;
    }
}
