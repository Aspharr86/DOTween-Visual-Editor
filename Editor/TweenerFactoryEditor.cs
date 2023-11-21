using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DOTweenUtilities
{
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
                     where IsSubclassOfGeneric(assemblyType, typeof(TweenerBase<,>))
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

            TweenerFactory tweenerFactory = target as TweenerFactory;

            int selectedIndex = EditorGUILayout.Popup(0, displayedOptions);
            if (selectedIndex > 0)
            {
                serializedObject.Update();

                tweenerFactory.gameObject.AddComponent(types[selectedIndex - 1]);

                serializedObject.ApplyModifiedProperties();
            }

            if (GUILayout.Button("Remove Factory"))
            {
                // Destroy may not be called from edit mode! Use DestroyImmediate instead.
                DestroyImmediate(tweenerFactory.transform.GetComponent<TweenerFactory>());
            }
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
