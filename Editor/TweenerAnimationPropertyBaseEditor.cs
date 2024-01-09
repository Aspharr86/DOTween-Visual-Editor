using UnityEngine;
using UnityEditor;

namespace DOTweenUtilities
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(TweenerAnimationPropertyBase<,>), true)]
    public class TweenerAnimationPropertyBaseEditor : TweenerEditorBase
    {
        private SerializedProperty serializedTarget;
        public SerializedProperty SerializedTarget => serializedTarget;

        private SerializedProperty serializedDelay;
        private SerializedProperty serializedLoops;

        private SerializedProperty serializedIsFromTween;

        private protected SerializedProperty serializedFromValue;
        private protected SerializedProperty serializedEndValue;

        private protected override void FindSerializedProperties()
        {
            base.FindSerializedProperties();

            serializedTarget = serializedObject.FindProperty("target");

            serializedDelay = serializedObject.FindProperty("delay");
            serializedLoops = serializedObject.FindProperty("loops");

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

        private void SetInspector<T, U>(TweenerAnimationPropertyBase<T, U> tweener) where U : UnityEngine.Object
        {
            EditorGUILayout.PropertyField(serializedPlayOnAwake, new GUIContent("Play On Awake"));
            EditorGUILayout.PropertyField(serializedOnDisableAction, new GUIContent("On Disable Action"));

            EditorGUILayout.PropertyField(serializedTarget, new GUIContent("Target"));

            if (serializedTarget.objectReferenceValue == null)
            {
                EditorGUILayout.HelpBox("Target is not assigned.", MessageType.Warning);
                return;
            }

            EditorGUI.BeginChangeCheck();
            {
                EditorGUILayout.PropertyField(serializedDuration, new GUIContent("Duration"));
            }
            if (EditorGUI.EndChangeCheck())
            {
                serializedDuration.floatValue = Mathf.Max(0f, serializedDuration.floatValue);
            }
            EditorGUI.BeginChangeCheck();
            {
                EditorGUILayout.PropertyField(serializedDelay, new GUIContent("Delay"));
            }
            if (EditorGUI.EndChangeCheck())
            {
                serializedDelay.floatValue = Mathf.Max(0f, serializedDelay.floatValue);
            }
            EditorGUILayout.PropertyField(serializedAnimationCurve, new GUIContent("Animation Curve"));
            EditorGUI.BeginChangeCheck();
            {
                EditorGUILayout.PropertyField(serializedLoops, new GUIContent("Loops", "Set to -1 for infinite loops"));
                if (serializedLoops.intValue == -1 || serializedLoops.intValue > 1)
                {
                    EditorGUILayout.PropertyField(serializedLoopType, new GUIContent("Loop Type"));
                }
            }
            if (EditorGUI.EndChangeCheck())
            {
                serializedLoops.intValue = (serializedLoops.intValue < -1) ? -1 : serializedLoops.intValue;
            }
            EditorGUILayout.PropertyField(serializedID, new GUIContent("ID"));

            EditorGUILayout.PropertyField(serializedIsFromTween, new GUIContent("Is From Tween"));
            if (tweener.IsFromTween)
            {
                ValidateFromValue();
                SetFromValueLayout();
            }
            ValidateEndValue();
            SetEndValueLayout();

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Play"))
            {
                if (!EditorApplication.isPlaying)
                    return;

                for (int i = 0; i < targets.Length; i++)
                {
                    var item = targets[i] as TweenerAnimationPropertyBase<T, U>;

                    item.SetTweener();
                    item.Play();
                }
            }

            if (GUILayout.Button("Stop"))
            {
                if (!EditorApplication.isPlaying)
                    return;

                for (int i = 0; i < targets.Length; i++)
                {
                    var item = targets[i] as TweenerAnimationPropertyBase<T, U>;

                    item.Stop();
                }
            }
            EditorGUILayout.EndHorizontal();
        }

        private protected virtual void ValidateFromValue() { }

        private protected virtual void ValidateEndValue() { }

        private protected virtual void SetFromValueLayout()
            => EditorGUILayout.PropertyField(serializedFromValue, new GUIContent("From Value"));

        private protected virtual void SetEndValueLayout()
            => EditorGUILayout.PropertyField(serializedEndValue, new GUIContent("End Value"));
    }
}
