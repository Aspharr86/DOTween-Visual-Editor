using DG.Tweening;
using UnityEngine;

namespace DOTweenUtilities
{
    [DisplayOption("Transform/DOScale")]
    public class TransformDOScaleTweener : TweenerBase<Vector3, Transform>
    {
        public override Transform SelfTarget => transform;

        public override Tweener Clone(Transform target)
        {
            var tweener = target.DOScale(endValue, duration);
            if (TweenType == TweenType.FROM) tweener.From(fromValue);
            tweener.SetTweenerParameters(delay, animationCurve, loops, loopType, iD);

            return tweener;
        }
    }
}
