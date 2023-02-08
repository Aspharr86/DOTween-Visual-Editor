#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace DOTweenUtilities
{
    [CustomEditor(typeof(TweenerAnimationEventBase<>), true)]
    public class TweenerAnimationEventBaseEditor : Editor
    {
        private SerializedProperty serializedTweenedGameObject;

        private SerializedProperty serializedDelay;

        private SerializedProperty serializedParameter;

        private void OnEnable()
        {
            FindSerializedProperties();
        }

        private protected virtual void FindSerializedProperties()
        {
            serializedTweenedGameObject = serializedObject.FindProperty("tweenedGameObject");

            serializedDelay = serializedObject.FindProperty("delay");

            serializedParameter = serializedObject.FindProperty("parameter");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            SetInspector((dynamic)target);

            serializedObject.ApplyModifiedProperties();
        }

        private void SetInspector<T>(TweenerAnimationEventBase<T> tween)
        {
            EditorGUILayout.PropertyField(serializedTweenedGameObject, new GUIContent("Tweened GameObject"));

            EditorGUILayout.PropertyField(serializedDelay, new GUIContent("Delay"));

            EditorGUILayout.PropertyField(serializedParameter, new GUIContent("Parameter"));

            if (GUILayout.Button("Play"))
            {
                if (!EditorApplication.isPlaying)
                    return;

                tween.GetTweenedComponent();
                tween.SetTweener();
                tween.Play();
            }
        }
    }
}
#endif
