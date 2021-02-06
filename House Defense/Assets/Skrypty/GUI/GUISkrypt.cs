using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System;
using UnityEngine.Events;

public class GUISkrypt : MonoBehaviour
{
    [SerializeField]
    private ZapisOdczyt _ZapisOdczyt;
    [SerializeField]
    private GameObject _Kamera;
    [Header("Metoda wykonyje się w aby wyłaczyć baner w grze")]
    public GUIReklama Reklama;
    private GUIListaObiektów _GUIListaObiektów;

    //Podstawowe statystyki w grze.
    private int _Doświadczenie;
    private int _Gold;
    private int _Diamenty;
    private int _EnemyKill; // Przetrzymuje ilość zabitych przeciwników
    private int _EnemyKillCount; //Licznik, co ile ma naliczać diamenty za zabitych przeciwników

    //Wartości do teleportu
    private float GranicaLewa;
    private float GranicaPrawa;
    private float GranicaŚrodek;
    [SerializeField]
    [Header("Animacja do pokazania (miniatura teleportu)")]
    private GameObject AnimacjaTeleport;
    [SerializeField]
    [Header("Animacja/Obrazek do pokazania (Obrazek Domu)")]
    private GameObject AnimacjaDom;

    //Zadawane przez gracza obrażenia
    private int _Obrażenia;

    //Parametry czarów
    private int _Leczenie;
    private int _LeczenieKoszt;


    //Przechowuje poziom życia domu
    private int _HousePointMax;
    private int _BierząceHousePoint;
    //Przetrzymuje czas gry podczas pauzy
    private float _CzasGry;
    private Vector2 _SzerokośćPaskaHP;
    void Start()
    {
        //Ustawia czas gry
        Time.timeScale = 1f;
        //Pobiera listęp obiektów w GUI
        _GUIListaObiektów = gameObject.GetComponent<GUIListaObiektów>();
        //Pobiera zapisane już osiągnięcia i ustawia HP House
        _HousePointMax = _ZapisOdczyt.House_Point;
        _BierząceHousePoint = _HousePointMax;
        _Gold = _ZapisOdczyt.Gold;
        _Diamenty = _ZapisOdczyt.Diamond;
        _EnemyKill = _ZapisOdczyt.EnemyKillCount;
        _EnemyKillCount = _ZapisOdczyt.EnemyCount;
        _Doświadczenie = 0;
        //Pobiera szerokość maksymalną paska HP
        _SzerokośćPaskaHP = _GUIListaObiektów.GUIPlayerLista.PasekHP.SzczegółyPaskaHP.WymiaryObrazekHP.sizeDelta;

        GranicaLewa = ZapisOdczyt.DefaultGranicaLewa;
        GranicaPrawa = ZapisOdczyt.DefaultGranicaPrawa;
        GranicaŚrodek = (GranicaLewa + GranicaPrawa) / 2;

        _Leczenie = _ZapisOdczyt.Heal;
        _LeczenieKoszt = Convert.ToInt32(_GUIListaObiektów.GUIPlayerLista.Czary.PieniądzeLeczenie.GetComponent<Text>().text);

        _Obrażenia = _ZapisOdczyt.ClickDamage;
        Odśwież();

    }

    private void Update()
    {
        PokażAnimacjęTeleport();
    }

    /// <summary>
    /// Odświerza wszystkie widoczne elementy GUI
    /// </summary>
    private void Odśwież()
    {
        //Aktualizuje wartości Pieniędzy, EXP i Diamentów
        _GUIListaObiektów.GUIPlayerLista.Pieniądze.text = _Gold.ToString();
        _GUIListaObiektów.GUIPlayerLista.Doświadczenie.text = _Doświadczenie.ToString();
        _GUIListaObiektów.GUIPlayerLista.Diamenty.text = _Diamenty.ToString();
        //Aktualizuje szerokość paska HP i jego napis
        if (_BierząceHousePoint < 0)
        {
            _BierząceHousePoint = 0;
        }
        _GUIListaObiektów.GUIPlayerLista.PasekHP.Pasek_HP_Tekst.text = _BierząceHousePoint.ToString() + " / " + _HousePointMax;
        Vector2 vector2 = new Vector2(((float)_BierząceHousePoint / (float)_HousePointMax) * _SzerokośćPaskaHP.x, _SzerokośćPaskaHP.y);
        _GUIListaObiektów.GUIPlayerLista.PasekHP.SzczegółyPaskaHP.WymiaryObrazekHP.sizeDelta = vector2;
    }
    private void SprawdźGameOver()
    {
        if (_BierząceHousePoint == 0)
        {
            Reklama.WyłączReklamę();
            Time.timeScale = 0;
            _Kamera.GetComponent<SterowanieDefaultGra>().enabled = false;
            _GUIListaObiektów.GUIPlayerLista.Teleport.Teleport.SetActive(false);
            _GUIListaObiektów.GUIPlayerLista.Czary.Czary.SetActive(false);
            _GUIListaObiektów.GUIGameOverLista.Najlepszy.SetActive(false);
            _GUIListaObiektów.GUIGameOverLista.TwójWynik.SetActive(false);
            _GUIListaObiektów.GUIGameOverLista.Wynik.SetActive(false);
            _GUIListaObiektów.GUIGameOverLista.CanvasGameOver.SetActive(true);
        }
    }
    #region Obsługa przycisków
    public void PrzyciskSetting()
    {
        _CzasGry = Time.timeScale;
        Time.timeScale = 0f;
        _GUIListaObiektów.GUIMenuLista.CanvasMenu.SetActive(true);
    }
    public void PrzyciskPowrót()
    {
        _GUIListaObiektów.GUIMenuLista.CanvasMenu.SetActive(false);
        Time.timeScale = _CzasGry;
    }
    public void PrzyciskMenuGame()
    {
        SceneManager.LoadScene("Start");
        Reklama.WyłączReklamę();
    }
    public void PrzyciskUpgrade()
    {
        _GUIListaObiektów.GUIMenuLista.CanvasMenu.SetActive(false);
        _GUIListaObiektów.GUIUlepszeniaLista.CanvasUlepszenia.SetActive(true);
    }
    public void PrzyciskRestart()
    {
        Reklama.WyłączReklamę();
        string nazwaSceny = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(nazwaSceny);
    }
    public void PrzyciskExit()
    {
        OnDestroy();
        Reklama.WyłączReklamę();
        Application.Quit();
    }
    public void PrzyciskPowrótDoMenuZUpgrade()
    {
        _GUIListaObiektów.GUIUlepszeniaLista.CanvasUlepszenia.SetActive(false);
        _GUIListaObiektów.GUIMenuLista.CanvasMenu.SetActive(true);
    }

