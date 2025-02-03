using UnityEditor;

namespace DOTweenUtilities
{
    public abstract class TweenerEditorBase : Editor
    {
        private protected SerializedProperty serializedOnEnableBehavior;
        private protected SerializedProperty serializedOnDisableBehavior;

        private protected SerializedProperty serializedDuration;
        private protected SerializedProperty serializedAnimationCurve;
        private protected SerializedProperty serializedLoopType;
        private protected SerializedProperty serializedID;

        private void OnEnable()
        {
            FindSerializedProperties();
        }

        private protected virtual void FindSerializedProperties()
        {
            serializedOnEnableBehavior = serializedObject.FindProperty("onEnableBehavior");
            serializedOnDisableBehavior = serializedObject.FindProperty("onDisableBehavior");

            serializedDuration = serializedObject.FindProperty("duration");
            serializedAnimationCurve = serializedObject.FindProperty("animationCurve");
            serializedLoopType = serializedObject.FindProperty("loopType");
            serializedID = serializedObject.FindProperty("iD");
        }
    }
}
