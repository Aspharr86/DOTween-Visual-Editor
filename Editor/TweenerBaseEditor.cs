#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace DOTweenUtilities
{
    [CustomEditor(typeof(TweenerBase<>), true)]
    public class TweenerBaseEditor : TweenerEditorBase
    {
        private SerializedProperty serializedFromValue;
        private SerializedProperty serializedEndValue;

        private protected override void FindSerializedProperties()
        {
            base.FindSerializedProperties();

            serializedFromValue = serializedObject.FindProperty("fromValue");
            serializedEndValue = serializedObject.FindProperty("endValue");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            SetInspector((dynamic)target);

            serializedObject.ApplyModifiedProperties();
        }

        private void SetInspector<T>(TweenerBase<T> tweener)
        {
            EditorGUILayout.PropertyField(serializedPlayOnAwake, new GUIContent("Play On Awake"));
            EditorGUILayout.PropertyField(serializedOnDisableAction, new GUIContent("On Disable Action"));

            EditorGUILayout.PropertyField(serializedDuration, new GUIContent("Duration"));
            EditorGUILayout.PropertyField(serializedAnimationCurve, new GUIContent("Animation Curve"));
            EditorGUILayout.PropertyField(serializedLoopType, new GUIContent("Loop Type"));

            EditorGUILayout.PropertyField(serializedFromValue, new GUIContent("From Value"));
            EditorGUILayout.PropertyField(serializedEndValue, new GUIContent("End Value"));

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Play"))
            {
                if (!EditorApplication.isPlaying)
                    return;

                tweener.SetTweener();
                tweener.Play();
            }

            if (GUILayout.Button("Stop"))
            {
                if (!EditorApplication.isPlaying)
                    return;

                tweener.Stop();
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}
#endif
