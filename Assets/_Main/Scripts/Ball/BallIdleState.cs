using EMA;
using EMA.UI;
using UnityEngine;

namespace _Main.Scripts.Ball
{
    public class BallIdleState : BallState
    {
        public BallIdleState(Rigidbody ballRb, Transform modelHolder, BallStatsManager ballStatsManager, BallStateManager ballStateManager) : base(ballRb, modelHolder, ballStatsManager, ballStateManager)
        {
        }

        public override void OnUpdate()
        {
            if(!EmaStatic.IsGamePaused)
                ballStateManager.ChangeTheState(new BallRunningState(ballRb, modelHolder, ballStatsManager, ballStateManager));
        }
    }
}
