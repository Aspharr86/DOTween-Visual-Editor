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
    public class SetActiveAnimationEvent : TweenerAnimationEventBase<SetActiveAnimationEventArgs>
    {
        public override void GetTweenedComponent()
        {
        }

        public override void SetTweener()
        {
            tween?.Kill();
            tween = DOVirtual.DelayedCall(delay, () => tweenedGameObject.SetActive(parameter.isActive))
            .SetAutoKill(false);
        }
    }
}
