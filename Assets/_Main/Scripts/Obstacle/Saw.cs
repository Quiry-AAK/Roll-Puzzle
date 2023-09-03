using UnityEngine;

namespace _Main.Scripts.Obstacle
{
    public class Saw : ObstacleParent
    {
        [SerializeField] private Collider[] colliders;
        private float eulerAngleY = 90f;
        protected override void OnInput(Vector2 touchDelta)
        {
            eulerAngleY += sensitivity * GameManager.Instance.GlobalSensitivity * -touchDelta.x;
            eulerAngleY = Mathf.Clamp(eulerAngleY, 0f, 180f);
            var _newRot = new Vector3(-90f, eulerAngleY, 0f);
            movingObject.transform.localRotation = Quaternion.Euler(_newRot);

            if (Mathf.Abs(eulerAngleY - (0f)) < .5f || Mathf.Abs(eulerAngleY - 180f) < .5f) {
                LockTheObject();
                foreach (var _collider in colliders) {
                    Destroy(_collider);
                }
            }
        }
    }
}
