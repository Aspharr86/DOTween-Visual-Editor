using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

namespace DOTweenUtilities
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(SliderDOValueProperty), true)]
    public class SliderDOValuePropertyEditor : TweenerAnimationPropertyBaseEditor
    {
        private Slider slider;
        public Slider Slider => slider ?? (slider = (target as SliderDOValueTweener).GetComponent<Slider>());

        private protected override void ValidateFromValue()
        {
            serializedFromValue.floatValue = Mathf.Clamp(serializedFromValue.floatValue, Slider.minValue, Slider.maxValue);
        }

        private protected override void ValidateEndValue()
        {
            serializedEndValue.floatValue = Mathf.Clamp(serializedEndValue.floatValue, Slider.minValue, Slider.maxValue);
        }

        private protected override void SetFromValueLayout()
        {
            EditorGUILayout.Slider(serializedFromValue, Slider.minValue, Slider.maxValue, new GUIContent("From Value"));
        }

        private protected override void SetEndValueLayout()
        {
            EditorGUILayout.Slider(serializedEndValue, Slider.minValue, Slider.maxValue, new GUIContent("End Value"));
        }
    }
}
