using UnityEngine;

namespace _Main.Scripts.Good_Obstacles
{
    public class Pipe : GoodObstacleMono
    {
        [SerializeField] private ParticleSystem pipeParticleSystem;
        [SerializeField] private Color particleStartColor;
        [SerializeField] private Color particleEndColor;

        protected override void SetSpecificLockTheObjectSettings()
        {
            var _particleSystemMain = pipeParticleSystem.main;
            _particleSystemMain.startColor =  new ParticleSystem.MinMaxGradient(particleStartColor, particleEndColor);
        }
    }
}
