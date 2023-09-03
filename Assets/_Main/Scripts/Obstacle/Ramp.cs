using UnityEngine;

namespace _Main.Scripts.Obstacle
{
    public class Ramp : ObstacleParent
    {

        protected override void OnInput(Vector2 touchDelta)
        {
            if (Mathf.Abs(touchDelta.x) > 0f) {
                var _pos = movingObject.transform.localPosition;
                _pos.y += -touchDelta.x * sensitivity * GameManager.Instance.GlobalSensitivity;
                _pos.y = Mathf.Clamp(_pos.y, -0.00307806f, 0.000692f);
                movingObject.transform.localPosition = _pos;

                if (Mathf.Abs(_pos.y - 0.000692f) < 0.0005f) {
                    LockTheObject();
                }
            }
        }
    }
}
