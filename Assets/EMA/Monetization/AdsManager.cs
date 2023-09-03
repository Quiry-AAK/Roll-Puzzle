using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using EMA;

namespace EMA
{
    public class AdsManager : MonoBehaviour
    { 
        AdsFunctions adsFunctions;
        private void Awake()
        {
            adsFunctions = new AdsFunctions();
        }

        private void Start()
        {
            Advertisement.AddListener(adsFunctions);
#if UNITY_IOS
            Advertisement.Initialize(AdsStats.instance.GameId[0], adsStats.TestMode);
#else
            Advertisement.Initialize(AdsStats.instance.GameId[1], AdsStats.instance.TestMode);
#endif
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        }

        public void HideBanner()
        {
            Advertisement.Banner.Hide();
        }
  
        public void ShowAdsVideo(string placementId, Action onSuccess)
        {
            AdsStats.instance.OnRewardedSuccess = onSuccess;
            if (Advertisement.IsReady())
            {
                Advertisement.Show(placementId);
            }
            else
            {
                Debug.Log("Advertisement not ready");
            }
        }

        public  IEnumerator ShowBannerWhenInitialized()
        {
            while (!Advertisement.isInitialized)
            {
                yield return new WaitForSeconds(0.5f);
            }
#if UNITY_IOS
            Advertisement.Banner.Show(AdsStats.instance.Banner[0]);
#else
            Advertisement.Banner.Show(AdsStats.instance.Banner[1]);
#endif
        }
    }
}

