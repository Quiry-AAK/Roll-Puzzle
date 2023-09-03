using UnityEngine;

namespace EMA.Samples.Runner.Scripts
{
    public class NonStopRunningSampleInput : MonoBehaviour
    {
        [SerializeField] private Rigidbody tr;
        public void Update()
        {
            Movement.NonStopRunning(tr, 1f);
        }
    }
}
