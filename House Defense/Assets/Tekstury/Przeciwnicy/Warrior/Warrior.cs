using System.Collections;
using System.Collections.Generic;
using System.Management.Instrumentation;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    private enum StanAnimacji
    {
        Idle, Walk, Hit, death
    }

    public RectTransform PasekHP;
    public GUISkrypt GUISkrypt;
    //Miejsce w którym jest generowane i jest ogsługa zliczania zabitych przeciwników
    public Generowanie Generator;

    /// <summary>
    /// Podczas tworzenia przeciwnika
    /// </summary>
    /// <param name="Nazwa">Pełna nazwa przeciwnika jaka będzie wyświetlana podczas debugowania.</param>
    /// <param name="Życie">Poziom życia przeciwnika</param>
    /// <param name="Prędkość">Prękość przeciwnika</param>
    /// <param name="Obrażenia">Obrażenia jakie zadaje przeciwnik</param>
    /// <param name="Granica">Granica przy której przeciwnik się zatrzymuje</param>
    /// <param name="WartośćGold">Ile Golda dodaje po śmierci</param>
    /// <param name="WartośćEXP">Ile dodaje EXP po śmierci</param>
    /// <param name="WartośćDiamenty">Ile i czy dodaje diamenty po śmierci</param>
    public void Kreator(string Nazwa,int Życie, float Prędkość, int Obrażenia, float Granica, int WartośćGold, int WartośćEXP, int WartośćDiamenty)
    {
        gameObject.name = Nazwa;
        _Życie = Życie;
        _ŻycieMAX = Życie;
        _Prędkość = Prędkość;
        _Obrażenia = Obrażenia;
        _Granica = Granica;
        _WartośćGold = WartośćGold;
        _WartośćEXP = WartośćEXP;
        _WartośćDiamenty = WartośćDiamenty;

    }
    /// <summary>
    /// Podczas tworzenia przeciwnika
    /// </summary>
    /// <param name="Nazwa">Numer przeciwnika dodawany do nazwy przy debugowaniu.</param>
    /// <param name="Życie">Poziom życia przeciwnika</param>
    /// <param name="Prędkość">Prękość przeciwnika</param>
    /// <param name="Obrażenia">Obrażenia jakie zadaje przeciwnik</param>
    /// <param name="Granica">Granica przy której przeciwnik się zatrzymuje</param>
    /// <param name="WartośćGold">Ile Golda dodaje po śmierci</param>
    /// <param name="WartośćEXP">Ile dodaje EXP po śmierci</param>
    /// <param name="WartośćDiamenty">Ile i czy dodaje diamenty po śmierci</param>
    public void Kreator(int Nazwa, int Życie, float Prędkość, int Obrażenia, float Granica, int WartośćGold, int WartośćEXP, int WartośćDiamenty)
    {
        gameObject.name = "Warrior: " + Nazwa;
        _Życie = Życie;
        _ŻycieMAX = Życie;
        _Prędkość = Prędkość;
        _Obrażenia = Obrażenia;
        _Granica = Granica;
        _WartośćGold = WartośćGold;
        _WartośćEXP = WartośćEXP;
        _WartośćDiamenty = WartośćDiamenty;
    }

    private Animator _Animator;
    private int _Życie;
    private int _ŻycieMAX;
    private int _Obrażenia;
    private float _Prędkość;
    private float _Granica;
    private int _WartośćGold;
    private int _WartośćEXP;
    private int _WartośćDiamenty;
    private float _SzerokośćPaskaHP;
    //Czy można już atakować postać
    private bool _Nieśmiertelny;

    // Start is called before the first frame update
    void Start()
    {
        _Animator = gameObject.GetComponent<Animator>();
        ZmieńAnimację(StanAnimacji.Walk);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        _Nieśmiertelny = true;
        _SzerokośćPaskaHP = PasekHP.sizeDelta.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (_Animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            if (gameObject.transform.position.x > _Granica)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - (_Prędkość * Time.deltaTime),
                    gameObject.transform.position.y, gameObject.transform.position.z);
            }
            else
            {
                gameObject.transform.position = new Vector3(_Granica,
                    gameObject.transform.position.y, gameObject.transform.position.z);
                ZmieńAnimację(StanAnimacji.Hit);
            }
        }
    }

    private void OnMouseDown()
    {
        if (_Nieśmiertelny == false)
        {
        _Życie -= GUISkrypt.PoziomZadawanychObrażeń;
        }
        if (_Życie <= 0)
        {
            Generator.OdejmijPrzeciwnik(Generowanie.ListaPrzeciwników.Warrior);
            ZmieńAnimację(StanAnimacji.death);
            PasekHP.sizeDelta = new Vector2(0,PasekHP.sizeDelta.y);
        }
        else
        {
            PasekHP.sizeDelta = new Vector2(((float)_Życie/(float)_ŻycieMAX)*_SzerokośćPaskaHP, PasekHP.sizeDelta.y);
        }

    }


    public void ZniszczPostać()
    {
        Destroy(gameObject);
    }
    /// <summary>
    /// Wyłącza kolider i dodaje punkty do wyniku
    /// </summary>
    public void WyłączCollider()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        GUISkrypt.DodajGold = _WartośćGold;
        GUISkrypt.DodajEXP = _WartośćEXP;
        GUISkrypt.DodajDiamenty = _WartośćDiamenty;
        GUISkrypt.NaliczKillCount = 1;
    }
    public void ZadajObrażenia()
    {
        GUISkrypt.ObrażeniaDom = _Obrażenia;
    }
    void ZmieńAnimację(StanAnimacji stanAnimacji)
    {
        if (stanAnimacji == StanAnimacji.Idle)
        {
            _Animator.SetBool("Stój",true);
            _Animator.SetBool("Idź",false);
            _Animator.SetBool("Atak", false);
            _Animator.SetBool("Śmierć", false);
        }
        if (stanAnimacji == StanAnimacji.Walk)
        {
            _Animator.SetBool("Stój", false);
            _Animator.SetBool("Idź", true);
            _Animator.SetBool("Atak", false);
            _Animator.SetBool("Śmierć", false);
        }
        if (stanAnimacji == StanAnimacji.Hit)
        {
            _Animator.SetBool("Stój", false);
            _Animator.SetBool("Idź", false);
            _Animator.SetBool("Atak", true);
            _Animator.SetBool("Śmierć", false);
        }
        if (stanAnimacji == StanAnimacji.death)
        {
            _Animator.SetBool("Stój", false);
            _Animator.SetBool("Idź", false);
            _Animator.SetBool("Atak", false);
            _Animator.SetBool("Śmierć", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Bariera")
        {
            _Nieśmiertelny = false;
        }
    }
}
