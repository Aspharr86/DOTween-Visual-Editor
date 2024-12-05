using UnityEditor;
using UnityEngine;

namespace DOTweenUtilities
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(RendererMaterialDOFloatTweener<>), true)]
    public class RendererMaterialDOFloatTweenerEditor : TweenerBaseEditor
    {
        private SerializedProperty serializedShaderPropertyName;

        private protected override void FindSerializedProperties()
        {
            base.FindSerializedProperties();

            serializedShaderPropertyName = serializedObject.FindProperty("shaderPropertyName");
        }

        private protected override void SetAdditionalParametersLayout()
        {
            EditorGUILayout.PropertyField(serializedShaderPropertyName, new GUIContent("Shader Property Name"));
        }
    }
}
