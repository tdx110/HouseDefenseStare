using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds.Api;

public class AdMob :MonoBehaviour
{
    /// <summary>
    /// W zmiennych wpisać Id reklamy
    /// ustalić lokalizację banera
    /// W reklamie Video (naliczającej punkty) wpisać funkcję obsługującą obejrzenie reklamy
    /// Hodzi o 
    /// </summary>
    private AdPosition pozycja;
    private AdSize wielkość;

    #region Zmienne
    public BannerView bannerView;
    public InterstitialAd interstitialAd;
    public RewardBasedVideoAd rewardBasedVideoAd;

    //Kod do reklam testowych
    private string idApp = "ca-app-pub-2278830977776782~4858036550";
    private string idBanner = "ca-app-pub-3940256099942544/6300978111";
    private string idInterstitial = "ca-app-pub-3940256099942544/1033173712";
    private string idVideo = "ca-app-pub-3940256099942544/5224354917";
    #endregion
    #region Konstruktory
    public AdMob() { }

    public AdMob(AdPosition _adPosition)
    {
        pozycja = _adPosition;
    }
    public AdMob(AdPosition _pozycjaBanera, AdSize _wielkośćBanera)
    {
        pozycja = _pozycjaBanera;
        wielkość = _wielkośćBanera;
    }
    public AdMob(AdPosition _pozycjaBanera, AdSize _wielkośćBanera, string _idBannera)
    {
        pozycja = _pozycjaBanera;
        wielkość = _wielkośćBanera;
        idBanner = _idBannera;
    }
    public AdMob(AdPosition _pozycjaBanera, AdSize _wielkośćBanera,string _idBannera, string _idInterstitial, string _idVideo)
    {
        pozycja = _pozycjaBanera;
        wielkość = _wielkośćBanera;
        idBanner = _idBannera;
        idInterstitial = _idInterstitial;
        idVideo = _idVideo;
    }
    #endregion

    public void Start()
    {

        MobileAds.Initialize(idApp);
    }

    #region Baner
    public void BannerShow()
    {
        
        this.bannerView = new BannerView(idBanner, wielkość, pozycja);
        AdRequest request = new AdRequest.Builder().Build();
        this.bannerView.LoadAd(request);
    }
    public void BannerDestroy()
    {
        if (bannerView != null)
        {
            bannerView.Destroy();
        }
    }
    #endregion

    #region Reklama Pełnoekranowa
    public void InterstitialShow()
    {
        this.interstitialAd = new InterstitialAd(idInterstitial);
        AdRequest request = new AdRequest.Builder().Build();
        this.interstitialAd.LoadAd(request);
        this.interstitialAd.OnAdLoaded += InterstitialVoid;
    }
    private void InterstitialVoid(object sender, EventArgs args)
    {
        if (this.interstitialAd.IsLoaded())
        {
            this.interstitialAd.Show();
        }
    }
    #endregion
    #region Reklama Video z nagrodą
    //Reklama Video z nagrodą (Legacy API)
    public void VideoAdInitialize()
    {
        this.rewardBasedVideoAd = RewardBasedVideoAd.Instance;
        AdRequest request = new AdRequest.Builder().Build();
        this.rewardBasedVideoAd.LoadAd(request, idVideo);
        //Tutaj metoda wykonywana jak wczyta reklamę i będzie gotowa do wyświetlenia.
        //this.rewardBasedVideoAd.OnAdLoaded += rewardBasedVideoAdVoid;

        //Tutaj odnośnik do własnej reklamy
        //this.rewardBasedVideoAd.OnAdRewarded += Naliczono;
    }
    //Pokazuje po wczytaniu film
    public void rewardBasedVideoAdVoid(object sender, EventArgs args)
    {
        rewardBasedVideoAd.Show();
    }
    //Funkcja testowa do wykonania po oglądnięciu reklamy
    private void Naliczono(object sender, Reward reward)
    {
        string _typNaliczania = reward.Type;
        double _ilość = reward.Amount;
    }
    #endregion
}

