using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIPlayer : MonoBehaviour
{
    public GameObject CanvasPlayer;
    public Text Doświadczenie;
    public GameObject ObrazekDoświadczenie;
    public Text Pieniądze;
    public GameObject ObrazekPieniądze;
    public Text Diamenty;
    public GameObject ObrazekDiamenty;
    public GameObject Sterowanie;
    public pasekHP PasekHP;
    public czary Czary;
    public Text Fala;
    public teleport Teleport;

    [Serializable]
    public class pasekHP
    {
        public Text Pasek_HP_Tekst;
        public obrazekPasekHP SzczegółyPaskaHP;
    }
    [Serializable]
    public class obrazekPasekHP
    {
        public GameObject ObrazekHP;
        public RectTransform WymiaryObrazekHP;
    }
    [Serializable]
    public class czary
    {
        public GameObject Czary;
        public GameObject KulaOgnia;
        public GameObject PieniądzeKulaOgnia;
        public GameObject MonetaKulaOgnia;
        public GameObject Leczenie;
        public GameObject PieniądzeLeczenie;
        public GameObject MonetaLeczenie;
        public GameObject Łucznik;
        public GameObject PieniądzeŁucznik;
        public GameObject MonetaŁucznik;
    }
    [Serializable]
    public class teleport
    {
        public GameObject Teleport;
        public GameObject ObrazekDom;
        public GameObject AnimacjaPortal;
    }
}
