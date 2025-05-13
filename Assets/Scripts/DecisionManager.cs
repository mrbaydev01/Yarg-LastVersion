using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DecisionManager : MonoBehaviour
{
    public GameObject decisionPanel;
    public TMP_InputField hapisInput;
    public TMP_InputField paraInput;

    // Paneli açan fonksiyon
    public void OpenDecisionPanel()
    {
        decisionPanel.SetActive(true);
    }

    // Paneli kapatan fonksiyon
    public void CloseDecisionPanel()
    {
        decisionPanel.SetActive(false);
    }

    public void BeraatVer()
    {
        Debug.Log("Beraat verildi.");
        decisionPanel.SetActive(false);
    }

    public void HapisVer()
    {
        string yil = hapisInput.text;
        Debug.Log("Hapis cezası verildi: " + yil + " yıl.");
        decisionPanel.SetActive(false);
    }

    public void ParaVer()
    {
        string miktar = paraInput.text;
        Debug.Log("Para cezası verildi: " + miktar + " TL.");
        decisionPanel.SetActive(false);
    }
}
