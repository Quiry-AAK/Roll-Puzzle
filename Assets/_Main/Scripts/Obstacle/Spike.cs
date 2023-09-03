using System;
using UnityEngine;

namespace _Main.Scripts.Obstacle
{
    public class Spike : ObstacleParent
    {
        private float eulerAngleZ = 0f;
        protected override void OnInput(Vector2 touchDelta)
        {
            eulerAngleZ += sensitivity * GameManager.Instance.GlobalSensitivity * -touchDelta.x;
            eulerAngleZ = Mathf.Clamp(eulerAngleZ, -90f, 90f);
            var _newRot = new Vector3(0f, 0f, eulerAngleZ);
            movingObject.transform.localRotation = Quaternion.Euler(_newRot);

            if (Math.Abs(eulerAngleZ - (-90f)) < .5f || Math.Abs(eulerAngleZ - 90f) < .5f) {
                LockTheObject();
            }
        }
    }
}
