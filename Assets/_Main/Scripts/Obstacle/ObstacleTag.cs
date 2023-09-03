using UnityEngine;

namespace _Main.Scripts.Obstacle
{
    public class ObstacleTag : MonoBehaviour
    {
        [SerializeField] private float multiplier;

        public float Multiplier => multiplier;
    }
}
