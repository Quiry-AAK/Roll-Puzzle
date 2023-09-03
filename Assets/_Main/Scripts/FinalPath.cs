using System;
using System.Collections.Generic;
using System.Linq;
using EMA.Curve;
using UnityEngine;

namespace _Main.Scripts
{
    public class FinalPath : MonoBehaviour
    {
        public Transform[] bezierWayPoints;
        public Transform[] bezierMidPoint;
        
        public Vector3[] GetPath(int multiplier)
        {
            var _offset = GetOffset(multiplier);

            List<Vector3> pathList = new List<Vector3>();
            for (int i = 0; i < bezierWayPoints.Length - 1; i++) {
                var _vector3s = Bezier.Quadratic(bezierWayPoints[i].position, bezierMidPoint[i].position,
                    bezierWayPoints[i + 1].position, 20);
                pathList = pathList.ToArray().Union(_vector3s).ToList();
            }

            for (int i = 0; i < pathList.Count; i++) {
                var _vector = pathList[i];
                _vector.z += _offset;
                pathList[i] = _vector;
            }
            
            return pathList.ToArray();
        }

        public float GetOffset(int multiplier)
        {
            switch (multiplier) {
                case 2:
                    return 0f;
                case 4:
                    return 3.00423f;
                case 8:
                    return 6.00846f;
                case 16:
                    return 9.01269f;
                case 32:
                    return 12.01692f;
            }
            return 0f;
        }
        
    }
}
