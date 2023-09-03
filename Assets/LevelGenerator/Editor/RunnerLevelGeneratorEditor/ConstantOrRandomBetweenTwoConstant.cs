using System;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LevelGenerator.Editor.RunnerLevelGeneratorEditor
{
    public class ConstantOrRandomBetweenTwoConstant : EditorWindow
    {
        private SerializedObject so;
        private SerializedProperty constantProperty;
        private SerializedProperty rnd1Property;
        private SerializedProperty rnd2Property;
        private SerializedProperty optionsProperty;
        
        public int constant = 0;
        public int rnd1 = 0, rnd2 = 0;
        [SerializeField] private ConstantOrRandomBetweenTwoConstantOptions options = 
            ConstantOrRandomBetweenTwoConstantOptions.Constant;

        private void OnEnable()
        {
            so = new SerializedObject(this);
            constantProperty = so.FindProperty("constant");
            rnd1Property = so.FindProperty("rnd1");
            rnd2Property = so.FindProperty("rnd2");
            optionsProperty = so.FindProperty("options");
        }

        public int GetValue()
        {
            switch (optionsProperty.enumValueIndex) {
                case 0:
                    return constant;
                case 1:
                    return Random.Range(rnd1, rnd2);
            }
            Debug.LogError("Enum index error");
            return 0;
        }
        

        public void DrawGUI(string label)
        {
            so.Update();
            EditorGUILayout.LabelField(label, EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(optionsProperty);
            switch (optionsProperty.enumValueIndex) {
                case 0:
                    EditorGUILayout.PropertyField(constantProperty);
                    break;
                case 1:
                    EditorGUILayout.PropertyField(rnd1Property);
                    EditorGUILayout.PropertyField(rnd2Property);
                    break;
            }
            so.ApplyModifiedProperties();
        }
    }
    
    enum ConstantOrRandomBetweenTwoConstantOptions{
        Constant,
        RandomBetweenTwoConstant,
    }
}
