using UnityEditor;
using UnityEngine;

namespace DOTweenUtilities
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(CanvasGroupDOFadeTweener), true)]
    public class CanvasGroupDOFadeTweenerEditor : TweenerBaseEditor
    {
        private protected override void ValidateFromValue()
        {
            serializedFromValue.floatValue = Mathf.Clamp01(serializedFromValue.floatValue);
        }

        private protected override void ValidateEndValue()
        {
            serializedEndValue.floatValue = Mathf.Clamp01(serializedEndValue.floatValue);
        }

        private protected override void SetFromValueLayout()
        {
            EditorGUILayout.Slider(serializedFromValue, 0f, 1f, new GUIContent("From Value"));
        }

        private protected override void SetEndValueLayout()
        {
            EditorGUILayout.Slider(serializedEndValue, 0f, 1f, new GUIContent("End Value"));
        }
    }
}
