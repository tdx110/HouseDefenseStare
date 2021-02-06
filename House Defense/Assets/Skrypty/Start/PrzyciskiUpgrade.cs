using System;
using UnityEngine;
using UnityEngine.UI;

public class PrzyciskiUpgrade : MonoBehaviour
{
    public GameObject CanvasUpgrade;
    public napisy Napisy;
    public actual Actual;
    public nextLvl NextLvl;
    public cost Cost;
    public GameObject Powrót;

    [Serializable]
    public class napisy
    {
        public Text Click;
        public Text Houde;
        public Text Heal;
    }
    [Serializable]
    public class actual
    {
        public Text ActualText;
        public Text ActualClick;
        public Text ActualHouse;
        public Text ActualHeal;
    }
    [Serializable]
    public class nextLvl
    {
        public Text NextLvlText;
        public Text NextLvlCllick;
        public Text NextLvlHouse;
        public Text NextLvlHeal;
    }
    [Serializable]
    public class cost
    {
        public Text CostText;
        public Text CostClick;
        public Text CostHouse;
        public Text CostHeal;
    }
}
