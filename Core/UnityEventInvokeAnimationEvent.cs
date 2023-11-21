using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Call UnityEvent.Invoke() by Tween. </summary>
    public class UnityEventInvokeAnimationEvent : TweenerAnimationEventBase
    {
        /// <summary> Use DOVirtual.DelayedCall() to set up Tween. </summary>
        public override void SetTweener()
        {
            tween?.Kill();
            tween = Clone(target);
        }

        public Tween Clone(UnityEvent target)
        {
            return DOVirtual.DelayedCall(delay, () => target.Invoke())
            .SetAutoKill(false);
        }

        [SerializeField] private UnityEvent target;
        public UnityEvent Target { get => target; set => target = value; }
    }
}
