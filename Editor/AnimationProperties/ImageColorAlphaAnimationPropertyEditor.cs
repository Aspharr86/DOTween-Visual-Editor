#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace DOTweenUtilities
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(ImageColorAlphaAnimationProperty), true)]
    public class ImageColorAlphaAnimationPropertyEditor : TweenerAnimationPropertyBaseEditor
    {
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
#endif
