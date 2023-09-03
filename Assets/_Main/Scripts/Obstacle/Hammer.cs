using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.Obstacle
{
    public class Hammer : ObstacleParent
    {
        [SerializeField] private Collider wallCollider;
        [SerializeField] private Animator wallAnimator;
        
        private float eulerAngleX = -90f;
        protected override void OnInput(Vector2 touchDelta)
        {
            eulerAngleX += sensitivity * GameManager.Instance.GlobalSensitivity * touchDelta.y;
            eulerAngleX = Mathf.Clamp(eulerAngleX, -90f, 0f);
            var _newRot = new Vector3(eulerAngleX, -45f, 100f);
            movingObject.transform.localRotation = Quaternion.Euler(_newRot);

            if (eulerAngleX == 0f) {
                LockTheObject();
                StartHammerAnimationFirstPart();
            }
        }

        private void StartHammerAnimationFirstPart()
        {
            movingObject.transform.DOLocalRotate(new Vector3(-125f, -45f, 100f), .6f).SetEase(Ease.InQuad).OnComplete(StartHammerAnimationAndBreakTheWall);
        }

        private void StartHammerAnimationAndBreakTheWall()
        {
            wallCollider.transform.DOLocalMoveY(-20f, 8f).SetEase(Ease.OutCubic).SetDelay(.3f);
            movingObject.transform.DOLocalRotate(new Vector3(-90f, -45f, 100f), 1f).SetEase(Ease.OutCubic);
            wallAnimator.SetTrigger("break");
        }
    }
}
