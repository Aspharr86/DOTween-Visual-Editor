using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

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
            types = (from type in Assembly.Load("Assembly-CSharp").GetTypes()
                     where type.Namespace == nameof(DOTweenUtilities)
                     where TweenerUtilities.IsSubclassOfGeneric(type, typeof(TweenerBase<,>))
                     where type.GetCustomAttribute<DisplayOptionAttribute>() is not null
                     select type).ToList();

            displayedOptions = new string[types.Count + 1];
            displayedOptions[0] = "Add new tweener";

            for (int i = 0; i < types.Count; i++)
            {
                var attribute = types[i].GetCustomAttribute<DisplayOptionAttribute>();
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

                    // Reference:
                    // https://docs.unity3d.com/ScriptReference/Undo.html
                    // Use Undo.AddComponent to correctly add a component which can be handle by the undo system
                    Undo.AddComponent(factory.gameObject, types[selectedIndex - 1]);
                }

                serializedObject.ApplyModifiedProperties();
            }

            if (GUILayout.Button("Remove Factory"))
            {
                for (int i = 0; i < targets.Length; i++)
                {
                    var factory = targets[i] as TweenerFactory;

                    Undo.DestroyObjectImmediate(factory);
                }
            }
        }
    }
}
