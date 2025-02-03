using UnityEditor;
using UnityEngine;

namespace DOTweenUtilities
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(TransformDORotateTweener), true)]
    public class TransformDORotateTweenerEditor : TweenerBaseEditor
    {
        private SerializedProperty serializedRotateMode;

        private protected override void FindSerializedProperties()
        {
            base.FindSerializedProperties();

            serializedRotateMode = serializedObject.FindProperty("rotateMode");
        }

        private protected override void SetAdditionalParametersLayout()
        {
            EditorGUILayout.PropertyField(serializedRotateMode, new GUIContent("Rotate Mode"));
        }
    }
}
