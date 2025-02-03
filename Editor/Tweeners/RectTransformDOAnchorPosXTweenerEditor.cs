using UnityEditor;
using UnityEngine;

namespace DOTweenUtilities
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(RectTransformDOAnchorPosXTweener), true)]
    public class RectTransformDOAnchorPosXTweenerEditor : TweenerBaseEditor
    {
        private SerializedProperty serializedSnapping;

        private protected override void FindSerializedProperties()
        {
            base.FindSerializedProperties();

            serializedSnapping = serializedObject.FindProperty("snapping");
        }

        private protected override void SetAdditionalParametersLayout()
        {
            EditorGUILayout.PropertyField(serializedSnapping, new GUIContent("Snapping"));
        }
    }
}
