using System;
using UnityEngine;

namespace _Main.Scripts.Ball
{
    public class BallStatsManager : MonoBehaviour
    {
        [Header("Stats")][SerializeField] private BallStats ballNormalStats;
        [SerializeField] private BallStats ballFastStats;
        [SerializeField] private BallStats ballEndPlatformStats;

        private BallStats ballCurrentStats;

        public BallStats BallCurrentStats => ballCurrentStats;

        private void Start()
        {
            ChangeStatsToNormalStats();
        }

        public void ChangeStatsToNormalStats()
        {
            ballCurrentStats = ballNormalStats;
        }

        public void ChangeStatsToFastStats()
        {
            ballCurrentStats = ballFastStats;
        }

        public void ChangeStatsToEndPlatformStats()
        {
            ballCurrentStats = ballEndPlatformStats;
        }
    }
}
