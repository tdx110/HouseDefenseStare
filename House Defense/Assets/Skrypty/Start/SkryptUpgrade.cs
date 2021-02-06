using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkryptUpgrade : MonoBehaviour
{
    [SerializeField]
    private ListaSkryptów listaSkryptów;
    private ZapisOdczyt zapisOdczyt = new ZapisOdczyt();
    #region ClickDamage
    // Wzór/funkcja do generowania poziomu obrażeń
    // Zwraca ilość obrażeń jaka o ile będzie zwiększona na następnym poziomie
    private int nextClickDamageValue
    {
        get
        {
            int obrażenia;
            obrażenia = 10;
            return obrażenia;
        }
    }
    // Wzór/funkcja do zwracania kosztów następnego ulepszenia
    private int nextClickDamageCost
    {
        get
        {
            int koszta;
            koszta = zapisOdczyt.ClickDamageLevelUpgrade * 100;
            return koszta;
        }
    }
    #endregion
    #region House_Point
    // Zwraca wartość o ile podniesie życie domu
    // Po ulepszeniu
    private int nextHouse_PointValue
    {
        get
        {
            int House_Point;
            House_Point = 50;
            return House_Point;
        }

    }
    // Zwraca koszt następnego ulepszenia życia domu
    private int nextHouse_PointCost
    {
        get
        {
            int koszta;
            koszta = zapisOdczyt.House_PointLevelUpgrade * 100;
            return koszta;
        }
    }
    #endregion
    #region Health
    // Zwraca o ile zwiększy się siła leczenia
    private int nextHealthValue
    {
        get
        {
            int Health;
            Health = 20;
            return Health;
        }

    }
    //Zwraca ile kosztuje następne ulepszenie leczenia
    private int nextHealthCost
    {
        get
        {
            int koszta;
            koszta = zapisOdczyt.HealLevelUpgrade * 100;
            return koszta;
        }
    }
    #endregion
    #region Przyciski Upgrade
    /// <summary>
    /// Metoda wykonywana przy naciśnięciu zakupu "Click"
    /// </summary>
    public void buyClickDamage()
    {
        if (nextClickDamageCost <= zapisOdczyt.Gold)
        {
            zapisOdczyt.Gold = zapisOdczyt.Gold - nextClickDamageCost;
            zapisOdczyt.ClickDamageLevelUpgrade += 1;
            zapisOdczyt.ClickDamage += nextClickDamageValue;
            OnEnable();
        }
    }
    /// <summary>
    /// Metoda wykonywana przy naciśnięciu zakupu Punktów HP House
    /// </summary>
    public void buyHouse_Point()
    {
        if (nextHouse_PointCost<= zapisOdczyt.Gold)
        {
            zapisOdczyt.Gold = zapisOdczyt.Gold - nextHouse_PointCost;
            zapisOdczyt.House_PointLevelUpgrade += 1;
            zapisOdczyt.House_Point += nextHouse_PointValue;
            OnEnable();
        }


    }
    /// <summary>
    /// Metoda wykonywana przy ulepszaniu czaru leczenia
    /// </summary>
    public void buyHealPower()
    {
        if (nextHealthCost <= zapisOdczyt.Gold)
        {
            zapisOdczyt.Gold = zapisOdczyt.Gold - nextHealthCost;
            zapisOdczyt.HealLevelUpgrade += 1;
            zapisOdczyt.Heal += nextHealthValue;
            OnEnable();
        }


    }
    #endregion
    private void OnEnable()
    {
        listaSkryptów.przyciskiUpgrade.Actual.ActualClick.text = zapisOdczyt.ClickDamage.ToString() + " dam.";
        listaSkryptów.przyciskiUpgrade.Actual.ActualHouse.text = zapisOdczyt.House_Point.ToString() + " HP";
        listaSkryptów.przyciskiUpgrade.Actual.ActualHeal.text = zapisOdczyt.Heal.ToString() + " HP";

        listaSkryptów.przyciskiUpgrade.NextLvl.NextLvlCllick.text = nextClickDamageValue.ToString() + " dam.";
        listaSkryptów.przyciskiUpgrade.NextLvl.NextLvlHeal.text = nextHealthValue.ToString() + " HP";
        listaSkryptów.przyciskiUpgrade.NextLvl.NextLvlHouse.text = nextHouse_PointValue.ToString() + " HP";

        listaSkryptów.przyciskiUpgrade.Cost.CostClick.text = nextClickDamageCost.ToString();
        listaSkryptów.przyciskiUpgrade.Cost.CostHeal.text = nextHealthCost.ToString();
        listaSkryptów.przyciskiUpgrade.Cost.CostHouse.text = nextHouse_PointCost.ToString();

        listaSkryptów.canvasOgólne.PasekZasobów.Pieniądze.text = zapisOdczyt.Gold.ToString();
        listaSkryptów.canvasOgólne.PasekZasobów.Doświadczenie.text = zapisOdczyt.Score.ToString();
        listaSkryptów.canvasOgólne.PasekZasobów.Diamenty.text = zapisOdczyt.Diamond.ToString();
    }
    public void Powrót()
    {
        listaSkryptów.przyciskiStart.CanvasStart.SetActive(true);
        listaSkryptów.przyciskiUpgrade.CanvasUpgrade.SetActive(false);
    }
}
