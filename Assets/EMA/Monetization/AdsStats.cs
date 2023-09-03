using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EMA
{
    public class AdsStats : MonoBehaviour
    {
        public static AdsStats instance { get; set; }

        private void Awake()
        {
            instance = this;
        }
        [SerializeField] private string[] gameId;
        [SerializeField] private string[] video ;
        [SerializeField] private string[] rewardedVideo;
        [SerializeField] private string[] banner;
        [SerializeField] private bool testMode = true;
        [SerializeField] private Action onRewardedSuccess;
        public bool TestMode { get => testMode; set => testMode = value; }
        public string[] GameId { get => gameId; set => gameId = value; }
        public string[] Video { get => video; set => video = value; }
        public string[] RewardedVideo { get => rewardedVideo; set => rewardedVideo = value; }
        public string[] Banner { get => banner; set => banner = value; }
        public Action OnRewardedSuccess { get => onRewardedSuccess; set => onRewardedSuccess = value; }
    }

}
