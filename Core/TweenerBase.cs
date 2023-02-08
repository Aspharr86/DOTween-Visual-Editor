using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    enum OnDisableAction
    {
        None, Pause, Stop
    }

    public abstract class TweenerBase : MonoBehaviour
    {
        [SerializeField] private protected bool playOnAwake;
        [SerializeField] private protected OnDisableAction onDisableAction;

        [SerializeField] private protected float duration;
        public float Duration { get => duration; set => duration = value; }
        [SerializeField] private protected AnimationCurve animationCurve;
        public AnimationCurve AnimationCurve { get => animationCurve; set => animationCurve = value; }
        [SerializeField] private protected LoopType loopType;
        public LoopType LoopType { get => loopType; set => loopType = value; }

        private protected Tweener tweener;

        /// <summary> Get the component of Tweener. </summary>
        private protected abstract void Awake();

        /// <summary> Use DOTween.To() to set up Tweener. </summary>
        public abstract void SetTweener();

        public void Play()
        {
            tweener?.Play();
        }

        public void Restart()
        {
            tweener?.Restart();
        }

        public void Pause()
        {
            tweener?.Pause();
        }

        public void Stop()
        {
            tweener?.Rewind();
        }

        private void OnEnable()
        {
            if (playOnAwake)
            {
                SetTweener();
            }
            Play();
        }

        private void OnDisable()
        {
            switch (onDisableAction)
            {
                case OnDisableAction.None:
                    break;
                case OnDisableAction.Pause:
                    Pause();
                    break;
                case OnDisableAction.Stop:
                    Stop();
                    break;
            }
        }

        private void OnDestroy()
        {
            tweener?.Kill();
        }
    }

    public abstract class TweenerBase<T> : TweenerBase
    {
        [SerializeField] private protected T fromValue;
        public T FromValue { get => fromValue; set => fromValue = value; }
        [SerializeField] private protected T endValue;
        public T EndValue { get => endValue; set => endValue = value; }
    }
}
