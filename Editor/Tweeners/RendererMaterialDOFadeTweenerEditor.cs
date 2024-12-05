using UnityEditor;
using UnityEngine;

namespace DOTweenUtilities
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(RendererMaterialDOFadeTweener<>), true)]
    public class RendererMaterialDOFadeTweenerEditor : TweenerBaseEditor
    {
        private SerializedProperty serializedShaderPropertyName;

        private protected override void FindSerializedProperties()
        {
            base.FindSerializedProperties();

            serializedShaderPropertyName = serializedObject.FindProperty("shaderPropertyName");
        }

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

        private protected override void SetAdditionalParametersLayout()
        {
            EditorGUILayout.PropertyField(serializedShaderPropertyName, new GUIContent("Shader Property Name", "If empty, tweens the main color of the Material."));
        }
    }
}
