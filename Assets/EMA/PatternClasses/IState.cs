using UnityEngine;

namespace EMA.PatternClasses
{
    public interface IState
    {
        void OnEnter();
        void OnUpdate();
        void OnFixedUpdate();
        void OnExit();
        void OnCollisionEnter(Collision other);
        void OnCollisionStay(Collision other);
        void OnCollisionExit(Collision other);
        void OnTriggerEnter(Collider other);
        void OnTriggerStay(Collider other);
        void OnTriggerExit(Collider other);
        void OnParticleCollision(GameObject other);
    }
}
