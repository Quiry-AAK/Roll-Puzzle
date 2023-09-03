using DG.Tweening;
using PathCreation;
using PathCreation.Examples;
using UnityEngine;

namespace _Main.Scripts.Ball
{
    public class BallInTubeState : BallState
    {
        private Vector3[] path;

        private Transform lastPlatform;
        public override void OnEnter()
        {
            ballRb.velocity = Vector3.zero;
            ballRb.transform.DOPath(path, 6f).SetEase(Ease.InSine).OnComplete(ChangeState);
            ballRb.transform.rotation = Quaternion.identity;
            ballRb.useGravity = false;
            GameManager.Instance.ChangeCameraToVCam3();
            GameManager.Instance.ChangeCameraToVCam4WDelay();
            ballStateManager.ballFX.SetBallEndFxActiveness(true);
        }

        private void ChangeState()
        {
            ballStateManager.ChangeTheState(new BallEndState(ballRb, modelHolder, ballStatsManager, ballStateManager, lastPlatform));
        }

        public override void OnUpdate()
        {
            modelHolder.transform.localRotation = Quaternion.Euler(360f*Mathf.Sin(Time.time), 360f*Mathf.Cos(Time.time), 360f*Mathf.Sin(Time.time));
        }
        
        public BallInTubeState(Rigidbody ballRb, Transform modelHolder, BallStatsManager ballStatsManager, BallStateManager ballStateManager, Vector3[] path, Transform lastPlatform) : base(ballRb, modelHolder, ballStatsManager, ballStateManager)
        {
            this.path = path;
            this.lastPlatform = lastPlatform;
        }
    }
}
