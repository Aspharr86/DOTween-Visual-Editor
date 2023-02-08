#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace DOTweenUtilities
{
    [CustomEditor(typeof(TweenerAnimationPropertyBase<>), true)]
    public class TweenerAnimationPropertyBaseEditor : TweenerEditorBase
    {
        private SerializedProperty serializedTweenedGameObject;

        private SerializedProperty serializedDelay;
        private SerializedProperty serializedIsLoop;

        private SerializedProperty serializedIsFromTween;

        private SerializedProperty serializedFromValue;
        private SerializedProperty serializedEndValue;

        private protected override void FindSerializedProperties()
        {
            base.FindSerializedProperties();

            serializedTweenedGameObject = serializedObject.FindProperty("tweenedGameObject");

            serializedDelay = serializedObject.FindProperty("delay");
            serializedIsLoop = serializedObject.FindProperty("isLoop");

            serializedIsFromTween = serializedObject.FindProperty("isFromTween");

            serializedFromValue = serializedObject.FindProperty("fromValue");
            serializedEndValue = serializedObject.FindProperty("endValue");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            SetInspector((dynamic)target);

            serializedObject.ApplyModifiedProperties();
        }

        private void SetInspector<T>(TweenerAnimationPropertyBase<T> tweener)
        {
            EditorGUILayout.PropertyField(serializedPlayOnAwake, new GUIContent("Play On Awake"));
            EditorGUILayout.PropertyField(serializedOnDisableAction, new GUIContent("On Disable Action"));

            EditorGUILayout.PropertyField(serializedTweenedGameObject, new GUIContent("Tweened GameObject"));

            EditorGUILayout.PropertyField(serializedDuration, new GUIContent("Duration"));
            EditorGUILayout.PropertyField(serializedDelay, new GUIContent("Delay"));
            EditorGUILayout.PropertyField(serializedAnimationCurve, new GUIContent("Animation Curve"));
            EditorGUILayout.PropertyField(serializedIsLoop, new GUIContent("Is Loop"));
            if (tweener.IsLoop) EditorGUILayout.PropertyField(serializedLoopType, new GUIContent("Loop Type"));

            EditorGUILayout.PropertyField(serializedIsFromTween, new GUIContent("Is From Tween"));
            if (tweener.IsFromTween) EditorGUILayout.PropertyField(serializedFromValue, new GUIContent("From Value"));
            EditorGUILayout.PropertyField(serializedEndValue, new GUIContent("End Value"));

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Play"))
            {
                if (!EditorApplication.isPlaying)
                    return;

                tweener.GetTweenedComponent();
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
