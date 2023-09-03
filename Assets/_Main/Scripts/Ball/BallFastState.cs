using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.Ball
{
    public class BallFastState : BallRunningState
    {
        public BallFastState(Rigidbody ballRb, Transform modelHolder, BallStatsManager ballStatsManager, BallStateManager ballStateManager) : base(ballRb, modelHolder, ballStatsManager, ballStateManager)
        {
        }

        public override void OnEnter()
        {
            modelHolder.transform.localRotation = Quaternion.identity;
            modelHolder.transform.DOLocalRotate(360f * Vector3.right, 1f, RotateMode.FastBeyond360)
                .SetLoops(-1).SetEase(Ease.Linear).SetId("rotateFast");
            
            DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 1f, .3f)
                .SetId("timeScalerForFast");
            
            ballStateManager.ballFX.SetBallJumpFxActiveness(true);
            ballStatsManager.ChangeStatsToFastStats();
            
            GameManager.Instance.ShakeCamera();
        }

        public override void OnExit()
        {
            ballStateManager.ballFX.SetBallJumpFxActiveness(false);
            GameManager.Instance.ChangeCameraToVCam1();
            
            DOTween.Kill("rotateFast");
            DOTween.Kill("timeScalerForFast");
            ballStatsManager.ChangeStatsToNormalStats();
        }

        public override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            if (other.GetComponent<RampEndPool>()) {
                ballStateManager.ChangeTheState(new BallRunningState(ballRb, modelHolder, ballStatsManager, ballStateManager));
            }
        }
    }
}
