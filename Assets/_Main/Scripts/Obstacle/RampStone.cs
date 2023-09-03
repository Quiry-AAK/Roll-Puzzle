using System;
using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.Obstacle
{
    public class RampStone : MonoBehaviour
    {
        [SerializeField] private Transform button;
        [SerializeField] private RampPlatform rampPlatform;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Outline>()) {
                transform.DOLocalMoveZ(-0.0004f, .5f).SetEase(Ease.InQuad).OnComplete(PressTheButton);
            }
        }

        private void PressTheButton()
        {
            transform.SetParent(button);
            button.transform.DOLocalMoveZ(-0.002077f, .15f).SetEase(Ease.OutSine).OnComplete(StartSpringAnimation);
        }

        private void StartSpringAnimation()
        {
            rampPlatform.StartAnimation();
        }
    }
}
