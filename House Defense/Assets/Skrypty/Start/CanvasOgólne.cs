using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasOgólne : MonoBehaviour
{
    [SerializeField]
    private ListaSkryptów listaSkryptów;
    private ZapisOdczyt zapisOdczyt = new ZapisOdczyt();

    public pasekZasobów PasekZasobów;
    public Text Wersja;
    public GameObject Reklama;
    
   [Serializable]
   public class pasekZasobów
    {
        public Text Pieniądze;
        public GameObject ObrazekPieniądze;
        public Text Doświadczenie;
        public GameObject ObrazekDoświadczenie;
        public Text Diamenty;
        public GameObject ObrazekDiamenty;
    }

    private void Start()
    {
        Time.timeScale = 1f;
        Wersja.text = "Version: " + Application.version.ToString();
        PasekZasobów.Pieniądze.text = zapisOdczyt.Gold.ToString();
        PasekZasobów.Doświadczenie.text = zapisOdczyt.Score.ToString();
        PasekZasobów.Diamenty.text = zapisOdczyt.Diamond.ToString();
    }
}
