using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace _Main.Scripts.Obstacle
{
    public class RampPlatform : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        public BoxCollider col;

        [SerializeField] private Transform jumpPos;
        
        [HideInInspector]public UnityEvent<Vector3> jumpEvent;

        private bool jumpEventExecutable = false;

        public void StartAnimation()
        {
            animator.SetTrigger("jump");
        }

        public void MakeColliderSmaller()
        {
            DOTween.Complete("col");
            DOTween.To(() => col.size, x => col.size = x, 
                new Vector3(col.size.x, col.size.y, 0.004f), .3f).SetEase(Ease.OutQuad).SetId("col")
                .SetLoops(2, LoopType.Yoyo);
            //col.size = new Vector3(col.size.x, col.size.y, 0.007f);
        }
        public void MakeColliderBig()
        {
            DOTween.Complete("col");
            DOTween.To(() => col.size, x => col.size = x, 
                new Vector3(col.size.x, col.size.y, 0.02f), .5f).
                SetEase(Ease.InOutBack).SetId("col").SetLoops(2, LoopType.Yoyo);
            //col.size = new Vector3(col.size.x, col.size.y, 0.01343323f);
        }

        public void SetJumpEventExecutable()
        {
            jumpEventExecutable = !jumpEventExecutable;
        }

        private void ExecuteJumpEvent()
        {
            jumpEvent?.Invoke(jumpPos.position);
            jumpEvent?.RemoveAllListeners();
        }

        private void Update()
        {
            if(jumpEventExecutable)
                ExecuteJumpEvent();
        }
    }
}
