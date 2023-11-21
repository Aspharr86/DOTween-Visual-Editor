using UnityEngine;
using UnityEditor;

namespace DOTweenUtilities
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(ScrollRectDONormalizedPosProperty), true)]
    public class ScrollRectDONormalizedPosPropertyEditor : TweenerAnimationPropertyBaseEditor
    {
        private protected override void ValidateFromValue()
        {
            serializedFromValue.vector2Value = new Vector2(Mathf.Clamp01(serializedFromValue.vector2Value.x), Mathf.Clamp01(serializedFromValue.vector2Value.y));
        }

        private protected override void ValidateEndValue()
        {
            serializedEndValue.vector2Value = new Vector2(Mathf.Clamp01(serializedEndValue.vector2Value.x), Mathf.Clamp01(serializedEndValue.vector2Value.y));
        }

        private protected override void SetFromValueLayout()
        {
            EditorGUILayout.PropertyField(serializedFromValue, new GUIContent("From Value"));
        }

        private protected override void SetEndValueLayout()
        {
            EditorGUILayout.PropertyField(serializedEndValue, new GUIContent("End Value"));
        }
    }
}
