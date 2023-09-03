using EMA.PatternClasses;
using UnityEngine;

namespace _Main.Scripts
{
    public class ObjectPools : MonoSingleton<ObjectPools>
    {
        [SerializeField] private ObjectPool arrowPool;
        [SerializeField] private ObjectPool coinFxPool;

        #region Props

        public ObjectPool ArrowPool => arrowPool;

        public ObjectPool CoinFxPool => coinFxPool;

        #endregion
        
        private void Start()
        {
            arrowPool.CreatePool();
            coinFxPool.CreatePool();
        }
    }
}
