using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.Ball
{
    public class BallJumpingState : BallState
    {
        private Vector3 jumpPos;

        public BallJumpingState(Rigidbody ballRb, Transform modelHolder, BallStatsManager ballStatsManager, BallStateManager ballStateManager, Vector3 jumpPos) : base(ballRb, modelHolder, ballStatsManager, ballStateManager)
        {
            this.jumpPos = jumpPos;
        }

        public override void OnEnter()
        {
            modelHolder.transform.localRotation = Quaternion.identity;
            modelHolder.transform.DOLocalRotate(360f * Vector3.right, 5f, RotateMode.FastBeyond360)
                .SetLoops(-1).SetEase(Ease.Linear).SetId("rotateForJumping");

            ballRb.transform.DOJump(jumpPos, 3f, 1, 1.5f).
                OnComplete(ChangeStateToBallFastState).SetEase(Ease.Linear);
            DOTween.To(() => Time.timeScale, x => Time.timeScale = x, .3f, 1.3f).SetId("timeScaler");
            GameManager.Instance.ChangeCameraToVCam2();
            
            GameManager.Instance.MakeFogFullyTransparent();
            
            
        }

        private void ChangeStateToBallFastState()
        {
            ballStateManager.ChangeTheState(new BallFastState(ballRb, modelHolder, ballStatsManager, ballStateManager));
        }


        public override void OnExit()
        {
            DOTween.Kill("rotateForJumping");
            DOTween.Kill("timeScaler");
        }
    }
}
