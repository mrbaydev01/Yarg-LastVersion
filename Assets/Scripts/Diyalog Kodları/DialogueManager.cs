using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [Header("UI")]
    public GameObject playerDialoguePanel;
    public GameObject otherDialoguePanel;
    public TMP_Text playerNameText;
    public TMP_Text playerDialogueText;
    public TMP_Text otherNameText;
    public TMP_Text otherDialogueText;

    [Header("Typing Effect")]
    public float typingSpeed = 0.02f;

    private Queue<DialogueLine> dialogueLines;
    private Coroutine typingCoroutine;
    private bool isTyping = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            dialogueLines = new Queue<DialogueLine>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartDialogue(DialogueData dialogue)
    {
        dialogueLines.Clear();

        foreach (DialogueLine line in dialogue.lines)
        {
            dialogueLines.Enqueue(line);
        }

        ShowNextLine();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isTyping && (playerDialoguePanel.activeSelf || otherDialoguePanel.activeSelf))
        {
            ShowNextLine();
        }
    }

    public void ShowNextLine()
    {
        if (dialogueLines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine line = dialogueLines.Dequeue();

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        if (line.isPlayer)
        {
            playerDialoguePanel.SetActive(true);
            otherDialoguePanel.SetActive(false);
            playerNameText.text = line.speakerName;
            typingCoroutine = StartCoroutine(TypeText(playerDialogueText, line.lineText));
        }
        else
        {
            playerDialoguePanel.SetActive(false);
            otherDialoguePanel.SetActive(true);
            otherNameText.text = line.speakerName;
            typingCoroutine = StartCoroutine(TypeText(otherDialogueText, line.lineText));
        }
    }

    IEnumerator TypeText(TMP_Text textComponent, string line)
    {
        isTyping = true;
        textComponent.text = "";
        foreach (char c in line.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    void EndDialogue()
    {
        playerDialoguePanel.SetActive(false);
        otherDialoguePanel.SetActive(false);
    }
}
