using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DOTweenUtilities
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(TweenerFactory))]
    public class TweenerFactoryEditor : Editor
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
                     where TweenerUtilities.IsSubclassOfGeneric(assemblyType, typeof(TweenerBase<,>))
                     select assemblyType).ToList();

            displayedOptions = new string[types.Count + 1];
            displayedOptions[0] = "Add new tweener";

            for (int i = 0; i < types.Count; i++)
            {
                var attribute = Attribute.GetCustomAttribute(types[i], typeof(DisplayOptionAttribute)) as DisplayOptionAttribute;
                displayedOptions[i + 1] = attribute.Name;
            }
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            int selectedIndex = EditorGUILayout.Popup(0, displayedOptions);
            if (selectedIndex > 0)
            {
                serializedObject.Update();

                for (int i = 0; i < targets.Length; i++)
                {
                    var factory = targets[i] as TweenerFactory;

                    factory.gameObject.AddComponent(types[selectedIndex - 1]);
                }

                serializedObject.ApplyModifiedProperties();
            }

            if (GUILayout.Button("Remove Factory"))
            {
                for (int i = 0; i < targets.Length; i++)
                {
                    var factory = targets[i] as TweenerFactory;

                    // Destroy may not be called from edit mode! Use DestroyImmediate instead.
                    DestroyImmediate(factory.transform.GetComponent<TweenerFactory>());
                }
            }
        }
    }
}
