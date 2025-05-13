using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundCont : MonoBehaviour
{
 public AudioSource audioSource;
    public AudioClip buttonClickSound;
   public void PlaySound()
    {
        audioSource.PlayOneShot(buttonClickSound);
    }
    void Awake()
{
    DontDestroyOnLoad(this.gameObject);
}
}

