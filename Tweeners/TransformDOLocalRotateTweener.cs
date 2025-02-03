using DG.Tweening;
using UnityEngine;

namespace DOTweenUtilities
{
    [DisplayOption("Transform/DOLocalRotate")]
    public class TransformDOLocalRotateTweener : TweenerBase<Vector3, Transform>
    {
        public override Transform SelfTarget => transform;

        [SerializeField] private RotateMode rotateMode;
        public RotateMode RotateMode { get => rotateMode; set => rotateMode = value; }

        public override Tweener Clone(Transform target)
        {
            var tweener = target.DOLocalRotate(endValue, duration, rotateMode);
            if (TweenType == TweenType.FROM) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
