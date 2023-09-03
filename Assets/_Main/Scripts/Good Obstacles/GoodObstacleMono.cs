using System;
using _Main.Scripts.Ball;
using _Main.Scripts.Obstacle;
using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.Good_Obstacles
{
    public class GoodObstacleMono : ObstacleParent
    {
        [SerializeField] private Collider makeBiggerTrigger;
        public BallSkin ballSkin;
        public GoodObstacleType goodObstacleType;

        private float eulerAngleX = 0f;

        [SerializeField] private Renderer filterMat;

        [HideInInspector] public bool isObjectLocked = false;
        
        protected override void OnInput(Vector2 touchDelta)
        {
            eulerAngleX += sensitivity * GameManager.Instance.GlobalSensitivity * touchDelta.y;
            eulerAngleX = Mathf.Clamp(eulerAngleX, -75f, 0f);
            var _newRot = new Vector3(eulerAngleX, 0f, 0f);
            movingObject.transform.localRotation = Quaternion.Euler(_newRot);

            if (Math.Abs(eulerAngleX - (-75f)) < 0.5f) {
                LockTheObject();
                RemoveWhiteFilter();
                SetSpecificLockTheObjectSettings();
            }
        }

        protected virtual void SetSpecificLockTheObjectSettings(){}

        private void RemoveWhiteFilter()
        {
            isObjectLocked = true;
            filterMat.material.DOFloat(1f, "_FilterAmount", 1f);
            makeBiggerTrigger.enabled = true;
        }
    }
}
