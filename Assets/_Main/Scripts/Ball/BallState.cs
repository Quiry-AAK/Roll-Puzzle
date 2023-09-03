using EMA.PatternClasses;
using UnityEngine;

namespace _Main.Scripts.Ball
{
    public class BallState : StateParent
    {
        protected BallStateManager ballStateManager;
        protected Rigidbody ballRb;
        protected Transform modelHolder;
        protected BallStatsManager ballStatsManager;
        
        
        public BallState(Rigidbody ballRb, Transform modelHolder, BallStatsManager ballStatsManager, BallStateManager ballStateManager)
        {
            this.ballRb = ballRb;
            this.modelHolder = modelHolder;
            this.ballStatsManager = ballStatsManager;
            this.ballStateManager = ballStateManager;
        }
    }
}
