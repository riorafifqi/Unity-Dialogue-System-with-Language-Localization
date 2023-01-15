using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DialogueTrigger : MonoBehaviour
{
    [System.Serializable]
    public struct DialogueAttribute
    {
        public Language textLanguage;

        public Dialogue[] dialogues;
    }

    private LanguageManager languageManager;

    public DialogueAttribute[] dialogueCollection;
    private Dialogue[] usedDialogues;

    private void Awake()
    {
        languageManager = FindObjectOfType<LanguageManager>();
    }

    public void TriggerDialogue()
    {
        FindDialogue();

        Debug.Log("Triggered");
        FindObjectOfType<DialogueManager>().StartDialogue(usedDialogues);
    }

    public void FindDialogue()
    {
        foreach (DialogueAttribute dAttribute in dialogueCollection)
        {
            if (dAttribute.textLanguage == languageManager.usedLanguage)
            {
                usedDialogues = dAttribute.dialogues;
                return;
            }
        }
    }
}
