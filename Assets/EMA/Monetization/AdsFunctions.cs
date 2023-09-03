using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using EMA;

namespace EMA
{
    public class AdsFunctions : IUnityAdsListener
    {
        public void OnUnityAdsReady(string placementId)
        {
            Debug.Log("Ads are ready");
        }

        public void OnUnityAdsDidError(string message)
        {
            Debug.Log("Error" + message);
        }

        public void OnUnityAdsDidStart(string placementId)
        {
            Debug.Log("Video started");
        }

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
#if UNITY_IOS
            if (placementId == AdsStats.instance.RewardedVideo[0] && showResult == ShowResult.Finished)
            {
                Debug.Log("ios player should be rewarded"); adsStats.OnRewardedSuccess.Invoke();
            }
#else
            if (placementId == AdsStats.instance.RewardedVideo[1] && showResult == ShowResult.Finished)
            {
                Debug.Log("Android player should be rewarded"); AdsStats.instance.OnRewardedSuccess.Invoke();
            }
#endif
        }
    }
}

