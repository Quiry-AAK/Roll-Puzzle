using UnityEngine;
using UnityEngine.Events;

namespace EMA.InputEma
{
    public class SwerveInput : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] private float deadZone;
        
        [Header("Touch Delta")]
        public UnityEvent<Vector2> Swerve;
        
        private Vector2 startTouch;
        private Vector2 swipeDelta;
        
        private void Update()
        {
            if(UnityEngine.Input.touchCount > 0)
            {
                Touch touch = UnityEngine.Input.GetTouch(0);
                if(touch.phase == TouchPhase.Began)
                {
                    startTouch = touch.position;
                }
                if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) 
                {
                    swipeDelta = touch.position - startTouch;
                    startTouch = touch.position;

                    swipeDelta /= 100f;
                }
                if(touch.phase == TouchPhase.Ended)
                {
                    swipeDelta = Vector2.zero;
                }

                if (Mathf.Abs(swipeDelta.x) < deadZone)
                    swipeDelta.x = 0f;
                if (Mathf.Abs(swipeDelta.y) < deadZone)
                    swipeDelta.y = 0f;
                
                Swerve?.Invoke(swipeDelta);
            }

            else {
                swipeDelta = Vector2.zero;
                Swerve?.Invoke(swipeDelta);
            }
        }
    }
}
