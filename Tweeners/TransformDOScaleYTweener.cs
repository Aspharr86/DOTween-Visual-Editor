using DG.Tweening;
using UnityEngine;

namespace DOTweenUtilities
{
    [DisplayOption("Transform/DOScaleY")]
    public class TransformDOScaleYTweener : TweenerBase<float, Transform>
    {
        public override Transform SelfTarget => transform;

        public override Tweener Clone(Transform target)
        {
            var tweener = target.DOScaleY(endValue, duration);
            if (TweenType == TweenType.FROM) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
