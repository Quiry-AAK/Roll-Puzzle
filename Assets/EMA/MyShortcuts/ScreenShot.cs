using System;
using UnityEngine;

namespace EMA.MyShortcuts
{
    public class ScreenShot : MonoBehaviour
    {
        public float delay = 5f;

        private float delayCheck = 0f;
        public void Update()
        {
            if (Time.time > delayCheck) {
                delayCheck = delay + Time.time;
                Debug.Log("a");
                MyShortcuts.GetScreenShot();
            }
        }
    }
}
