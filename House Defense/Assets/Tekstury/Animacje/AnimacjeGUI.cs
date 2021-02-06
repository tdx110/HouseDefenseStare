using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimacjeGUI : MonoBehaviour
{
    public void AnimacjaAddHP_Kreator(int _HP_Max, int _HP_Bierzące, int _CzarLeczenia)
    {
        if (_CzarLeczenia > _HP_Max - _HP_Bierzące)
            gameObject.GetComponent<Text>().text = "+" + Convert.ToString(_HP_Max - _HP_Bierzące);
        else
            gameObject.GetComponent<Text>().text ="+" + Convert.ToString(_CzarLeczenia);
    }
    void Zniszcz()
    {
        Destroy(gameObject);
    }
}
