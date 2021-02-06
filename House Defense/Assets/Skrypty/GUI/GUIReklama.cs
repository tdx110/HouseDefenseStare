using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIReklama : MonoBehaviour
{
    private AdMob adMobReklama;
    //private AdMob _ReklamaHealAllHP = new AdMob();
    //private AdMob _ReklamaMaxHP = new AdMob();
    private AdMob _ReklamaMoreDamage = new AdMob();

    public GUIListaObiektów _GUIListaObiektów;
    public GUISkrypt _GUISkrypt;
    // Start is called before the first frame update
    void Start()
    {
        _GUIListaObiektów.GUIUlepszeniaLista.HeallAllHP.SetActive(false);
        _GUIListaObiektów.GUIUlepszeniaLista.MoreBaseHP.SetActive(false);
        _GUIListaObiektów.GUIUlepszeniaLista.MoreDamage.SetActive(false);

        adMobReklama = new AdMob(AdPosition.BottomLeft, AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(wielkośćBanera));
        adMobReklama.BannerShow();
        //_ReklamaHealAllHP.VideoAdInitialize();
        //_ReklamaHealAllHP.rewardBasedVideoAd.OnAdLoaded += PokażPrzyciskHealAllHP;
        //_ReklamaHealAllHP.rewardBasedVideoAd.OnAdRewarded += OglądnięteHealAllHP;
        //_ReklamaMaxHP.VideoAdInitialize();
        //_ReklamaMaxHP.rewardBasedVideoAd.OnAdLoaded += PokażPrzyciskAddMaxHP;
        //_ReklamaMaxHP.rewardBasedVideoAd.OnAdRewarded += OglądnięteAddMaxHP;
        _ReklamaMoreDamage.VideoAdInitialize();
        _ReklamaMoreDamage.rewardBasedVideoAd.OnAdLoaded += PokażPrzyciskMoreDamage;
        _ReklamaMoreDamage.rewardBasedVideoAd.OnAdRewarded += OglądnięteMoreDamage;

    }
    #region Reklama
    private int wielkośćBanera
    {
        get
        {
            int wielkość = 0;
            if (Screen.width < 1400)
            {
                wielkość = 250;
            }
            else
            {
                wielkość = 250;
            }
            return wielkość;
        }
    }
    public void WyłączReklamę()
    {
        adMobReklama.BannerDestroy();
    }
    #endregion
    #region Reklamy z punktami
    //#region Reklama Heal All HP
    //public void VideoHealAllHP()
    //{
    //    _ReklamaHealAllHP.rewardBasedVideoAd.Show();
    //    _GUIListaObiektów.GUIUlepszeniaLista.HeallAllHP.SetActive(false);
    //    _ReklamaHealAllHP.VideoAdInitialize();
    //}
    //private void PokażPrzyciskHealAllHP(object sender, EventArgs args)
    //{
    //    _GUIListaObiektów.GUIUlepszeniaLista.HeallAllHP.SetActive(true);
    //}
    //private void OglądnięteHealAllHP(object sender, Reward reward)
    //{
    //    Można wkorzystać w przyszłości.
    //    string _typNaliczania = reward.Type;
    //    double _ilość = reward.Amount;
    //    _GUISkrypt.HealAllHP();
    //}

    //#endregion
    //#region MAX HP
    //public void VideoMaxHP()
    //{
    //    _ReklamaMaxHP.rewardBasedVideoAd.Show();
    //    _GUIListaObiektów.GUIUlepszeniaLista.MoreBaseHP.SetActive(false);
    //    _ReklamaMaxHP.VideoAdInitialize();
    //}
    //private void PokażPrzyciskAddMaxHP(object sender, EventArgs args)
    //{
    //    _GUIListaObiektów.GUIUlepszeniaLista.MoreBaseHP.SetActive(true);
    //}
    //public void OglądnięteAddMaxHP(object sender, Reward reward)
    //{
    //    //Można wkorzystać w przyszłości.
    //    //string _typNaliczania = reward.Type;
    //    //double _ilość = reward.Amount;
    //    _GUISkrypt.AddMaxHP();
    //}
    //#endregion
    #region More Damage
    public void VideoMoreDamage()
    {
        _ReklamaMoreDamage.rewardBasedVideoAd.Show();
        _GUIListaObiektów.GUIUlepszeniaLista.MoreDamage.SetActive(false);
        _ReklamaMoreDamage.VideoAdInitialize();
    }
    private void PokażPrzyciskMoreDamage(object sender, EventArgs args)
    {
        _GUIListaObiektów.GUIUlepszeniaLista.MoreDamage.SetActive(true);
    }
    public void OglądnięteMoreDamage(object sender, Reward reward)
    {
        //string _typNaliczania = reward.Type;
        //double _ilość = reward.Amount;
        _GUISkrypt.AddDamage();
    }
    #endregion
    #endregion
    private void OnDestroy()
    {       
        //_ReklamaHealAllHP.rewardBasedVideoAd.OnAdLoaded -= PokażPrzyciskHealAllHP;
        //_ReklamaHealAllHP.rewardBasedVideoAd.OnAdRewarded -= OglądnięteHealAllHP;
        //_ReklamaMaxHP.rewardBasedVideoAd.OnAdLoaded -= PokażPrzyciskAddMaxHP;
        //_ReklamaMaxHP.rewardBasedVideoAd.OnAdRewarded -= OglądnięteAddMaxHP;
        _ReklamaMoreDamage.rewardBasedVideoAd.OnAdLoaded -= PokażPrzyciskMoreDamage;
        _ReklamaMoreDamage.rewardBasedVideoAd.OnAdRewarded -= OglądnięteMoreDamage;
    }
}
