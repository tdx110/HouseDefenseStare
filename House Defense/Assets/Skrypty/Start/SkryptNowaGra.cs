using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SkryptNowaGra : MonoBehaviour
{
    public ListaSkryptów listaSkryptów;
    private ReklamaMenuStart reklama;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Powrót()
    {
        listaSkryptów.przyciskiNowaGra.CanvasNowaGra.SetActive(false);
        listaSkryptów.przyciskiStart.CanvasStart.SetActive(true);
    }
    public void Rozpocznij()
    {
        reklama = listaSkryptów.canvasOgólne.Reklama.GetComponent<ReklamaMenuStart>();
        reklama.adMobReklama.BannerDestroy();
        SceneManager.LoadScene("GraDefault");
    }
}
