using System;
using UnityEngine;

namespace EMA.UI
{
    public abstract class TapToPlay : MonoBehaviour
    {
        private void OnEnable()
        {
            EmaStatic.IsGamePaused = true;
        }

        private void OnDisable()
        {
            EmaStatic.IsGamePaused = false;
        } 

        public void StartTheGame()
        {
            gameObject.SetActive(false);
        }
    }
}
