using System;
using UnityEngine;

namespace _Main.Scripts.Obstacle
{
    public class Crossbow : MonoBehaviour
    {
        [SerializeField] private float attackSpeed;

        private float attackSpeedController = 0f;
        private void FixedUpdate()
        {
            if (Time.time > attackSpeedController) {
                attackSpeedController = Time.time + attackSpeed;
                var _obj = ObjectPools.Instance.ArrowPool.GetPooledObject();
                _obj.transform.SetParent(transform);
                _obj.transform.localScale = Vector3.one;
                _obj.transform.localPosition = new Vector3(0.001f, 0f, .0001f);
                _obj.transform.localRotation = Quaternion.identity;
                _obj.GetComponent<Arrow>().Shoot();
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(transform.position, transform.position + -transform.right * 10f);
        }
    }
}
