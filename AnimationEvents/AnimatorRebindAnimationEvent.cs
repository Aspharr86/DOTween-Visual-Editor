using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    [System.Serializable]
    public class AnimatorRebindAnimationEventArgs : TweenerAnimationEventArgs
    {
    }

    /// <summary> Call Animator.Rebind() by Tween. </summary>
    public class AnimatorRebindAnimationEvent : TweenerAnimationEventBase<AnimatorRebindAnimationEventArgs, Animator>
    {
        public override Tween Clone(Animator target)
        {
            var tween = DOVirtual.DelayedCall(delay, () => target.Rebind());
            if (!string.IsNullOrEmpty(iD)) tween.SetId(iD);
            tween.SetAutoKill(false);

            return tween;
        }
    }
}
