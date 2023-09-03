using System;
using _Main.Scripts.Ball;
using Cinemachine;
using UnityEngine;

namespace _Main.Scripts.Obstacle
{
    public abstract class ObstacleParent : MonoBehaviour
    {
        [SerializeField] protected Transform movingObject;
        [SerializeField] private Renderer[] renderers;
        [SerializeField] private Renderer[] outlineRenderers;

        [SerializeField] protected float sensitivity;

        private void OnTriggerEnter(Collider other)
        {
            if (other.attachedRigidbody.gameObject.GetComponent<BallStateManager>()) {
                GameManager.Instance.SwerveInput.Swerve.RemoveAllListeners();
                GameManager.Instance.SwerveInput.Swerve.AddListener(OnInput);

                foreach (var _outlineRenderer in outlineRenderers) {
                    foreach (var _material in _outlineRenderer.materials) {
                        _material.SetFloat("_OutlineWidth", 5f);
                    }
                }


                foreach (var _renderer in renderers) {
                    foreach (var _rendererMaterial in _renderer.materials) {
                        _rendererMaterial.SetFloat("_highlight", 1);
                    }
                }
            }
        }

        protected abstract void OnInput(Vector2 touchDelta);
        protected void LockTheObject()
        {
            GameManager.Instance.SwerveInput.Swerve.RemoveAllListeners();
            
            foreach (var _outlineRenderer in outlineRenderers) {
                foreach (var _material in _outlineRenderer.materials) {
                    _material.SetFloat("_OutlineWidth", 0f);
                }
            }
            
            foreach (var _renderer in renderers) {
                foreach (var _rendererMaterial in _renderer.materials) {
                    _rendererMaterial.SetFloat("_highlight", 0);
                }
            }
        }
    }
}
