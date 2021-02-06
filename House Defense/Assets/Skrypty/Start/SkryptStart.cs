using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SkryptStart : MonoBehaviour
{
    [SerializeField]
    private ListaSkryptów listaSkryptów;

    public void NowaGra()
    {
        listaSkryptów.przyciskiStart.CanvasStart.SetActive(false);
        listaSkryptów.przyciskiNowaGra.CanvasNowaGra.SetActive(true);
    }
    public void Ustawienia()
    {
        listaSkryptów.przyciskiStart.CanvasStart.SetActive(false);
        listaSkryptów.przyciskiUstawienia.CanvasUstawienia.SetActive(true);
    }
    public void Upgrade()
    {
        listaSkryptów.przyciskiStart.CanvasStart.SetActive(false);
        listaSkryptów.przyciskiUpgrade.CanvasUpgrade.SetActive(true);
    }
    public void Wyjście()
    {
        Application.Quit();

    }
    
}
