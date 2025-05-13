using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // TextMeshPro kütüphanesini dahil et

public class DialogueManager : MonoBehaviour
{
    public DialogueData currentDialogue;  // Diyalog verisi
    public TextMeshProUGUI hakimDialogueText;    // Hakim diyalog metni
    public TextMeshProUGUI hakimSpeakerNameText; // Hakim isim metni
    public TextMeshProUGUI zanliDialogueText;    // Zanlı diyalog metni
    public TextMeshProUGUI zanliSpeakerNameText; // Zanlı isim metni

    public GameObject hakimBubble;    // Hakim baloncuğu
    public GameObject zanliBubble;    // Zanlı baloncuğu

    private int currentLine = 0;       // Şu anki diyalog satırı
    private bool isDialogueActive = false; // Diyalog aktif mi?

    // Mikrofona tıklanarak başlatılacak diyalog
    public void StartDialogue()
    {
        if (!isDialogueActive) // Eğer diyalog başlamamışsa
        {
            isDialogueActive = true; // Diyalog başladı
            currentLine = 0;  // Diyalog sırasını sıfırlıyoruz
            ShowLine();       // İlk diyalogu gösteriyoruz
        }
    }

    // Ekranın herhangi bir yerine tıklanarak diyaloğu ilerletme
    void Update()
    {
        if (isDialogueActive && Input.GetMouseButtonDown(0)) // Sol tıklama ile kontrol
        {
            ShowLine();
        }
    }

    // Diyalogları görüntüleme fonksiyonu
    void ShowLine()
    {
        // Diyalog bittiğinde, EndDialogue fonksiyonunu çağır ve baloncukları gizle
        if (currentLine >= currentDialogue.lines.Length)
        {
            EndDialogue();
            hakimBubble.SetActive(false);  // Hakim baloncuğunu gizle
            zanliBubble.SetActive(false);  // Zanlı baloncuğunu gizle
            return;
        }

        string speaker = currentDialogue.lines[currentLine].speakerName;
        string text = currentDialogue.lines[currentLine].text;

        // Baloncukları gizle
        hakimBubble.SetActive(false);
        zanliBubble.SetActive(false);

        // Diyalog metnini ve baloncuğu belirle
        if (speaker == "Hakim")
        {
            hakimBubble.SetActive(true);  // Hakim baloncuğunu aç
            StartCoroutine(TypeText(hakimDialogueText, text));  // Hakim metnini harf harf yaz
            hakimSpeakerNameText.text = speaker;  // Hakim ismini yaz
        }
        else if (speaker == "Yunus")
        {
            zanliBubble.SetActive(true);  // Zanlı baloncuğunu aç
            StartCoroutine(TypeText(zanliDialogueText, text));  // Zanlı metnini harf harf yaz
            zanliSpeakerNameText.text = speaker;  // Zanlı ismini yaz
        }

        currentLine++;  // Bir sonraki satıra geç
    }

    // Harf harf yazma efekti
    IEnumerator TypeText(TMP_Text textComponent, string fullText)
    {
        textComponent.text = "";  // Başlangıçta metni boş bırak
        foreach (char letter in fullText.ToCharArray())
        {
            textComponent.text += letter;  // Her harfi sırayla ekle
            yield return new WaitForSeconds(0.05f);  // Her harf arasında 0.05 saniye bekle
        }
    }

    // Diyalog sona erdiğinde yapılacaklar
    void EndDialogue()
    {
        isDialogueActive = false; // Diyalog sona erdi, flag'ı false yap
        Debug.Log("Diyalog sona erdi.");
        // İstediğiniz işlemleri burada gerçekleştirebilirsiniz (Örneğin, başka bir sahneye geçiş vb.)
    }
}
