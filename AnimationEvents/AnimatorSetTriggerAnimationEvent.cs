using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    [System.Serializable]
    public class AnimatorSetTriggerAnimationEventArgs : TweenerAnimationEventArgs
    {
        public string name;
    }

    /// <summary> Call Animator.SetTrigger() by Tween. </summary>
    public class AnimatorSetTriggerAnimationEvent : TweenerAnimationEventBase<AnimatorSetTriggerAnimationEventArgs, Animator>
    {
        public override Tween Clone(Animator target)
        {
            var tween = DOVirtual.DelayedCall(delay, () => target.SetTrigger(parameter.name));
            if (!string.IsNullOrEmpty(iD)) tween.SetId(iD);
            tween.SetAutoKill(false);

            return tween;
        }
    }
}
