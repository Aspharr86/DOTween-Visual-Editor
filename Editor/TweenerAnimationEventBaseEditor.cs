using UnityEngine;
using UnityEditor;

namespace DOTweenUtilities
{
    [CustomEditor(typeof(TweenerAnimationEventBase<,>), true)]
    public class TweenerAnimationEventBaseEditor : Editor
    {
        private SerializedProperty serializedTarget;

        private SerializedProperty serializedDelay;
        private SerializedProperty serializedID;

        private SerializedProperty serializedParameter;

        private void OnEnable()
        {
            FindSerializedProperties();
        }

        private protected virtual void FindSerializedProperties()
        {
            serializedTarget = serializedObject.FindProperty("target");

            serializedDelay = serializedObject.FindProperty("delay");
            serializedID = serializedObject.FindProperty("iD");

            serializedParameter = serializedObject.FindProperty("parameter");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            SetInspector((dynamic)target);

            serializedObject.ApplyModifiedProperties();
        }

        private void SetInspector<T, U>(TweenerAnimationEventBase<T, U> tween) where U : UnityEngine.Object
        {
            EditorGUILayout.PropertyField(serializedTarget, new GUIContent("Target"));

            EditorGUI.BeginChangeCheck();
            {
                EditorGUILayout.PropertyField(serializedDelay, new GUIContent("Delay"));
            }
            if (EditorGUI.EndChangeCheck())
            {
                serializedDelay.floatValue = Mathf.Max(0f, serializedDelay.floatValue);
            }
            EditorGUILayout.PropertyField(serializedID, new GUIContent("ID"));

            EditorGUILayout.PropertyField(serializedParameter, new GUIContent("Parameter"));

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
