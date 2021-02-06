using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PrzyciskiNowaGra : MonoBehaviour
{
    public GameObject CanvasNowaGra;
    public nowaGra GUI;

    [Serializable]
    public class nowaGra
    {
        public GameObject GUI;
        public Text Przeciwnicy;
        public GameObject Powrót;
        public GameObject Start;
        public Text NazwaŚwiata;
        public GameObject Minimapa;
        public GameObject Zakup;
    }


}
