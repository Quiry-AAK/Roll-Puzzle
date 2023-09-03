using System;
using UnityEditor;
using UnityEngine;

namespace LevelGenerator.Editor.RunnerLevelGeneratorEditor
{
    public class RunnerLevelGenerator : EditorWindow
    {
        private SerializedObject so;
        private GroundGenerator groundGenerator;

        private bool groundFoldOut;

        private RunnerLevelGenerator runnerLevelGenerator;

        #region Menu

        [MenuItem("Level Generator/Runner Level Generator")]
        public static void OpenWindow()
        {
            GetWindow<RunnerLevelGenerator>("Runner Level Generator");
        }

        #endregion

        private void OnEnable()
        {
            so = new SerializedObject(this);

            groundGenerator = CreateInstance<GroundGenerator>();

            groundFoldOut = false;
        }
        private void OnGUI()
        {
            so.Update();
            using (new GUILayout.VerticalScope(EditorStyles.toolbarButton)) {
                groundFoldOut = EditorGUILayout.Foldout(groundFoldOut, "Grounds");
                if (groundFoldOut)
                    groundGenerator.DrawGroundGUI();
            }
            so.ApplyModifiedProperties();
        }
    }
}
