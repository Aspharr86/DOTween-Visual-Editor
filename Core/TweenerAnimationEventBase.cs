using DG.Tweening;
using UnityEngine;

namespace DOTweenUtilities
{
    public abstract class TweenerAnimationEventBase : MonoBehaviour, ITweenerComponent
    {
        [SerializeField] private protected float delay;
        public float Delay { get => delay; set => delay = value; }

        private protected Tween tween;

        /// <summary> Override to get tweened component. </summary>
        public virtual void GetTweenedComponent()
        {
        }

        /// <summary> Use DOVirtual.DelayedCall() to set up Tween. </summary>
        public abstract void SetTweener();

        public void Play()
        {
            tween?.Play();
        }

        public void Restart()
        {
            tween?.Restart();
        }

        public void Pause()
        {
            tween?.Pause();
        }

        public void Stop()
        {
            tween?.Rewind();
        }

        private void OnDestroy()
        {
            tween?.Kill();
        }
    }

    public abstract class TweenerAnimationEventBase<T> : TweenerAnimationEventBase
    {
        [SerializeField] private protected GameObject tweenedGameObject;
        public GameObject TweenedGameObject { get => tweenedGameObject; set => tweenedGameObject = value; }

        [SerializeField] private protected T parameter;
        public T Parameter { get => parameter; set => parameter = value; }

        private void Awake()
        {
            if (tweenedGameObject == null) return;

            GetTweenedComponent();
        }
    }
}
