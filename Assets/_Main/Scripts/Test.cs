using System;
using UnityEngine;

namespace _Main.Scripts
{
    public class Test : MonoBehaviour
    {
        private void Update(){
            var _x = transform.localRotation.eulerAngles.x + Time.deltaTime;
            transform.localRotation = Quaternion.Euler(_x, 0f ,5);
        }
    }
}
