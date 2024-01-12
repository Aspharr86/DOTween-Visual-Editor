using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DOTweenUtilities
{
    [CanEditMultipleObjects]
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
                     where TweenerUtilities.IsSubclassOfGeneric(assemblyType, typeof(TweenerAnimationPropertyBase<,>))
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

            EditorGUILayout.BeginHorizontal();
            int selectedIndex = EditorGUILayout.Popup(0, displayedOptions);
            if (selectedIndex > 0)
            {
                serializedObject.Update();

                // https://stackoverflow.com/questions/33090386/editing-multiple-objects-in-gui-with-caneditmultipleobjects
                for (int i = 0; i < targets.Length; i++)
                {
                    var animator = targets[i] as TweenerAnimator;

                    animator.gameObject.AddComponent(types[selectedIndex - 1]);
                }

                serializedObject.ApplyModifiedProperties();
            }

            if (GUILayout.Button("Add new event"))
            {
                serializedObject.Update();

                for (int i = 0; i < targets.Length; i++)
                {
                    var animator = targets[i] as TweenerAnimator;

                    animator.gameObject.AddComponent<UnityEventInvokeAnimationEvent>();
                }

                serializedObject.ApplyModifiedProperties();
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Play"))
            {
                if (!EditorApplication.isPlaying)
                    return;

                for (int i = 0; i < targets.Length; i++)
                {
                    var animator = targets[i] as TweenerAnimator;

                    animator.Play();
                }
            }

            if (GUILayout.Button("Stop"))
            {
                if (!EditorApplication.isPlaying)
                    return;

                for (int i = 0; i < targets.Length; i++)
                {
                    var animator = targets[i] as TweenerAnimator;

                    animator.Stop();
                }
            }
            EditorGUILayout.EndHorizontal();
        }
    }
}
