using System.Collections.Generic;
using EMA.MyShortcuts;
using UnityEditor;
using UnityEngine;

namespace LevelGenerator.Editor.RunnerLevelGeneratorEditor
{
    public class GroundGenerator : UnityEditor.Editor
    {
        private SerializedObject so;
        private SerializedProperty groundPrefabProperty;
        private SerializedProperty distanceBetweenGroundsProperty;
        private SerializedProperty groundParentProperty;
        private SerializedProperty startPlatformProperty;
        private SerializedProperty distanceBetweenStartAndGroundProperty;
        private SerializedProperty endPlatformProperty;
        private SerializedProperty distanceBetweenEndAndGroundProperty;

        public GameObject[] groundPrefabs;
        public Transform groundParent;
        public Vector3 distanceBetweenGrounds;
        
        public GameObject startPlatform;
        public Vector3 distanceBetweenStartAndGround;
        
        public GameObject endPlatform;
        public Vector3 distanceBetweenEndAndGround;

        private ConstantOrRandomBetweenTwoConstant constantOrRandomBetweenTwoConstant;
        
        private void OnEnable()
        {
            if (so == null)
                so = new SerializedObject(this);

            groundPrefabProperty = so.FindProperty("groundPrefabs");
            distanceBetweenGroundsProperty = so.FindProperty("distanceBetweenGrounds");
            groundParentProperty = so.FindProperty("groundParent");
            startPlatformProperty = so.FindProperty("startPlatform");
            distanceBetweenStartAndGroundProperty = so.FindProperty("distanceBetweenStartAndGround");
            endPlatformProperty = so.FindProperty("endPlatform");
            distanceBetweenEndAndGroundProperty = so.FindProperty("distanceBetweenEndAndGround");
            

            constantOrRandomBetweenTwoConstant = CreateInstance<ConstantOrRandomBetweenTwoConstant>();
        }

        public void DrawGroundGUI()
        {
            so.Update();

            using (new GUILayout.VerticalScope(EditorStyles.helpBox)) {

                EditorGUILayout.PropertyField(groundPrefabProperty);

                using (new GUILayout.HorizontalScope()) {
                    EditorGUILayout.PropertyField(distanceBetweenGroundsProperty);
                    if (GUILayout.Button("Detect")) {
                        distanceBetweenGrounds = GetDistanceOfTwoObjects();
                    }
                }

                EditorGUILayout.PropertyField(groundParentProperty);
                constantOrRandomBetweenTwoConstant.DrawGUI("Ground Count");
                
                EditorGUILayout.LabelField("Start Platform", EditorStyles.boldLabel);
                EditorGUILayout.PropertyField(startPlatformProperty);
                using (new GUILayout.HorizontalScope()) {
                    EditorGUILayout.PropertyField(distanceBetweenStartAndGroundProperty);
                    if (GUILayout.Button("Detect")) {
                        distanceBetweenStartAndGround = GetDistanceOfTwoObjects();
                    }
                }
                
                EditorGUILayout.LabelField("End Platform", EditorStyles.boldLabel);
                EditorGUILayout.PropertyField(endPlatformProperty);
                using (new GUILayout.HorizontalScope()) {
                    EditorGUILayout.PropertyField(distanceBetweenEndAndGroundProperty);
                    if (GUILayout.Button("Detect")) {
                        distanceBetweenEndAndGround = GetDistanceOfTwoObjects();
                    }
                }

                if (GUILayout.Button("Generate Ground")) {
                    GenerateGround();
                }
                
                if (GUILayout.Button("Delete Ground")) {
                    DeleteGround();
                }
            }
            
            so.ApplyModifiedProperties();
        }

        public Vector3 GetDistanceOfTwoObjects()
        {
            if (Selection.objects.Length != 2) {
                Debug.LogError("2 object have to be selected to detect distance between them.");
                return Vector3.zero;
            }
            var _object1 = Selection.objects[0] as GameObject;
            var _object2 = Selection.objects[1] as GameObject;

            var _vector3 = _object2.transform.position - _object1.transform.position;
            return _vector3;
        }

        public void GenerateGround()
        {
            var _startPlatform = PrefabUtility.InstantiatePrefab(startPlatform, groundParent) as GameObject;
            _startPlatform.transform.localPosition = Vector3.zero - distanceBetweenStartAndGround;
            for (int i = 0; i < constantOrRandomBetweenTwoConstant.GetValue(); i++) {
                var _obj = PrefabUtility.InstantiatePrefab(MyShortcuts.GetRandomObjectOfList(groundPrefabs)
                    , groundParent) as GameObject;
                var _pos = _obj.transform.localPosition;
                _pos = distanceBetweenGrounds * i;
                _obj.transform.localPosition = _pos;
            }
            var _endPlatform = PrefabUtility.InstantiatePrefab(endPlatform, groundParent) as GameObject;
            _endPlatform.transform.localPosition = distanceBetweenEndAndGround + (distanceBetweenGrounds * (constantOrRandomBetweenTwoConstant.GetValue() - 1));
        }

        public void DeleteGround()
        {
            MyShortcuts.DeleteChildrenOfList(groundParent);
        }

    }
}
