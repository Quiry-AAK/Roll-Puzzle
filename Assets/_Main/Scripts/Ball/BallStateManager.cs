using EMA.PatternClasses;
using UnityEngine;

namespace _Main.Scripts.Ball
{
    public class BallStateManager : StateManager<BallState>
    {
        [SerializeField] private Rigidbody ballRb;
        [SerializeField] private Transform ballModelHolder;

        public BallStatsManager ballStatsManager;

        [Header("Comps")]public BallFX ballFX;

        public BallStateManager(BallState state) : base(state)
        {
        }

        public override void Start()
        {
            state = new BallIdleState(ballRb, ballModelHolder, ballStatsManager, this);
            state.OnEnter();
        }
    }
}
