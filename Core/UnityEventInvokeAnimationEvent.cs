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
            var tween = DOVirtual.DelayedCall(delay, () => target.Invoke());
            if (!string.IsNullOrEmpty(iD)) tween.SetId(iD);
            tween.SetAutoKill(false);

            return tween;
        }

        [SerializeField] private UnityEvent target;
        public UnityEvent Target { get => target; set => target = value; }
    }
}
