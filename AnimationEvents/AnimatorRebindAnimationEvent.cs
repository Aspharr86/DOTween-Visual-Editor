using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    [System.Serializable]
    public class AnimatorRebindAnimationEventArgs : TweenerAnimationEventArgs
    {
    }

    /// <summary> Call Animator.Rebind() by Tween. </summary>
    public class AnimatorRebindAnimationEvent : TweenerAnimationEventBase<AnimatorRebindAnimationEventArgs>
    {
        private Animator animator;

        public override void GetTweenedComponent()
        {
            animator = tweenedGameObject.transform.GetComponent<Animator>();
        }

        public override void SetTweener()
        {
            tween?.Kill();
            tween = DOVirtual.DelayedCall(delay, () => animator.Rebind())
            .SetAutoKill(false);
        }
    }
}
