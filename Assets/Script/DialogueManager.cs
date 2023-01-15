using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    Queue<Dialogue> dialogues;
    GameObject dialogueBox;

    private Vector3 openPosition;
    private Vector3 closedPosition;

    [SerializeField]
    private TMP_Text dialogueText;
    [SerializeField]
    private TMP_Text dialogueName;

    private void Awake()
    {
        dialogueBox = GameObject.Find("DialogueBox");
        openPosition = dialogueBox.transform.localPosition;
    }

    void Start()
    {
        dialogues = new Queue<Dialogue>();

        closedPosition = new Vector3(openPosition.x, -Screen.height, 0f);
        dialogueBox.transform.position = closedPosition;
    }

    public void StartDialogue(Dialogue[] dialogues)
    {
        //dialogueAnimator.SetBool("IsOpen", true);
        DialogueOpen();
        this.dialogues.Clear();

        foreach (Dialogue dialogue in dialogues)
        {
            this.dialogues.Enqueue(dialogue);
        }

        DisplayNextDialogue();
    }

    public void DisplayNextDialogue()
    {
        if (dialogues.Count == 0)
        {
            EndDialogue();
            return;
        }

        Dialogue tempDialogue = dialogues.Dequeue();

        dialogueName.text = tempDialogue.name;
        string tempSentence = tempDialogue.sentence;
        StopAllCoroutines();

        if(tempSentence != "")
            StartCoroutine(TypeSentence(tempSentence));

        Debug.Log("Dialogue next");
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        bool isTags = false;

        foreach (char letter in sentence.ToCharArray())
        {
            if (letter == '<' || isTags)
            {
                isTags = true;
                dialogueText.text += letter;
                if (letter == '>')
                    isTags = false;
            }
            else
            {
                dialogueText.text += letter;
                yield return null;
            }
        }
    }

    public void EndDialogue()
    {
        //dialogueAnimator.SetBool("IsOpen", false);
        DialogueClose();
        Debug.Log("End Conversation");
    }

    void DialogueOpen()
    {
        dialogueBox.transform.localPosition = openPosition;
        //dialogueBox.transform.LeanMoveLocalY(startPosition.y, 0.5f).setEaseOutExpo().setDelay(0.5f);
    }

    void DialogueClose()
    {
        dialogueBox.transform.position = closedPosition;
    }
}
