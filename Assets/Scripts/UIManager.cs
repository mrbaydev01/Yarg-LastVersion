using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void AyarlarButton()
    {
        SceneManager.LoadScene("Options");
    }
    public void MenuyeDon()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OdanaDon()
    {
        SceneManager.LoadScene("Scence1");
    }
    public void DavayaDon()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void EmekEkrani()
    {
        SceneManager.LoadScene("Emek");
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
