using EMA;
using EMA.UI;
using UnityEngine;

namespace _Main.Scripts.End
{
    public class EndMultiplier : MonoBehaviour
    {
        [SerializeField] private FinalPath finalPath;
        
        [SerializeField] private float scaleIntervalInitial;
        [SerializeField] private float scaleIntervalFinal;

        [SerializeField] private int multiplier;

        public Transform endMultiplierPlatform;

        public bool StopTheBall(float scale)
        {
            if (scale >= scaleIntervalInitial && scale <= scaleIntervalFinal) {
                return true;
            }

            return false;
        }

        public Vector3[] GetPath()
        {
            EmaStatic.FinalMultiplier = multiplier;
            return finalPath.GetPath(multiplier);
        }

    }
}
