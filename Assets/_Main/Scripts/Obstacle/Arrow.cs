using System;
using System.Collections;
using UnityEngine;

namespace _Main.Scripts.Obstacle
{
    public class Arrow : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private Rigidbody rb;
        
        public void Shoot()
        {
            rb.AddForce(moveSpeed * -transform.right, ForceMode.Impulse);
            StartCoroutine(GoToPoolArrow());
        }

        private IEnumerator GoToPoolArrow()
        {
            yield return new WaitForSeconds(3f);
            rb.velocity = Vector3.zero;
            rb.isKinematic = false;
            ObjectPools.Instance.ArrowPool.SendObjectToPool(gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<CrossbowTarget>()) {
                rb.velocity = Vector3.zero;
                rb.isKinematic = true;
            }
        }


    }
}
