#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DOTweenUtilities
{
    [CustomEditor(typeof(TweenerAnimator))]
    public class TweenerAnimatorEditor : Editor
    {
        private string[] displayedOptions;
        private List<Type> types;

        private void OnEnable()
        {
            InitializeDisplayedOptions();
        }

        private void InitializeDisplayedOptions()
        {
            types = (from domainAssembly in System.AppDomain.CurrentDomain.GetAssemblies()
                     from assemblyType in domainAssembly.GetTypes()
                     where IsSubclassOfGeneric(assemblyType, typeof(TweenerAnimationPropertyBase<>))
                     select assemblyType).ToList();

            displayedOptions = new string[types.Count + 1];
            displayedOptions[0] = "Add new animation property";

            for (int i = 0; i < types.Count; i++)
            {
                var attribute = Attribute.GetCustomAttribute(types[i], typeof(DisplayOptionAttribute)) as DisplayOptionAttribute;
                displayedOptions[i + 1] = attribute.Name;
            }
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            TweenerAnimator tweenerAnimator = target as TweenerAnimator;

            EditorGUILayout.BeginHorizontal();
            int selectedIndex = EditorGUILayout.Popup(0, displayedOptions);
            if (selectedIndex > 0)
            {
                serializedObject.Update();

                tweenerAnimator.gameObject.AddComponent(types[selectedIndex - 1]);

                serializedObject.ApplyModifiedProperties();
            }

            if (GUILayout.Button("Add new event"))
            {
                tweenerAnimator.gameObject.AddComponent<UnityEventInvokeAnimationEvent>();
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Play"))
            {
                var animator = target as TweenerAnimator;

                if (!EditorApplication.isPlaying)
                    return;

                animator.GetTweenerComponents();
                animator.Play();
            }

            if (GUILayout.Button("Stop"))
            {
                var animator = target as TweenerAnimator;

                if (!EditorApplication.isPlaying)
                    return;

                animator.Stop();
            }
            EditorGUILayout.EndHorizontal();
        }

        private bool IsSubclassOfGeneric(Type current, Type genericBase)
        {
            while ((current = current.BaseType) != null)
            {
                if (current.IsGenericType && current.GetGenericTypeDefinition() == genericBase)
                    return true;
            }
            return false;
        }
    }
}
#endif
