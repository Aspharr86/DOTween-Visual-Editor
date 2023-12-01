using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    public enum OnDisableAction
    {
        None, Pause, Stop
    }

    public abstract class TweenerBase : MonoBehaviour
    {
        [SerializeField] private protected bool playOnAwake;
        [SerializeField] private protected OnDisableAction onDisableAction;

        [SerializeField] private protected float duration;
        public float Duration { get => duration; set => duration = value; }
        [SerializeField] private protected AnimationCurve animationCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
        public AnimationCurve AnimationCurve { get => animationCurve; set => animationCurve = value; }
        [SerializeField] private protected LoopType loopType;
        public LoopType LoopType { get => loopType; set => loopType = value; }
        [SerializeField] private protected string iD;
        public string ID { get => iD; set => iD = value; }

        private protected Tweener tweener;

        /// <summary> Set up Tweener. </summary>
        public abstract void SetTweener();

        public bool IsPlaying => (tweener?.IsPlaying()) ?? false;

        public void Play() => tweener?.Play();

        public void Restart() => tweener?.Restart();

        public void Pause() => tweener?.Pause();

        public void Stop() => tweener?.Rewind();

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

    public abstract class TweenerBase<T, U> : TweenerBase where U : UnityEngine.Object
    {
        public override void SetTweener()
        {
            tweener?.Kill();
            tweener = Clone(Target);
        }

        public abstract U Target { get; }
        public abstract Tweener Clone(U target);

        [SerializeField] private protected float delay;
        public float Delay { get => delay; set => delay = value; }
        [SerializeField] private protected int loops = -1;
        public int Loops { get => loops; set => loops = value; }
        [SerializeField] private protected T fromValue;
        public T FromValue { get => fromValue; set => fromValue = value; }
        [SerializeField] private protected T endValue;
        public T EndValue { get => endValue; set => endValue = value; }
    }
}