    //Obsługa Teleportu i jego animacji
    /// <summary>
    /// Zmienia animację w zalezności od położenia kamery
    /// </summary>
    public void PokażAnimacjęTeleport()
    {
        if (_Kamera.transform.position.x < GranicaŚrodek)
        {
            AnimacjaDom.SetActive(false);
            AnimacjaTeleport.SetActive(true);
        }
        else
        {
            AnimacjaDom.SetActive(true);
            AnimacjaTeleport.SetActive(false);
        }
    }
    /// <summary>
    /// Wykonuje teleport w zależności od tego gdzie znajduje się kamera
    /// </summary>
    public void Teleport()
    {
        if (_Kamera.transform.position.x < GranicaŚrodek)
        {
            _Kamera.transform.position = new Vector3(GranicaPrawa, _Kamera.transform.position.y, _Kamera.transform.position.z);
        }
        else
        {
            _Kamera.transform.position = new Vector3(GranicaLewa, _Kamera.transform.position.y, _Kamera.transform.position.z);
        }
    }

    #endregion
    #region Komunikacja z przeciwnikiem
    /// <summary>
    /// Funkcja dodająca pieniądze, EXP, lub diamenty
    /// Wykonywana w klasie przeciwnika przy śmierci
    /// </summary>
    public int DodajGold
    {
        set
        {
            _Gold += value;
            Odśwież();
        }
    }
    public int DodajEXP
    {
        set
        {
            _Doświadczenie += value;
            Odśwież();
        }
    }
    public int DodajDiamenty
    {
        set
        {
            _Diamenty += value;
            Odśwież();
        }
    }
    /// <summary>
    /// Funkcja zadająca przeciwnikowi obrażenia (Wykonywana w klasie przeciwnika)
    /// Funkcja wykonywana w kliknięciu na przeciwnika
    /// </summary>
    public int PoziomZadawanychObrażeń
    {
        get { return _Obrażenia; }
    }

    /// <summary>
    /// Obrażenia zadawane bazie przez przeciwnika
    /// Funkcja wywoływana w klasie przeciwnika
    /// </summary>
    public int ObrażeniaDom
    {
        set
        {
            _BierząceHousePoint -= value;
            Odśwież();
            SprawdźGameOver();
        }
    }
    /// <summary>
    /// Zwiększa licznik zabitych przeciwników o konkretną wartość
    /// </summary>
    public int NaliczKillCount
    {
        set 
        {
            _EnemyKill += value;
            if (_EnemyKill >= _EnemyKillCount)
            {
                _Diamenty += 1;
                _EnemyKill = 0;
            }
            Odśwież();
        }
    }
    #endregion
    #region Komunikacja z generatorem
    /// <summary>
    /// Funkcja zmieniająca Numer fali
    /// Podaje się się numer fali
    /// </summary>
    public int KtóraFala
    {
        set
        {
            _GUIListaObiektów.GUIPlayerLista.Fala.text = "Wave: " + value.ToString();
            Odśwież();
        }
    }

    #endregion
    #region Funkcje Czarów
    public void Leczenie()
    {
        if (_LeczenieKoszt <= _Gold && _BierząceHousePoint != _HousePointMax)
        {
            _Gold -= _LeczenieKoszt;
            if (_Leczenie >= (_HousePointMax - _BierząceHousePoint))
            {
                _BierząceHousePoint = _HousePointMax;
            }
            else
            {
                _BierząceHousePoint += _Leczenie;
            }
            Odśwież();
        }
    }
    #endregion
    #region Inne funkcje
    /// <summary>
    /// Wykonywane przy wyściu z planszy/gry. (Zapis wszystkich wyników)
    /// </summary>
    private void OnDestroy()
    {
        _ZapisOdczyt.Score = _Doświadczenie + _ZapisOdczyt.Score;
        _ZapisOdczyt.Gold = _Gold;
        _ZapisOdczyt.Diamond = _Diamenty;
        _ZapisOdczyt.EnemyKillCount = _EnemyKill;
    }
    /// <summary>
    /// Zmienia czas wraz z fixed Time.
    /// </summary>
    public float ZmieńCzas
    {
        get { return Time.timeScale; }
        set
        {
            Time.timeScale = value;
            Time.fixedDeltaTime = value * 0.2f;
        }
    }

    #endregion
    #region Menu Ulepszenia
    //Funkcja przywracająca Punkty życia
    public void HealAllHP()
    {
        _BierząceHousePoint = _HousePointMax;
        Odśwież();
    }
    //Funkcja zwiększająca MAX HP
    public void AddMaxHP()
    {
        _HousePointMax += 50;
        Odśwież();
    }
    //Funkcja zwiększająca zadawane obrażenia
    public void AddDamage()
    {
        _Obrażenia += 10;
        Odśwież();
    }
    #endregion

}
