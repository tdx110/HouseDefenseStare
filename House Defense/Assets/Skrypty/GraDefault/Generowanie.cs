using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generowanie : MonoBehaviour
{
    public enum ListaPrzeciwników
    {
        Warrior
    }
    //Przechowuje inforacje, która jest fala
    public int fala;

    [SerializeField]
    [Header("Główne ciało Warrior, które jest jako wzór przy tworzeniu.")]
    private GameObject WarriorWzór;
    [SerializeField]
    [Header("GUI do połączenia z obsługą Przeciwników")]
    private GUISkrypt GUISkrypt;

    GameObject _CiałoTworzone;
    Warrior _SkryptTworzony;

    private int _LicznikWarriorPozostali;
    private int _LicznikWarriorDoGenerowania;
      void Start()
    {
        fala = 1;
        _LicznikWarriorPozostali = 1;
        _LicznikWarriorDoGenerowania = 1;
        GUISkrypt.KtóraFala = fala;

        InvokeRepeating("GenerujWarrior", 3,2);
    }
    #region Obsługa Warrior
    private void GenerujWarrior()
    {

        _CiałoTworzone = Instantiate(WarriorWzór, gameObject.transform.position, Quaternion.identity);
        _SkryptTworzony = _CiałoTworzone.GetComponent<Warrior>();
        _SkryptTworzony.GUISkrypt = GUISkrypt;
        _SkryptTworzony.Generator = gameObject.GetComponent<Generowanie>();
        _SkryptTworzony.Kreator(_LicznikWarriorDoGenerowania, GenerowanieŻycieWarrior, 50, 1, 20, GenerowanieGoldWarrior, 1, 0);
        _LicznikWarriorDoGenerowania -= 1;
        //Zatrzymuje generowanie Warrior jeśli już wszystkich przeciwników wygenerował
        if (_LicznikWarriorDoGenerowania ==0)
        {
            CancelInvoke("GenerujWarrior");
        }
    }
    private int GenerowanieŻycieWarrior
    { get 
        {
            int wartość;
            wartość = (int) (fala * 10);
            //wartość =(int) ((Math.Round((double)fala/2.0,0)+1)*10);
            return wartość;
        }
    }
    private int GenerowanieGoldWarrior
    {
        get 
        {
            int wynik;
            int matem = (int)(fala / 10.0);
            wynik = (int)(matem+1);
            return wynik;
        }
    }
    #endregion
    #region Obsługa wszystkich fal
    /// <summary>
    /// Zmniejsza wartość licznika zliczającego odpowiedniego przeciwnika.
    /// Funckcja wywoływana przez przeciwnika umierającego
    /// </summary>
    /// <param name="Przeciwnik">Licznik za jakiego przeciwnika ma być odpowiedzialny</param>
    public void OdejmijPrzeciwnik(ListaPrzeciwników Przeciwnik)
    {
        if (Przeciwnik == ListaPrzeciwników.Warrior)
        {
            _LicznikWarriorPozostali -= 1;
        }

        SprawdźCzyPusto();
    }
    /// <summary>
    /// Sprawdza czy już żadnego przeciwnika nie ma na planszy i nie został do respawnu
    /// </summary>
    private void SprawdźCzyPusto()
    {
        float czasRespawn = 2.0f;
        if (_LicznikWarriorDoGenerowania == 0 && _LicznikWarriorPozostali == 0)
        {
            fala += 1;
            _LicznikWarriorDoGenerowania = fala;
            _LicznikWarriorPozostali = fala;
            GUISkrypt.KtóraFala = fala;

            if (fala%5==0)
            {
                czasRespawn = 0.8f;
            }
            InvokeRepeating("GenerujWarrior", 3, czasRespawn);
        }
    }
    /// <summary>
    /// Odczekaj określony czas pomiędzy falami
    /// W przyszłości do zastąpienia przez Aniamcję
    /// </summary>
    private void OdczekajMiędzyFalami()
    {

    }
    #endregion
    // Update is called once per frame
    void Update()
    {

    }
    
}
