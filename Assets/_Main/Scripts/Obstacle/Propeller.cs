using UnityEngine;

namespace _Main.Scripts.Obstacle
{
    public class Propeller : ObstacleParent
    {
        [SerializeField] private GameObject[] endCols;
        [SerializeField] private GameObject propCols;
        
        private SkinnedMeshRenderer meshRenderer;
        

        private void Start()
        {
            meshRenderer = movingObject.GetComponent<SkinnedMeshRenderer>();
        }

        protected override void OnInput(Vector2 touchDelta)
        {
            var _value = meshRenderer.GetBlendShapeWeight(0);
            _value += -touchDelta.x * sensitivity * GameManager.Instance.GlobalSensitivity;
            _value = Mathf.Clamp(_value, 0f, 100f);
            meshRenderer.SetBlendShapeWeight(0, _value);

            if (Mathf.Abs(_value - 100f) < .05f) {
                LockTheObject();

                foreach (var _endCol in endCols) {
                    _endCol.SetActive(true);
                }
                
                propCols.SetActive(false);
            }
        }
    }
}
