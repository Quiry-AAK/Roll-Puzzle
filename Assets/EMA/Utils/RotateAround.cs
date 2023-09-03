using System;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

namespace EMA.Utils
{
    public class RotateAround : MonoBehaviour
    {
        [SerializeField] private Vector3 rotatePos;
        [SerializeField] private float duration;
        
        [SerializeField] private bool randomizeDuration;
        [SerializeField] private bool randomizePos;

        private int tweenId;
            
        private void Start()
        {
            if (randomizeDuration)
                duration = Random.Range(duration - 1f, duration + 1f);
            if (randomizePos && MyShortcuts.MyShortcuts.GetRandomBoolByChance(.5f))
                rotatePos *= -1f;
            Rotate();
        }
        public void Rotate()
        {
            EmaStatic.DoTweenId++;
            tweenId = EmaStatic.DoTweenId;
            transform.DOLocalRotate( transform.localRotation.eulerAngles + (rotatePos * 360f), duration, 
                RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear).SetId("rotateEMA" + tweenId);
        }

        public void StopRotating()
        {
            DOTween.Kill("rotateEMA" + tweenId);
        }
    }
}
