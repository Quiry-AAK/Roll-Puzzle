using System;
using _Main.Scripts.Ball;
using _Main.Scripts.End;
using EMA.PatternClasses;
using EMA.UI;
using EMA.Utils;
using UnityEngine;

namespace _Main.Scripts
{
    public class UIManager : MonoSingleton<UIManager>
    {
        public UICoinGoToIcon uiCoinGoToIcon;
        public StraightLevelSliderFiller straightLevelSliderFiller;


        [Header("Panels")] public EndPanel endPanel;
        public LevelProgressUI levelProgressUI;

        private void Start()
        {
            straightLevelSliderFiller.mainBall = FindObjectOfType<BallStateManager>().transform;
            straightLevelSliderFiller.endPlatform = FindObjectOfType<EndPlatformTag>().transform;
            
            
        }
    }
}
