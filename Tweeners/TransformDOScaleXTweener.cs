using DG.Tweening;
using UnityEngine;

namespace DOTweenUtilities
{
    [DisplayOption("Transform/DOScaleX")]
    public class TransformDOScaleXTweener : TweenerBase<float, Transform>
    {
        public override Transform SelfTarget => transform;

        public override Tweener Clone(Transform target)
        {
            var tweener = target.DOScaleX(endValue, duration);
            if (TweenType == TweenType.FROM) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
