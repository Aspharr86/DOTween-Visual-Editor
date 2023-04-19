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
    public class AnimatorSetTriggerAnimationEvent : TweenerAnimationEventBase<AnimatorSetTriggerAnimationEventArgs>
    {
        private Animator animator;

        public override void GetTweenedComponent()
        {
            animator = tweenedGameObject.transform.GetComponent<Animator>();
        }

        public override void SetTweener()
        {
            tween?.Kill();
            tween = DOVirtual.DelayedCall(delay, () => animator.SetTrigger(parameter.name))
            .SetAutoKill(false);
        }
    }
}
