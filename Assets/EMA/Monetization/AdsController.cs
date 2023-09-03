using UnityEngine;

namespace EMA.Monetization
{
    public class AdsController : MonoBehaviour
    {
        private AdsManager adsManager;
        
        private void Start()
        {
            adsManager = gameObject.AddComponent<AdsManager>();
        }

        public int gainCoin = 1;

        public void ShowVideoAds()
        {
            adsManager.ShowAdsVideo(AdsStats.instance.Video[1], null);
        }

        public void ShowRewardedAds()
        {
#if UNITY_IOS
            adsManager.ShowAdsVideo(AdsStats.instance.RewardedVideo[0], OnRewardedSuccess);
#else
            adsManager.ShowAdsVideo(AdsStats.instance.RewardedVideo[1], OnRewardedSuccess);
#endif
        }

        public void HideBanner()
        {
            adsManager.HideBanner();
        }

        public void ShowBanner()
        {
            StartCoroutine(adsManager.ShowBannerWhenInitialized());
        }

        private void OnRewardedSuccess()
        {
            gainCoin += 150;
        }
    }
}