using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReklamaMenuStart : MonoBehaviour
{
    public AdMob adMobReklama;

    // Start is called before the first frame update
    void Start()
    {
        adMobReklama = new AdMob(AdPosition.TopLeft, AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(wielkośćBanera));
        adMobReklama.BannerShow();
    }
private int wielkośćBanera
    {
        get
        {
            int wielkość = 0;
            if (Screen.width < 1400)
            {
                wielkość = 450;
            }
            else
            {
                wielkość = 600;
            }
            return wielkość;
        }
    }
}
