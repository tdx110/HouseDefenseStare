using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;

public class SkryptUstawienia : MonoBehaviour
{
    [SerializeField]
    private ListaSkryptów listaSkryptów;

    private ZapisOdczyt zapisOdczyt = new ZapisOdczyt();

    private void Start()
    {
    }

    //skrypt czyszczący ustawienia użytkownika
    public void czyść()
    {
        PlayerPrefs.DeleteAll();

        listaSkryptów.canvasOgólne.PasekZasobów.Pieniądze.text = zapisOdczyt.Gold.ToString();
        listaSkryptów.canvasOgólne.PasekZasobów.Doświadczenie.text = zapisOdczyt.Score.ToString();
        listaSkryptów.canvasOgólne.PasekZasobów.Diamenty.text = zapisOdczyt.Diamond.ToString();
    }
    //skrypt powrotu o początku (Start-u)
    public void powrót()
    {
        listaSkryptów.przyciskiUstawienia.CanvasUstawienia.SetActive(false);
        listaSkryptów.przyciskiStart.CanvasStart.SetActive(true);
    }
}
