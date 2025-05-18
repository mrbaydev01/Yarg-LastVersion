using UnityEngine;

public class MicButtonController : MonoBehaviour
{
    public DialogueTrigger tanik1Trigger;
    public GameObject retryPanel;



    public DialogueTrigger dialogueTrigger; // Sahnede kimin konuşacağı atanacak

    public void OnMicButtonClicked()
    {
        var data = CourtManager.Instance.currentCharacter;
var character = CourtManager.Instance.currentCharacter;

        if (character == null)
        {
            Debug.LogWarning("Hiçbir karakter çağrılmadı! Lütfen önce bir karakteri kürsüye çağır.");
            return; // Diyalog başlatma, çık.
        }

        if (character.dialogueTrigger == null)
        {
            Debug.LogWarning("Çağrılan karakterin DialogueTrigger bileşeni atanmadı.");
            return; // Güvenli çık.
        }

        character.dialogueTrigger.TriggerDialogue();
        if (data != null)
        {
            Debug.Log("Şu anki karakter: " + data.name);
            if (data.dialogueTrigger != null)
            {
                Debug.Log("DialogueTrigger bulundu. Diyalog başlatılıyor.");
                data.dialogueTrigger.TriggerDialogue();
            }
            else
            {
                Debug.LogWarning("DialogueTrigger atanmadı!");
            }
        }
        else
        {
            Debug.LogWarning("currentCharacter atanmadı!");
        }
    if (CourtManager.Instance.currentCharacter == null)
{
    Debug.LogError("Aktif karakter atanmadı!");
    return;
}

if (CourtManager.Instance.currentCharacter.dialogueTrigger == null)
{
    Debug.LogError("Karakterin DialogueTrigger'ı atanmadı!");
    return;
}

}


    public void OnRetryYesClicked()
    {
        retryPanel.SetActive(false);
        tanik1Trigger.TriggerDialogue(); // Diyaloğu tekrar başlat
    }

    public void OnRetryNoClicked()
    {
        retryPanel.SetActive(false); // Paneli kapat
    }
     public CourtManager courtManager;

  public void OnMicButtonClicked2()
    {
        if (courtManager.currentCharacter != null && courtManager.currentCharacter.dialogueTrigger != null)
        {
            courtManager.currentCharacter.dialogueTrigger.TriggerDialogue();
        }
    }


    }

