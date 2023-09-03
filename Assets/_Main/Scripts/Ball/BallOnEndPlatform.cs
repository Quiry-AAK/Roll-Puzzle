using _Main.Scripts.End;
using UnityEngine;
using DG.Tweening;

namespace _Main.Scripts.Ball
{
    public class BallOnEndPlatform : BallRunningState
    {

        public BallOnEndPlatform(Rigidbody ballRb, Transform modelHolder, BallStatsManager ballStatsManager, BallStateManager ballStateManager) : base(ballRb, modelHolder, ballStatsManager, ballStateManager)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            GameManager.Instance.ChangeCameraToVCam2();
            GameManager.Instance.MakeFogFullyTransparent();
            UIManager.Instance.levelProgressUI.DisappearLevelPanel();
            modelHolder.transform.localRotation = Quaternion.identity;
            modelHolder.transform.DOLocalRotate(360f * Vector3.right, 1.5f, RotateMode.FastBeyond360)
                .SetLoops(-1).SetEase(Ease.Linear).SetId("rotateFast");
            ballStatsManager.ChangeStatsToEndPlatformStats();
        }

        public override void OnExit()
        {
            base.OnExit();
            DOTween.Kill("rotateFast");
        }

        public override void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out EndMultiplier _endMultiplier)) {
                if (_endMultiplier.StopTheBall(ballRb.transform.localScale.x)) {
                    ballStateManager.ChangeTheState(new BallInTubeState(ballRb, 
                        modelHolder, ballStatsManager, ballStateManager, _endMultiplier.GetPath(), 
                        _endMultiplier.endMultiplierPlatform));
                }
            }
        }
    }
}
