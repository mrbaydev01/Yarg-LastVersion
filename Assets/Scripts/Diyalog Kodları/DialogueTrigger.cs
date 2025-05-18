using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueData dialogueData;

    public void TriggerDialogue()
    {
        if (dialogueData == null)
        {
            Debug.LogError("DialogueTrigger: DialogueData atanmamış!");
            return;
        }

        FindObjectOfType<DialogueManager>().StartDialogue(dialogueData);
    }
}

