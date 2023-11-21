using UnityEngine;
using DG.Tweening;

namespace DOTweenUtilities
{
    public abstract class TweenerAnimationPropertyBase<T, U> : TweenerBase, ITweenerComponent where U : UnityEngine.Object
    {
        public override void SetTweener()
        {
            tweener?.Kill();
            tweener = Clone(target);
        }

        public abstract Tweener Clone(U target);

        [SerializeField] private protected float delay;
        public float Delay { get => delay; set => delay = value; }
        [SerializeField] private protected int loops = -1;
        public int Loops { get => loops; set => loops = value; }
        [SerializeField] private protected T fromValue;
        public T FromValue { get => fromValue; set => fromValue = value; }
        [SerializeField] private protected T endValue;
        public T EndValue { get => endValue; set => endValue = value; }
        [SerializeField] private protected U target;
        public U Target => target;

        [SerializeField] private protected bool isFromTween;
        public bool IsFromTween { get => isFromTween; set => isFromTween = value; }
    }
}
