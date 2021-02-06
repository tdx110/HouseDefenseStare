﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class SterowanieDefaultGra : MonoBehaviour
{
    //Czułość przemieszczania kamery
    float Czułość = 0.3f;
    //Granica do któej może przemieszczać się kamera
    private float GranicaLewa;
    private float GranicaPrawa;
    //Pozycja wcześniejsza dotyku
    private Vector2 PozycjaPoczątkowa;
    //Przesuwanie dotyku
    private Vector2 Kierunek;
    //Obiekty Kamery
    private GameObject Kamera;
    //Plik z zapisanymi stałymi ustawieniami
    // Start is called before the first frame update
    void Start()
    {
        Kamera = this.gameObject;
        GranicaLewa = ZapisOdczyt.DefaultGranicaLewa;
        GranicaPrawa = ZapisOdczyt.DefaultGranicaPrawa;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (Input.touchCount > 0)
            {
                Touch dotyk = Input.GetTouch(0);
                bool Przemieszczanie;

                switch (dotyk.phase)
                {
                    case TouchPhase.Began:
                        PozycjaPoczątkowa = dotyk.position;
                        Przemieszczanie = false;
                        break;

                    case TouchPhase.Moved:
                        Kierunek = dotyk.position - PozycjaPoczątkowa;
                        if (Math.Abs(Kierunek.x) > 10)
                        {
                            Przemieszczanie = true;
                        }
                        else
                        {
                            Przemieszczanie = false;
                        }
                        if (Przemieszczanie )
                        {
                            if (Kamera.transform.position.x - Kierunek.x * Czułość > GranicaPrawa)
                            {
                                Kamera.transform.position = new Vector3(GranicaPrawa, Kamera.transform.position.y, Kamera.transform.position.z);
                            }
                            else if (Kamera.transform.position.x - Kierunek.x * Czułość < GranicaLewa)
                            {
                                Kamera.transform.position = new Vector3(GranicaLewa, Kamera.transform.position.y, Kamera.transform.position.z);
                            }
                            else
                            {
                                Kamera.transform.position = new Vector3(Kamera.transform.position.x - Kierunek.x * Czułość, Kamera.transform.position.y, Kamera.transform.position.z);
                            }

                            PozycjaPoczątkowa = dotyk.position;
                        }
                        
                        break;

                }
            }
        }
    }
}
