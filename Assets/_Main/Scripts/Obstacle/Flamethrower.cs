using System;
using UnityEngine;

namespace _Main.Scripts.Obstacle
{
    public class Flamethrower : ObstacleParent
    {
        protected override void OnInput(Vector2 touchDelta)
        {
            if (Mathf.Abs(touchDelta.x) > 0) {
                var _pos = movingObject.transform.localPosition;
                _pos.y += -touchDelta.x * sensitivity * GameManager.Instance.GlobalSensitivity;
                _pos.y = Mathf.Clamp(_pos.y, -0.00561f, 0.00483f);
                movingObject.transform.localPosition = _pos;
                
                if(Math.Abs(_pos.y - 0.00483f) < 0.0005f)
                    LockTheObject();
            }
        }
    }
}
