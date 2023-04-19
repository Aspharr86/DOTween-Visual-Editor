#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace DOTweenUtilities
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(TweenerBase<>), true)]
    public class TweenerBaseEditor : TweenerEditorBase
    {
        private SerializedProperty serializedDelay;
        private SerializedProperty serializedLoops;

        private protected SerializedProperty serializedFromValue;
        private protected SerializedProperty serializedEndValue;

        private protected override void FindSerializedProperties()
        {
            base.FindSerializedProperties();

            serializedDelay = serializedObject.FindProperty("delay");
            serializedLoops = serializedObject.FindProperty("loops");

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
            EditorGUILayout.PropertyField(serializedDelay, new GUIContent("Delay"));
            EditorGUILayout.PropertyField(serializedAnimationCurve, new GUIContent("Animation Curve"));
            // EditorGUILayout.PropertyField(serializedLoopType, new GUIContent("Loop Type"));
            EditorGUILayout.PropertyField(serializedLoops, new GUIContent("Loops", "Set to -1 for infinite loops"));
            serializedLoops.intValue = (serializedLoops.intValue < -1) ? -1 : serializedLoops.intValue;
            if (serializedLoops.intValue == -1 || serializedLoops.intValue > 1)
            {
                EditorGUILayout.PropertyField(serializedLoopType, new GUIContent("Loop Type"));
            }

            SetFromValueLayout();
            SetEndValueLayout();

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

        private protected virtual void SetFromValueLayout()
            => EditorGUILayout.PropertyField(serializedFromValue, new GUIContent("From Value"));

        private protected virtual void SetEndValueLayout()
            => EditorGUILayout.PropertyField(serializedEndValue, new GUIContent("End Value"));
    }
}
#endif
