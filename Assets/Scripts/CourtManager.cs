using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CourtManager : MonoBehaviour
{
    public GameObject raporPaneli;
    public GameObject mikrofonPaneli;
    public GameObject kitapPaneli;

    public void RaporuAc()
    {
        raporPaneli.SetActive(true);
    }

    public void MikrofonAc()
    {
        mikrofonPaneli.SetActive(true);
    }

    public void KitapAc()
    {
        kitapPaneli.SetActive(true);
    }
}