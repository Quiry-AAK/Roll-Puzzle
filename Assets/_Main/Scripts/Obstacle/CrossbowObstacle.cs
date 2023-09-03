using UnityEngine;

namespace _Main.Scripts.Obstacle
{
    public class CrossbowObstacle : ObstacleParent
    {

        protected override void OnInput(Vector2 touchDelta)
        {
            if (Mathf.Abs(touchDelta.y) > 0f) {
                var _pos = movingObject.transform.localPosition;
                _pos.z += touchDelta.y * sensitivity * GameManager.Instance.GlobalSensitivity;
                _pos.z = Mathf.Clamp(_pos.z, 0.00674f, 0.02054f);
                movingObject.transform.localPosition = _pos;

                if (Mathf.Abs(_pos.z - 0.02054f) < 0.005f) {
                    LockTheObject();
                }
            }
        }
    }
}
