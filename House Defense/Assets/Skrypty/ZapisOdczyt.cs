using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZapisOdczyt : MonoBehaviour
{
    #region Stałe do gry
    public const float DefaultGranicaLewa = 0;
    public const float DefaultGranicaPrawa = 900;

    #endregion

    #region Zmienne i Stałe

    private const bool TrybDev = false;
    private const string ScoreName = "Score";
    private const string GoldName = "Gold";
    private const string DiamondName = "Diamond";

    private const string ClickDamageName = "ClickDamage";
    private const int ClickDamageValue = 10;
    private const string ClickDamageLevelName = "Click Damage Level";
    private const int ClickDamageLevelValue = 1;

    private const string HealName = "Heal";
    private const int HealLevelValue = 1;
    private const string HealLevelName = "Heal Level";
    private const int HealValue = 30;

    private const string House_PointName = "HP Point";
    private const int House_PointLevelValue = 1;
    private const string House_PointLevelName = "HP Point Level";
    private const int House_PointValue = 100;

    private const string EnemyCountName = "Enemy Count Name";
    private const string EnemyKillCountName = "Enemy Kill Count";
    private const int EnemyCountValue = 10;

    private const string WarriorLevel = "Warrior Level";

    private const string WarriorEnable = "Warrior Enable";
    private const bool WarriorEnableValue = true;
    private const string WarriorUpgadeCost = "Warrior Upgrade Cost";
    private const int WarriorUpgradeCostValue = 100;
    private const string WarriorCountPerWave = "Enemy Count Per Wave";
    private const double WarriorCountPerWaveValue = 1;
    private const int WarriorDamage = 1;
    private const int WarriorLive = 20;



    private const int ArrowDamageValue = 300;
    private const int ArrowDamageLevelValue = 1;
    private const int FireBallDamageValue = 1500;
    private const int FireBallDamageLevelValue = 1;
    #endregion
    public ZapisOdczyt() { }

    #region Konstruktory pojedyńcze
    #region Waluta
    public int Score
    {
        get
        {
            if (TrybDev)
            {
                return PlayerPrefs.GetInt(ScoreName, 99999);
            }
            else
            {
                return PlayerPrefs.GetInt(ScoreName, 0);
            }
        }
        set { PlayerPrefs.SetInt(ScoreName, value); }
    }
    public int Gold
    {
        get
        {
            if (TrybDev)
            {
                return PlayerPrefs.GetInt(GoldName, 99999);
            }
            else
            {
                return PlayerPrefs.GetInt(GoldName, 0);
            }
        }
        set { PlayerPrefs.SetInt(GoldName, value); }
    }
    public int Diamond
    {
        get
        {
            if (TrybDev)
            {
                return PlayerPrefs.GetInt(DiamondName, 99999);
            }
            else
            {
                return PlayerPrefs.GetInt(DiamondName, 0);
            }
        }
        set { PlayerPrefs.SetInt(DiamondName, value); }
    }
    #endregion
    #region ClickDamage
    public int ClickDamage
    {
        get { return PlayerPrefs.GetInt(ClickDamageName, ClickDamageValue); }
        set { PlayerPrefs.SetInt(ClickDamageName, value); }
    }
    public int ClickDamageLevelUpgrade
    {
        get { return PlayerPrefs.GetInt(ClickDamageLevelName, ClickDamageLevelValue); }
        set { PlayerPrefs.SetInt(ClickDamageLevelName, value); }
    }

    #endregion
    #region House_Point
    public int House_Point
    {
        get { return PlayerPrefs.GetInt(House_PointName, House_PointValue); }
        set { PlayerPrefs.SetInt(House_PointName, value); }
    }
    public int House_PointLevelUpgrade
    {
        get { return PlayerPrefs.GetInt(House_PointLevelName, House_PointLevelValue); }
        set { PlayerPrefs.SetInt(House_PointLevelName, value); }
    }
    #endregion
    #region Heal
    public int Heal
    {
        get { return PlayerPrefs.GetInt(HealName, HealValue); }
        set { PlayerPrefs.SetInt(HealName, value); }
    }
    public int HealLevelUpgrade
    {
        get { return PlayerPrefs.GetInt(HealLevelName, HealLevelValue); }
        set { PlayerPrefs.SetInt(HealLevelName, value); }
    }
    #endregion
    #region Enemy Kill
    /// <summary>
    /// Licznik zabitych przeciwników. Zwraca licznik, który zlicza pkt. za zabitych przeciwników.
    /// </summary>
    public int EnemyKillCount
    {
        get { return PlayerPrefs.GetInt(EnemyKillCountName, 0); }
        set { PlayerPrefs.SetInt(EnemyKillCountName, value); }
    }
    /// <summary>
    /// Zwraca co ile pkt ma zostać naliczony diament
    /// </summary>
    public int EnemyCount
    {
        get { return PlayerPrefs.GetInt(EnemyCountName, EnemyCountValue); }
        set { PlayerPrefs.SetInt(EnemyCountName, value); }
    }
    #endregion
    #region Pozostałe


    #endregion

    #endregion
}
