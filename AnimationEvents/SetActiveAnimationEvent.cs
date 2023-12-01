using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    [System.Serializable]
    public class SetActiveAnimationEventArgs : TweenerAnimationEventArgs
    {
        public bool isActive;
    }

    /// <summary> Call GameObject.SetActive() by Tween. </summary>
    public class SetActiveAnimationEvent : TweenerAnimationEventBase<SetActiveAnimationEventArgs, GameObject>
    {
        public override Tween Clone(GameObject target)
        {
            var tween = DOVirtual.DelayedCall(delay, () => target.SetActive(parameter.isActive));
            if (!string.IsNullOrEmpty(iD)) tween.SetId(iD);
            tween.SetAutoKill(false);

            return tween;
        }
    }
}
