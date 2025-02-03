using DG.Tweening;
using UnityEngine;

namespace DOTweenUtilities
{
    public enum OnEnableBehavior
    {
        None,
        Play,
        Resume,
    }

    public enum OnDisableBehavior
    {
        None,
        Pause,
        Stop,
    }

    public enum TargetType
    {
        SELF,
        OTHER,
    }

    public enum TweenType
    {
        TO,
        FROM,
    }

    public abstract class TweenerBase : MonoBehaviour
    {
        [SerializeField] private OnEnableBehavior onEnableBehavior;
        /// <summary> Gets or sets the behavior to execute when the GameObject is enabled. </summary>
        public OnEnableBehavior OnEnableBehavior
        {
            get => onEnableBehavior;
            set => onEnableBehavior = value;
        }
        [SerializeField] private OnDisableBehavior onDisableBehavior;
        /// <summary> Gets or sets the behavior to execute when the GameObject is disabled. </summary>
        public OnDisableBehavior OnDisableBehavior
        {
            get => onDisableBehavior;
            set => onDisableBehavior = value;
        }

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

        public abstract void Play();

        public abstract void Restart();

        public abstract void Pause();

        public abstract void Stop();

        private void OnEnable()
        {
            switch (onEnableBehavior)
            {
                case OnEnableBehavior.None:
                    break;
                case OnEnableBehavior.Play:
                    Restart();
                    break;
                case OnEnableBehavior.Resume:
                    Play();
                    break;
            }
        }

        private void OnDisable()
        {
            switch (onDisableBehavior)
            {
                case OnDisableBehavior.None:
                    break;
                case OnDisableBehavior.Pause:
                    Pause();
                    break;
                case OnDisableBehavior.Stop:
                    Stop();
                    break;
            }
        }

        private void OnDestroy()
        {
            tweener?.Kill();
        }
    }

    public abstract class TweenerBase<T, U> : TweenerBase, ITweenerComponent where U : UnityEngine.Object
    {
        public override void SetTweener()
        {
            tweener?.Kill();
            tweener = Clone(TargetType == TargetType.SELF ? SelfTarget : Target);
        }

        public override void Play()
        {
            tweener ??= Clone(TargetType == TargetType.SELF ? SelfTarget : Target);
            tweener.Play();
        }

        public override void Restart()
        {
            tweener ??= Clone(TargetType == TargetType.SELF ? SelfTarget : Target);
            tweener.Restart();
        }

        public override void Pause()
        {
            tweener ??= Clone(TargetType == TargetType.SELF ? SelfTarget : Target);
            tweener.Pause();
        }

        public override void Stop()
        {
            tweener ??= Clone(TargetType == TargetType.SELF ? SelfTarget : Target);
            tweener.Rewind();
        }

        public abstract Tweener Clone(U target);

        [SerializeField] private protected TargetType targetType;
        public TargetType TargetType { get => targetType; set => targetType = value; }
        public abstract U SelfTarget { get; }
        [SerializeField] private protected U target;
        public U Target { get => target; set => target = value; }
        [SerializeField] private protected float delay;
        public float Delay { get => delay; set => delay = value; }
        [SerializeField] private protected int loops = 1;
        public int Loops { get => loops; set => loops = value; }
        [SerializeField] private protected TweenType tweenType;
        public TweenType TweenType { get => tweenType; set => tweenType = value; }
        [SerializeField] private protected T fromValue;
        public T FromValue { get => fromValue; set => fromValue = value; }
        [SerializeField] private protected T endValue;
        public T EndValue { get => endValue; set => endValue = value; }
    }
}
