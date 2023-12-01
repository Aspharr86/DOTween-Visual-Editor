using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    [System.Serializable]
    public class ParticleSystemPlayAnimationEventArgs : TweenerAnimationEventArgs
    {
    }

    /// <summary> Call ParticleSystem.Play() by Tween. </summary>
    public class ParticleSystemPlayAnimationEvent : TweenerAnimationEventBase<AnimatorRebindAnimationEventArgs, ParticleSystem>
    {
        public override Tween Clone(ParticleSystem target)
        {
            var tween = DOVirtual.DelayedCall(delay, () => target.Play());
            if (!string.IsNullOrEmpty(iD)) tween.SetId(iD);
            tween.SetAutoKill(false);

            return tween;
        }
    }
}
