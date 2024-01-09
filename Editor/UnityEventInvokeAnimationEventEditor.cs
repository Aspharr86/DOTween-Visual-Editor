using UnityEngine;
using UnityEditor;

namespace DOTweenUtilities
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(UnityEventInvokeAnimationEvent), true)]
    public class UnityEventInvokeAnimationEventEditor : Editor
    {
        private SerializedProperty serializedDelay;
        private SerializedProperty serializedID;

        private SerializedProperty serializedTarget;

        private void OnEnable()
        {
            FindSerializedProperties();
        }

        private protected virtual void FindSerializedProperties()
        {
            serializedDelay = serializedObject.FindProperty("delay");
            serializedID = serializedObject.FindProperty("iD");

            serializedTarget = serializedObject.FindProperty("target");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            SetInspector((dynamic)target);

            serializedObject.ApplyModifiedProperties();
        }

        private void SetInspector(UnityEventInvokeAnimationEvent tween)
        {
            EditorGUI.BeginChangeCheck();
            {
                EditorGUILayout.PropertyField(serializedDelay, new GUIContent("Delay"));
            }
            if (EditorGUI.EndChangeCheck())
            {
                serializedDelay.floatValue = Mathf.Max(0f, serializedDelay.floatValue);
            }
            EditorGUILayout.PropertyField(serializedID, new GUIContent("ID"));

            EditorGUILayout.PropertyField(serializedTarget, new GUIContent("Target"));

            if (GUILayout.Button("Play"))
            {
                if (!EditorApplication.isPlaying)
                    return;

                tween.SetTweener();
                tween.Play();
            }
        }
    }
}
