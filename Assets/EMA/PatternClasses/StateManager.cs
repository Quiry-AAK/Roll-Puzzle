using System;
using UnityEngine;

namespace EMA.PatternClasses
{
    public abstract class StateManager<T1> : MonoBehaviour where T1 : IState
    {
        public T1 state;

        public StateManager(T1 state)
        {
            this.state = state;
        }

        public abstract void Start();

        private void Update()
        {
            state.OnUpdate();
        }
        private void FixedUpdate()
        {
            state.OnFixedUpdate();
        }

        private void OnCollisionEnter(Collision other)
        {
            state.OnCollisionEnter(other);
        }

        private void OnCollisionStay(Collision other)
        {
            state.OnCollisionStay(other);
        }

        private void OnCollisionExit(Collision other)
        {
            state.OnCollisionExit(other);
        }

        private void OnTriggerEnter(Collider other)
        {
            state.OnTriggerEnter(other);
        }

        private void OnTriggerStay(Collider other)
        {
            state.OnTriggerStay(other);
        }

        private void OnTriggerExit(Collider other)
        {
            state.OnTriggerExit(other);
        }

        private void OnParticleCollision(GameObject other)
        {
            state.OnParticleCollision(other);
        }

        public void ChangeTheState(T1 newState) 
        {
            state.OnExit();
            state = newState;
            state.OnEnter();
        }
    }
}
