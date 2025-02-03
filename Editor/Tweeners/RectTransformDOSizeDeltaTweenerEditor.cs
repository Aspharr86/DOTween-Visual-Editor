using UnityEditor;
using UnityEngine;

namespace DOTweenUtilities
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(RectTransformDOSizeDeltaTweener), true)]
    public class RectTransformDOSizeDeltaTweenerEditor : TweenerBaseEditor
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
