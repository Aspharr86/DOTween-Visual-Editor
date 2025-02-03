using UnityEditor;
using UnityEngine;

namespace DOTweenUtilities
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(TweenerBase<,>), true)]
    public class TweenerBaseEditor : TweenerEditorBase
    {
        private protected SerializedProperty serializedTargetType;
        private protected SerializedProperty serializedTarget;

        private protected SerializedProperty serializedDelay;
        private protected SerializedProperty serializedLoops;

        private protected SerializedProperty serializedTweenType;

        private protected SerializedProperty serializedFromValue;
        private protected SerializedProperty serializedEndValue;

        private protected override void FindSerializedProperties()
        {
            base.FindSerializedProperties();

            serializedTargetType = serializedObject.FindProperty("targetType");
            serializedTarget = serializedObject.FindProperty("target");

            serializedDelay = serializedObject.FindProperty("delay");
            serializedLoops = serializedObject.FindProperty("loops");

            serializedTweenType = serializedObject.FindProperty("tweenType");

            serializedFromValue = serializedObject.FindProperty("fromValue");
            serializedEndValue = serializedObject.FindProperty("endValue");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            SetInspector((dynamic)target);

            serializedObject.ApplyModifiedProperties();
        }

        private void SetInspector<T, U>(TweenerBase<T, U> tweener) where U : UnityEngine.Object
        {
            EditorGUILayout.PropertyField(serializedTargetType, new GUIContent("Target Type"));
            if (serializedTargetType.enumValueIndex == (int)TargetType.OTHER)
            {
                EditorGUILayout.PropertyField(serializedTarget, new GUIContent("Target"));
                if (serializedTarget.objectReferenceValue == null)
                {
                    EditorGUILayout.HelpBox("Target is not assigned.", MessageType.Warning);
                    return;
                }
            }

            EditorGUILayout.PropertyField(serializedOnEnableBehavior, new GUIContent("On Enable Behavior"));
            EditorGUILayout.PropertyField(serializedOnDisableBehavior, new GUIContent("On Disable Behavior"));

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
            serializedLoops.intValue = (serializedLoops.intValue < -1) ? -1 : serializedLoops.intValue;
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

            EditorGUILayout.PropertyField(serializedTweenType, new GUIContent("Tween Type"));
            if (serializedTweenType.enumValueIndex == (int)TweenType.FROM)
            {
                ValidateFromValue();
                SetFromValueLayout();
            }
            ValidateEndValue();
            SetEndValueLayout();

            SetAdditionalParametersLayout();

            if (GUILayout.Button("Set Tweener"))
            {
                if (!EditorApplication.isPlaying)
                    return;

                for (int i = 0; i < targets.Length; i++)
                {
                    var item = targets[i] as TweenerBase<T, U>;

                    item.SetTweener();
                }
            }

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Play"))
            {
                if (!EditorApplication.isPlaying)
                    return;

                for (int i = 0; i < targets.Length; i++)
                {
                    var item = targets[i] as TweenerBase<T, U>;

                    item.Restart();
                }
            }

            if (GUILayout.Button("Pause"))
            {
                if (!EditorApplication.isPlaying)
                    return;

                for (int i = 0; i < targets.Length; i++)
                {
                    var item = targets[i] as TweenerBase<T, U>;

                    item.Pause();
                }
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Resume"))
            {
                if (!EditorApplication.isPlaying)
                    return;

                for (int i = 0; i < targets.Length; i++)
                {
                    var item = targets[i] as TweenerBase<T, U>;

                    item.Play();
                }
            }

            if (GUILayout.Button("Stop"))
            {
                if (!EditorApplication.isPlaying)
                    return;

                for (int i = 0; i < targets.Length; i++)
                {
                    var item = targets[i] as TweenerBase<T, U>;

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

        private protected virtual void SetAdditionalParametersLayout() { }
    }
}
