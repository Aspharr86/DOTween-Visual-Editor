using DG.Tweening;
using UnityEngine;

namespace DOTweenUtilities
{
    public abstract class TweenerAnimationEventBase : MonoBehaviour, ITweenerComponent
    {
        [SerializeField] private protected float delay;
        public float Delay { get => delay; set => delay = value; }
        [SerializeField] private protected string iD;
        public string ID { get => iD; set => iD = value; }

        private protected Tween tween;

        /// <summary> Set up Tweener. </summary>
        public abstract void SetTweener();

        public bool IsPlaying => (tween?.IsPlaying()) ?? false;

        public void Play() => tween?.Play();

        public void Restart() => tween?.Restart();

        public void Pause() => tween?.Pause();

        public void Stop() => tween?.Rewind();

        private void OnDestroy()
        {
            tween?.Kill();
        }
    }

    public abstract class TweenerAnimationEventBase<T, U> : TweenerAnimationEventBase where U : UnityEngine.Object
    {
        /// <summary> Use DOVirtual.DelayedCall() to set up Tween. </summary>
        public override void SetTweener()
        {
            tween?.Kill();
            tween = Clone(target);
        }

        public abstract Tween Clone(U target);

        [SerializeField] private protected U target;
        public U Target { get => target; set => target = value; }

        [SerializeField] private protected T parameter;
        public T Parameter { get => parameter; set => parameter = value; }
    }
}
