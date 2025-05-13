using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject gavelImage;  // Gavel image (button)
    public GameObject cezaScreen;  // Ceza Screen (Panel)
    public GameObject nextCaseButton;  // Next case button

    public TextMeshProUGUI cezaText;  // Ceza text for decision screen

    private DialogueManager dialogueManager;  // Referans to DialogueManager

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();  // DialogueManager'ı bul
        gavelImage.SetActive(true);  // Gavel initially visible
        cezaScreen.SetActive(false); // Ceza screen hidden
        nextCaseButton.SetActive(false); // Next case button hidden
    }

    // Gavel tıklanınca ceza ekranını göster
    public void OnGavelClick()
    {
        gavelImage.SetActive(false);  // Gavel'ı gizle
        cezaScreen.SetActive(true);   // Ceza ekranını göster
    }

    // Ceza seçeneklerinden birini seçme
    public void VerBerat()
    {
        cezaText.text = "Zanlı beraat etti!";
        EndCezaScreen();
    }

    public void VerHapis()
    {
        cezaText.text = "Zanlı hapis cezası aldı!";
        EndCezaScreen();
    }

    public void VerParaCeza()
    {
        cezaText.text = "Zanlı para cezası aldı!";
        EndCezaScreen();
    }

    // Ceza seçildikten sonra ekranı kapatma ve diğer davaya geçiş
    private void EndCezaScreen()
    {
        nextCaseButton.SetActive(true);  // Diğer davaya geç butonunu göster
    }

    // Diğer davaya geçiş
    public void NextCase()
    {
        cezaScreen.SetActive(false);
        nextCaseButton.SetActive(false);
        dialogueManager.StartDialogue(); // Diyalog başlat
    }
}
