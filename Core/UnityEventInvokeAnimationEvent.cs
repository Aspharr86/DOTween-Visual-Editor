using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

namespace DOTweenUtilities
{
    /// <summary> Call UnityEvent.Invoke() by Tween. </summary>
    public class UnityEventInvokeAnimationEvent : TweenerAnimationEventBase
    {
        [SerializeField] private UnityEvent unityEvent;
        public UnityEvent UnityEvent { get => unityEvent; set => unityEvent = value; }

        /// <summary> Use DOVirtual.DelayedCall() to set up Tween. </summary>
        public override void SetTweener()
        {
            tween?.Kill();
            tween = DOVirtual.DelayedCall(delay, () => unityEvent.Invoke())
            .SetAutoKill(false);
        }
    }
}
