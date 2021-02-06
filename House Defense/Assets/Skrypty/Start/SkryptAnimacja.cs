using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkryptAnimacja : MonoBehaviour
{
 
    private Animator PostaćAnimacja;
    private int Licznik;
    // Start is called before the first frame update
    void Start()
    {
        PostaćAnimacja = GetComponent<Animator>();
        Licznik = 0;
        PostaćAnimacja.SetBool("Stój", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Animacja pokazowa Warrior
    /// </summary>
    private void AnimacjaTestowa()
    {
        Licznik = Licznik + 1;
        if (Licznik == 2 && PostaćAnimacja.GetBool("Stój"))
        {
            PostaćAnimacja.SetBool("Stój", false);
            PostaćAnimacja.SetBool("Idź", true);
            Licznik = 0;
        }
        if (Licznik == 3 && PostaćAnimacja.GetBool("Idź"))
        {
            PostaćAnimacja.SetBool("Idź", false);
            PostaćAnimacja.SetBool("Atakuj", true);
            Licznik = 0;
        }

        if (Licznik == 2 && PostaćAnimacja.GetBool("Atakuj"))
        {
            PostaćAnimacja.SetBool("Atakuj", false);
            PostaćAnimacja.SetBool("Stój", true);
            Licznik = 0;
        }
    }
}
