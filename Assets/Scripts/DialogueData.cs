using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DialogueLine
{
    public string speakerName;
    public string text;
}

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue Data")]
public class DialogueData : ScriptableObject
{
    public DialogueLine[] lines;
}


