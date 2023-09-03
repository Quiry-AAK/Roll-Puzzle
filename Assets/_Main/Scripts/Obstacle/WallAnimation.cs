using UnityEngine;

namespace _Main.Scripts.Obstacle
{
    public class WallAnimation : MonoBehaviour
    {
        public void SetPassiveGameObject()
        {
            Destroy(gameObject, 5f);
        }
    }
}
