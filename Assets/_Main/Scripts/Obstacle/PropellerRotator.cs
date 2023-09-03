using DG.Tweening;
using EMA.Utils;
using UnityEngine;

namespace _Main.Scripts.Obstacle
{
    public class PropellerRotator : MonoBehaviour
    {
        [SerializeField] private RotateAround rotateAround;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PropellerLockCollider>()) {
                rotateAround.StopRotating();
                transform.DOLocalRotateQuaternion(Quaternion.Euler(GetClosestAngle(), 90f, -90f), .3f).SetEase(Ease.OutBounce);
            }
        }

        private float GetClosestAngle()
        {
            var _value = transform.localEulerAngles.x;
            _value = Mathf.CeilToInt(_value / 90);
            _value = -30 + (_value * 90);
            return _value;
        }
    }
}
