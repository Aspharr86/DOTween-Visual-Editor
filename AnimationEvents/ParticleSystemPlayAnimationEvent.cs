using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    [System.Serializable]
    public class ParticleSystemPlayAnimationEventArgs : TweenerAnimationEventArgs
    {
    }

    /// <summary> Call ParticleSystem.Play() by Tween. </summary>
    public class ParticleSystemPlayAnimationEvent : TweenerAnimationEventBase<AnimatorRebindAnimationEventArgs>
    {
        private new ParticleSystem particleSystem;

        public override void GetTweenedComponent()
        {
            particleSystem = tweenedGameObject.transform.GetComponent<ParticleSystem>();
        }

        public override void SetTweener()
        {
            tween?.Kill();
            tween = DOVirtual.DelayedCall(delay, () => particleSystem.Play())
            .SetAutoKill(false);
        }
    }
}
