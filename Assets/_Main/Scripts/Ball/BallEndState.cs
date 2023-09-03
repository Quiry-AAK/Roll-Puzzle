using _Main.Scripts.End;
using DG.Tweening;
using EMA.Utils;
using UnityEngine;

namespace _Main.Scripts.Ball
{
    public class BallEndState : BallState
    {
        private Transform endMultiplierPlatform;
        public BallEndState(Rigidbody ballRb, Transform modelHolder, BallStatsManager ballStatsManager, BallStateManager ballStateManager, Transform endMultiplierPlatform) : base(ballRb, modelHolder, ballStatsManager, ballStateManager)
        {
            this.endMultiplierPlatform = endMultiplierPlatform;
        }

        public override void OnEnter()
        {
            ballRb.transform.DOMoveY(-48.62f, 1f).SetEase(Ease.OutBounce).OnComplete(ScaleEndMultiplierPlatform);
        }

        private void ScaleEndMultiplierPlatform()
        {
            endMultiplierPlatform.transform.DOScale(new Vector3(1.5f,1.5f,1f), .5f)
                .SetEase(Ease.InOutBack).SetLoops(2, LoopType.Yoyo).OnComplete(CallEndConfettiFx);
            
        }

        private void CallEndConfettiFx()
        {
            ballStateManager.ballFX.CallEndConfettiFx();
            UIManager.Instance.endPanel.AppearPanel();
        }
    }
}
