using UnityEditor;

namespace DOTweenUtilities
{
    public abstract class TweenerEditorBase : Editor
    {
        private protected SerializedProperty serializedPlayOnAwake;
        private protected SerializedProperty serializedOnDisableAction;

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
            serializedPlayOnAwake = serializedObject.FindProperty("playOnAwake");
            serializedOnDisableAction = serializedObject.FindProperty("onDisableAction");

            serializedDuration = serializedObject.FindProperty("duration");
            serializedAnimationCurve = serializedObject.FindProperty("animationCurve");
            serializedLoopType = serializedObject.FindProperty("loopType");
            serializedID = serializedObject.FindProperty("iD");
        }
    }
}
