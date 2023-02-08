#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace DOTweenUtilities
{
    [CustomEditor(typeof(UnityEventInvokeAnimationEvent), true)]
    public class UnityEventInvokeAnimationEventEditor : Editor
    {
        private SerializedProperty serializedDelay;

        private SerializedProperty serializedUnityEvent;

        private void OnEnable()
        {
            FindSerializedProperties();
        }

        private protected virtual void FindSerializedProperties()
        {
            serializedDelay = serializedObject.FindProperty("delay");

            serializedUnityEvent = serializedObject.FindProperty("unityEvent");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            SetInspector((dynamic)target);

            serializedObject.ApplyModifiedProperties();
        }

        private void SetInspector(UnityEventInvokeAnimationEvent tween)
        {
            EditorGUILayout.PropertyField(serializedDelay, new GUIContent("Delay"));

            EditorGUILayout.PropertyField(serializedUnityEvent, new GUIContent("UnityEvent"));

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
#endif
