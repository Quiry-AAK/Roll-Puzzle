using UnityEngine;

namespace EMA.PatternClasses
{
    public abstract class MonoSingleton<T> : MonoBehaviour
    {
        public static T Instance { get; private set; }
        
        private void Awake()
        {
            Instance = GetComponent<T>();
        }
    }
}