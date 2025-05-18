using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortcutPanelController : MonoBehaviour
{
    public GameObject shortcutPanel;

    public void TogglePanel()
    {
        shortcutPanel.SetActive(!shortcutPanel.activeSelf);
    }

    public void CallCharacter(string characterName)
    {
        Debug.Log(characterName + " çağrıldı!");
        // Buraya karakteri sahneye getirme animasyonu vs. eklersin
    }
}
