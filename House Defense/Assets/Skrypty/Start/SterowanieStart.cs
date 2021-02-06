using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class SterowanieStart : MonoBehaviour
{
    //Czułość przemieszczania kamery
    float Czułość = 0.6f;
    //Granica do któej może przemieszczać się kamera
    private float GranicaLewa = -1000;
    private float GranicaPrawa = 0;
    //Pozycja wcześniejsza dotyku
    private Vector2 PozycjaPoczątkowa;
    //Przesuwanie dotyku
    private Vector2 Kierunek;
    //Obiekty Kamery
    private GameObject Kamera;
    // Start is called before the first frame update
    void Start()
    {
        Kamera = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (Input.touchCount > 0)
            {
                Touch dotyk = Input.GetTouch(0);

                switch (dotyk.phase)
                {
                    case TouchPhase.Began:
                        PozycjaPoczątkowa = dotyk.position;
                        break;

                    case TouchPhase.Moved:
                        Kierunek = dotyk.position - PozycjaPoczątkowa;
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
                        break;

                }
            }
        }
    }
}
