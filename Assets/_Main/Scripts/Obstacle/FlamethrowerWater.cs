using System;
using UnityEngine;

namespace _Main.Scripts.Obstacle
{
    public class FlamethrowerWater : ObstacleParent
    {
        private float eulerAngleY = 0f;
        protected override void OnInput(Vector2 touchDelta)
        {
            eulerAngleY += sensitivity * GameManager.Instance.GlobalSensitivity * -touchDelta.y;
            eulerAngleY = Mathf.Clamp(eulerAngleY, 0f, 90f);
            var _newRot = eulerAngleY * Vector3.up;
            movingObject.transform.localRotation = Quaternion.Euler(_newRot);

            if (Math.Abs(eulerAngleY - 90f) < .5f) {
                LockTheObject();
            }
        }
    }
}
