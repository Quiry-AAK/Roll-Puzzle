using UnityEngine;

namespace _Main.Scripts.Obstacle
{
    public class Pipeline : ObstacleParent
    {
        [SerializeField] private ParticleSystem water;
        protected override void OnInput(Vector2 touchDelta)
        {
            if (Mathf.Abs(touchDelta.x) > 0f) {
                var _pos = movingObject.transform.localPosition;
                _pos.x += touchDelta.x * sensitivity * GameManager.Instance.GlobalSensitivity;
                _pos.x = Mathf.Clamp(_pos.x, -0.00843f, -0.00234f);
                movingObject.transform.localPosition = _pos;

                if (Mathf.Abs(_pos.x + 0.00843f) < 0.0005f) {
                    LockTheObject();
                    var _collisionModule = water.collision;
                    _collisionModule.sendCollisionMessages = false;
                }
            }
        }
    }
}
