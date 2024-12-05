using UnityEditor;
using UnityEngine;

namespace DOTweenUtilities
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(RendererMaterialDOColorTweener<>), true)]
    public class RendererMaterialDOColorTweenerEditor : TweenerBaseEditor
    {
        private SerializedProperty serializedShaderPropertyName;

        private protected override void FindSerializedProperties()
        {
            base.FindSerializedProperties();

            serializedShaderPropertyName = serializedObject.FindProperty("shaderPropertyName");
        }

        private protected override void SetAdditionalParametersLayout()
        {
            EditorGUILayout.PropertyField(serializedShaderPropertyName, new GUIContent("Shader Property Name", "If empty, tweens the main color of the Material."));
        }
    }
}
