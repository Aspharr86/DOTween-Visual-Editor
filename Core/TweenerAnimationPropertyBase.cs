using UnityEngine;

namespace DOTweenUtilities
{
    public abstract class TweenerAnimationPropertyBase<T> : TweenerBase, ITweenerComponent
    {
        [SerializeField] private protected float delay;
        public float Delay { get => delay; set => delay = value; }
        [SerializeField] private protected bool isLoop;
        public bool IsLoop { get => isLoop; set => isLoop = value; }
        [SerializeField] private protected T fromValue;
        public T FromValue { get => fromValue; set => fromValue = value; }
        [SerializeField] private protected T endValue;
        public T EndValue { get => endValue; set => endValue = value; }
        [SerializeField] private protected GameObject tweenedGameObject;
        public GameObject TweenedGameObject { get => tweenedGameObject; set => tweenedGameObject = value; }
        [SerializeField] private protected bool isFromTween;
        public bool IsFromTween { get => isFromTween; set => isFromTween = value; }

        private protected override void Awake()
        {
            if (tweenedGameObject == null) return;

            GetTweenedComponent();
        }

        /// <summary> Override to get tweened component. </summary>
        public abstract void GetTweenedComponent();
    }
}
