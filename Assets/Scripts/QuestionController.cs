using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionController : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public DialogueData[] possibleAnswers; // Her soruya karşılık gelen cevaplar

    public void AskQuestion(int index)
    {
        if (index >= 0 && index < possibleAnswers.Length)
        {
            dialogueManager.StartDialogue(possibleAnswers[index]);
        }
    }
}
