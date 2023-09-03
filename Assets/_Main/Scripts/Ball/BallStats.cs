using UnityEngine;

namespace _Main.Scripts.Ball
{
    [System.Serializable]
    public struct BallStats
    {
        [SerializeField] private float moveSpeed;


        public float MoveSpeed => moveSpeed;
    }
}
