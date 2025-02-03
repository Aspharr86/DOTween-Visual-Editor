using DG.Tweening;
using UnityEngine;

namespace DOTweenUtilities
{
    [DisplayOption("Transform/DOScaleZ")]
    public class TransformDOScaleZTweener : TweenerBase<float, Transform>
    {
        public override Transform SelfTarget => transform;

        public override Tweener Clone(Transform target)
        {
            var tweener = target.DOScaleZ(endValue, duration);
            if (TweenType == TweenType.FROM) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
